using System;
using System.CodeDom;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Xml;

namespace tlLanguageSpec
{
    public class TlLanguage
    {
        private readonly string _code;
        private readonly XmlDocument _cldrUiMain = new XmlDocument { XmlResolver = null };
        private readonly XmlDocument _cldrMain = new XmlDocument { XmlResolver = null };
        private readonly XmlDocument _cldrKeyboard = new XmlDocument { XmlResolver = null };
        private readonly XmlDocument _lang = new XmlDocument { XmlResolver = null };

        public TlLanguage(string uiLang, string code, string cldrFullPath)
        {
            var uiFullName = Path.Combine(cldrFullPath, "main", uiLang + ".xml");
            _cldrUiMain.Load(uiFullName);
            _code = code;
            var mainFullName = Path.Combine(cldrFullPath, "main", code + ".xml");
            _cldrMain.Load(mainFullName);
            var cldrKeyboardSpec = Path.Combine(cldrFullPath, "keyboards", "windows");
            var keyboardFiles = new DirectoryInfo(cldrKeyboardSpec).GetFiles(code + "*.xml");
            _cldrKeyboard.Load(keyboardFiles[0].FullName);
        }

        public void Parse(string fontName, string country)
        {
            _lang.RemoveAll();
            _lang.LoadXml(@"<tlLanguage/>");
            var g = Guid.NewGuid();
            AppendChild("id", g.ToString().Replace("-","").Substring(1,24));
            var langName = AppendChildUiXpath("name", string.Format("//languages/language[@type='{0}']", _code));
            AppendChildUiXpath("script", string.Format("//script[text()='{0}']/@type", langName));
            AppendChild("font", fontName);
            AppendChild("country", country);
            var exemplarNode = _cldrMain.SelectSingleNode("//exemplarCharacters");
            Debug.Assert(exemplarNode != null, "exemplarNode != null");
            var exemplarText = exemplarNode.InnerText.Trim("[]".ToCharArray());
            foreach (string input in exemplarText.Split(' '))
            {
                var codes = "";
                for (int i = 0; i < input.Length; i += Char.IsSurrogatePair(input, i) ? 2 : 1)
                {
                    int x = Char.ConvertToUtf32(input, i);
                    codes += string.Format("{0:X4}", x);
                }
                AppendChild("alphabet", codes);
            }
            //Numerals
            //Punctuation
            //accent_char_set
            //other_chars

            //keyboards
            //accents
            //substitutions
            //ignore_rules
/* 
  <content_code>KANin</content_code>
  <legacy_code>KANNADA</legacy_code>
  <space_delimited>true</space_delimited>
  <ms_translate_code />
  <polyglossia_code>kannada</polyglossia_code>
  <google_code>kn</google_code>
  <iso_639_1>kn</iso_639_1>
  <iso_639_2>kan</iso_639_2>
  <iso_639_3>kan</iso_639_3>
  <iso_3166_2>IN</iso_3166_2>
  <dialect_of />
  <dialects />
  <transliteration_of />
  <transliterations />
  <localizations>
    <id>5542839b68669d1055e87f30</id>
    <name>ENGLISH</name>
    <translates_to>ಕನ್ನಡ</translates_to>
  </localizations>
  <locked>false</locked>
  <in_use>false</in_use>
  <rtl>false</rtl>
*/



        }

        private void AppendChild(string name, string value)
        {
            var e = _lang.CreateElement(name);
            e.InnerText = value;
            Debug.Assert(_lang.DocumentElement != null, "_lang.DocumentElement != null");
            _lang.DocumentElement.AppendChild(e);
        }

        private string AppendChildUiXpath(string name, string xpath)
        {
            var node = _cldrUiMain.SelectSingleNode(xpath);
            Debug.Assert(node != null, "node != null");
            AppendChild(name, node.InnerText);
            return node.InnerText;
        }

        private string AppendChildMainXpath(string name, string xpath)
        {
            var node = _cldrMain.SelectSingleNode(xpath);
            Debug.Assert(node != null, "node != null");
            AppendChild(name, node.InnerText);
            return node.InnerText;
        }
    }
}
