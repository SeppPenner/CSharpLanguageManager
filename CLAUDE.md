# Project rules for Claude

## What this is

CSharpLanguageManager is a small .NET class library that lets an application be multilingual. It
loads XML language files from a `languages` folder next to the executing assembly and hands out
translated strings by key. It is published on NuGet as
[HaemmerElectronics.SeppPenner.Language](https://www.nuget.org/packages/HaemmerElectronics.SeppPenner.Language/),
so every public API change is a breaking change for consumers.

One solution `src/Language.sln` with exactly one project, `src/Language/Languages.csproj`
(assembly and root namespace `Languages`, folder `Language`, package id
`HaemmerElectronics.SeppPenner.Language`, all three names differ on purpose). There is no test
project, no example project and no second project of any kind.

Layout inside `src/Language`:

- `Interfaces/`: `ILanguageManager`, `ILanguage`, `IImportExport`, `IWord`. This is the public
  contract, consumers program against it. A member added to an implementation that callers need
  belongs in the interface as well.
- `Implementation/`:
  - `LanguageManager.cs`: the entry point. Loads all languages in the constructor, keeps the
    current one, raises `OnLanguageChanged`, resolves words via the current language.
  - `ImportExport.cs`: file access. Reads every `*.xml` in `<assembly directory>/languages` with
    `XDocument` plus `XmlSerializer` and collects failures in an `Exception` list instead of
    throwing per file.
  - `Language.cs`: one language (`Name`, `Identifier`, `Words`, `GetWord`, `GetCulture`).
  - `Word.cs`: a key and value pair.
- `Exceptions/`: `LanguageInitializationException`, `LanguageNotLoadedException`,
  `WrongFileExtensionException`.
- `Events/`: `LanguageChangedEventArgs`.
- `GlobalUsings.cs`: all usings of the project.

The runtime contract is convention based and part of the public behaviour:

- Language files are discovered in the `languages` directory beside the assembly, they must have
  the extension `.xml` and deserialize into `Language` (`Identifier`, `Name`,
  `Words/Word/Key` plus `Value`).
- `languages/de-DE.xml` and `languages/en-US.xml` in the repository root are the shipped samples.
  They are packed into the NuGet package under `languages`.
- Identifiers follow the culture names that `CultureInfo` understands (`de-DE`, `en-US`), because
  `Language.GetCulture()` feeds the identifier into `new CultureInfo(...)`.

Renaming the folder, changing the file extension check or changing the XML shape breaks every
consumer, so treat those as deliberate breaking changes, not as cleanup.

## Build

```powershell
dotnet build src/Language.sln
```

- The project multi targets `net10.0;net11.0`, so building needs the .NET 11 SDK. Nothing here
  is Windows only, but the helper batch files are.
- `GeneratePackageOnBuild` is on, so **every** build packs: a `.nupkg` and a `.snupkg` appear in
  `src/Language/bin/<configuration>`, in Debug too. The version comes from GitVersion, for example
  `1.1.7-3` for the third commit after tag `1.1.6`.
- `TreatWarningsAsErrors` is enabled in `src/Directory.Build.props`, so every warning breaks the
  build, NuGet warnings (`NU****`) from restore and pack included. A clean build reports zero
  warnings, keep it that way.
- `NU1803` (HTTP source usage during restore) is the one warning suppressed via `NoWarn` in the
  csproj. Fix warnings instead of extending that list.
- The sample language files are packed to `languages` in the package, deliberately not below
  `lib`, because that folder is reserved for target framework folders. The old `lib\languages`
  path is what produced `NU5103` and `NU5128`.
- Restore needs nuget.org. If a private feed is configured globally on the machine and answers
  404 for public packages, restore fails with `NU1301`. Then build with an explicit source:
  `dotnet build src/Language.sln --source https://api.nuget.org/v3/index.json`.
- `Delete-BIN-OBJ-Folders.bat` deletes all `bin` and `obj` folders below the repository root.
- **There are no tests in this repository.** Never claim a test run happened. Verification means a
  clean build, and where behaviour changed, a small throwaway console application that references
  the built assembly and has language XML files next to its own executable.

## Code conventions

Follow the surrounding code, it is consistent throughout:

- File header comment block with `<copyright file="..." company="Hämmer Electronics">` and a
  `<summary>`, then the file-scoped namespace.
- XML doc comments on every type and every member, private members included, no exceptions.
- Implementations repeat the documentation of the interface: `/// <inheritdoc cref = "IXyz" />.`,
  then the full `<summary>`, `<param>`, `<returns>`, then `/// <seealso cref = "IXyz" />.`. Keep
  that pattern including the unusual spaces inside `cref = "..."` and the trailing dot, do not
  shorten it to a plain `<inheritdoc/>`.
- `Nullable`, `ImplicitUsings` and `LangVersion latest` are enabled.
- New `using` directives go into `src/Language/GlobalUsings.cs`, inside the existing
  `#pragma warning disable IDE0065` block, never at the top of a file. The editorconfig requires
  usings inside the namespace (`csharp_using_directive_placement=inside_namespace:warning`), which
  global usings cannot satisfy, that is what the pragma is for. Do not add other pragmas.
- Fields, properties, methods and events are always accessed with `this.` qualification
  (`dotnet_style_qualification_for_*` at severity `warning`).
- `src/.editorconfig` also enforces braces everywhere, no multiple blank lines, four spaces, CRLF
  and UTF-8. Analyzer warnings are fixed, not silenced.
- One type per file, file name equals type name, folder equals category (`Interfaces`,
  `Implementation`, `Exceptions`, `Events`).

## Known quirks

Do not silently "clean up" these, they are behaviour that consumers may depend on:

- `SetCurrentLanguage` and `SetCurrentLanguageFromName` throw `LanguageNotLoadedException` for an
  unknown language and leave the current language untouched. Up to version 1.1.6.0 they threw the
  `InvalidOperationException` of `First(...)` instead.
- `ImportExport.LoadDefaults` does not throw per file, it collects the failures in `Exceptions`.
  `LanguageManager` turns a non empty list into one `LanguageInitializationException` whose message
  joins the single messages and whose inner exception is an `AggregateException`.
- `ThrowLanguageNotProperlyLoadedException` is annotated with `[DoesNotReturn]`. Without that
  attribute the nullable analysis flags the assignment after the null check, and warnings are
  errors here.
- The Windows Forms samples in `HowToUse.md` are illustration only, there is no such project in
  this repository. Do not turn them into links to one.

## Releasing

**Every new version is released completely.** Changelog, README, nuget.org, GitHub Packages and a
GitHub release belong to every version, none of these steps is optional and none of them waits for
a separate request.

1. Make the change.
2. Add an entry at the top of `Changelog.md` in the existing format:
   `* **Version 1.1.8.0 (2026-08-09)** : Short description.`
3. Copy that text into `PackageReleaseNotes` in `src/Language/Languages.csproj`, in the single line
   format `Version 1.1.8.0 (2026-08-09): Short description.`. It is the only place in the build
   files that names a version, and it is duplicated from the changelog by hand.
4. Update `README.md` for every version. The `## Available for` list has to match the
   `TargetFrameworks` of the project, and nothing there may describe a state the package has left
   behind. `HowToUse.md` is packed into the package as well, check it the same way.
5. Commit that.
6. Tag the commit with the plain version number, no `v` prefix (`1.1.8`, `1.1.7`, ...). The existing
   tags are lightweight tags, create new ones the same way. GitVersion.MsBuild derives assembly and
   package version from the tag, never edit a version property or an assembly version by hand.
7. Push the commits and the tag.
8. Only then build the package, and build it while the tag is the newest commit. GitVersion takes
   the version from the tag plus the distance to it, so a build before the tag or after another
   commit produces a prerelease version like `1.1.9-3+Branch.master.Sha...`, and that version would
   end up on nuget.org. `git describe --tags` has to answer with the plain tag.
9. Publish to nuget.org with `BuildAndPushPackage.bat`, started from the repository root, its first
   line is `cd .\src`. It deletes every `bin` and `obj` below `src`, builds `-c Release` and pushes
   the `.nupkg` and the `.snupkg` to nuget.org with `%NUGET_API_KEY%` and to the NuGet source named
   `github` with `%GITHUB_API_KEY%`. The four push lines carry a leading `@`, because `ECHO` is on
   there and cmd would otherwise write each of them to the console after the variable expansion,
   both API keys included. Do not remove those prefixes.
   The script ends with `PAUSE`, so it wants a console. Call it with its full path: the Claude Code
   shell sets `NoDefaultCurrentDirectoryInExePath=1`, so cmd does not find a bare
   `BuildAndPushPackage.bat` in the current directory. Because it always rebuilds, it is only
   correct as long as no commit sits on top of the tag. If one does, push the package that was
   built from the tagged state instead, by its file name and not with the wildcard, because
   `GeneratePackageOnBuild` leaves a `.nupkg` of every intermediate build in `bin`:
   `dotnet nuget push HaemmerElectronics.SeppPenner.Language.1.1.8.nupkg -s "nuget.org" --skip-duplicate -k %NUGET_API_KEY%`
   in `src/Language/bin/Release`. That command takes the matching `.snupkg` with it. A push to
   nuget.org cannot be taken back, the version is burned even after unlisting. nuget.org needs a few
   minutes to validate a new version before it is listed.
10. Publish the same `.nupkg` to GitHub Packages,
    `https://nuget.pkg.github.com/SeppPenner/index.json`. The script only reaches it if a NuGet
    source named `github` is registered on the machine, `dotnet nuget list source` shows that. On
    2026-11-24 only nuget.org was registered here, so the two `github` lines of the script fail and
    the push has to be done by hand in `src/Language/bin/Release`:
    `dotnet nuget push HaemmerElectronics.SeppPenner.Language.1.1.8.nupkg -s https://nuget.pkg.github.com/SeppPenner/index.json --skip-duplicate --api-key <token>`.
    The API key is a GitHub token with the scope `write:packages`, for example from
    `gh auth token`. If `gh auth status` lists no `write:packages`, the user has to run
    `gh auth refresh -h github.com -s write:packages,read:packages`, it needs a browser login.
    GitHub Packages takes no symbol packages, push the `.nupkg` only.
11. Create the GitHub release:
    `gh release create 1.1.8 -R SeppPenner/CSharpLanguageManager --verify-tag --latest --title "Version 1.1.8.0 (2026-08-09)" --notes-file <file>`.
    The notes are the changelog sentence plus the line
    `NuGet: https://www.nuget.org/packages/HaemmerElectronics.SeppPenner.Language/1.1.8`. Write
    credits as `` `@name` `` in backticks, a bare `@name` notifies that person again.

The version in `Changelog.md` has four parts (`1.1.8.0`), the tag has three (`1.1.8`). The old tag
`1.0.4.1` is the one exception.

nuget.org and GitHub Packages hold 1.0.0.5 to 1.0.0.12 and 1.0.1 to 1.1.9, `1.0.4.1` included.
The tags start with 1.0.2, so the versions before it have no GitHub release, every tag has one.
The missing versions on GitHub Packages and the releases were added on 2026-11-24.

There is no CI configuration in this repository, no `.github` folder and no publish pipeline. The
AppVeyor badge in `README.md` points to a build that is configured outside of the repository.

## Git

- Include the full GitHub pull request or issue URL in the body of each related commit on a `Refs:`
  line. Use the [GitHub issue skill](.claude/skills/github-issue/SKILL.md) for issue work and closeout.

## Writing style

- Commit messages are written **in English only**: short, precise subject line, explanatory body
  when needed.
- Code comments and comments in project files such as `.csproj` are **always English**, regardless
  of the language used in the conversation.
- **No em dashes or en dashes** (`—`, `–`), neither in prose, commit messages, code comments nor
  documentation. Use a regular hyphen, comma, colon, parentheses or a separate sentence.
- German texts (documentation, chat replies) always use real umlauts and ß, never ASCII
  transliterations such as `ae`, `oe`, `ue` or `ss`. Identifiers, file names and configuration keys
  stay unchanged where umlauts are technically undesirable.
