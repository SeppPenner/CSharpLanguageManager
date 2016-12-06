CSharpLanguageManager
====================================

CSharpLanguageManager is an assembly/ library to build multilingual programms in .Net.
The assembly was written and tested in .Net 4.6.2.


## Basic usage:
If you just have one language loaded, you don't need to set the current language as
the language manager uses the only language as default.
```csharp
public void Test()
{
	ILanguageManager _lm = new LanguageManager();
	var test = _lm.GetCurrentLanguage().GetWord("Test");
}
```
If you have more than one language loaded, you need to set the current (wanted) language.
The language identifiers are taken from https://msdn.microsoft.com/de-de/library/ee825488(v=cs.20).aspx.
```csharp
public void Test()
{
	ILanguageManager _lm = new LanguageManager();
	_lm.SetCurrentLanguage("de-DE");
	var test = _lm.GetCurrentLanguage().GetWord("YourKey");
}
```

## Subscription to OnLanguageChanged:
You can "subscribe" to the EventHandler OnLanguageChanged to update your GUI whenever the language is changed.
This can be done like the following: (For more information see the example project)

```csharp
using System;
using System.Windows.Forms;
using Languages.Implementation;
using Languages.Interfaces;

namespace TestLanguage
{
    public partial class Main : Form
    {
        private readonly ILanguageManager _lm = new LanguageManager();

        public Main()
        {
            InitializeComponent();
            InitializeLanguageManager();
            LoadLanguagesToCombo();
        }

        private void InitializeLanguageManager()
        {
            _lm.SetCurrentLanguage("de-DE");
            _lm.OnLanguageChanged += OnLanguageChanged;
        }

        private void LoadLanguagesToCombo()
        {
            foreach (var lang in _lm.GetLanguages())
            {
                comboBoxLanguage.Items.Add(lang.Name);
            }
            comboBoxLanguage.SelectedIndex = 0;
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxLanguage.SelectedItem.ToString())
            {
                case "German":
                    _lm.SetCurrentLanguage("de-DE");
                    break;
                case "English (US)":
                    _lm.SetCurrentLanguage("en-US");
                    break;
            }
        }

        private void OnLanguageChanged(object sender, EventArgs eventArgs)
        {
            labelSelectLanguage.Text = _lm.GetCurrentLanguage().GetWord("SelectLanguage");
        }
    }
}
```

## How do the language files need to look like:
The file's naming is not important but should be something like "de-DE.xml".
All language files need to be included into the "languages" folder in your application folder.
```xml
<?xml version="1.0" encoding="UTF-8" ?>
<Language xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Identifier>de-DE</Identifier> <!--According to https://msdn.microsoft.com/de-de/library/ee825488(v=cs.20).aspx-->
	<Name>German<Name>
	<Words>
		<Word>
			<Key>YourKey</Key>
			<Value>TestString</Value>
		</Word>
	</Words>
</Language>
```

An example project can be found here.

Change history
--------------

* **Version 1.0.0.1 (2016-12-06)** : Added EventHandler to subscribe to Event.
* **Version 1.0.0.0 (2016-12-06)** : 1.0 release.