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

- The project multi targets `net8.0;net9.0;net10.0`. Nothing here is Windows only, but the helper
  batch files are.
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

- `LanguageManager.SetCurrentLanguage` and `SetCurrentLanguageFromName` use `First(...)`, so an
  unknown language throws `InvalidOperationException` before the following null check can run. The
  null check and `ThrowLanguageNotProperlyLoadedException` are effectively dead code. Changing this
  to `FirstOrDefault` changes the thrown exception type and belongs in the changelog.
- `ImportExport.LoadDefaults` swallows per file errors into `Exceptions`, and `LanguageManager`
  turns a non empty list into a `LanguageInitializationException` whose message is the result of
  `List<Exception>.ToString()`, so it is the type name, not the messages.
- The Windows Forms samples in `HowToUse.md` are illustration only, there is no such project in
  this repository. Do not turn them into links to one.

## Releasing

The steps are the ones in `Updating.md`:

1. Make the change.
2. Update `PackageReleaseNotes` in `src/Language/Languages.csproj` to the new version line.
3. Add an entry at the top of `Changelog.md` in the existing format:
   `* **Version 1.1.8.0 (2026-08-09)** : Short description.`
4. Tag the commit with the plain version number, no `v` prefix (`1.1.6`, `1.1.5`, ...).
   GitVersion.MsBuild derives assembly and package version from the tag, never edit a version
   property or an assembly version by hand.
5. `BuildAndPushPackage.bat` cleans `bin` and `obj`, builds Release and pushes `.nupkg` and
   `.snupkg` to nuget.org and to github. It needs `NUGET_API_KEY` and `GITHUB_API_KEY` in the
   environment. Never run it unless explicitly asked to publish.

Also update the "Available for" list in `README.md` when the target frameworks change.

There is no CI configuration in this repository, no `.github` folder and no publish pipeline. The
AppVeyor badge in `README.md` points to a build that is configured outside of the repository.

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
