using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tlLanguageSpec
{
    public class tlLanguage
    {
        private readonly XmlDocument _cldrMain = new XmlDocument{XmlResolver = null};
        private readonly XmlDocument _cldrKeyboard = new XmlDocument { XmlResolver = null };
        private readonly XmlDocument _lang = new XmlDocument { XmlResolver = null };

        public tlLanguage(string code, string cldrFullPath)
        {
            var mainFullName = Path.Combine(cldrFullPath, "main", code + ".xml");
            _cldrMain.Load(mainFullName);
            var cldrKeyboardSpec = Path.Combine(cldrFullPath, "keyboards", "windows");
            var keyboardFiles = new DirectoryInfo(cldrKeyboardSpec).GetFiles(code + "*.xml");
            _cldrKeyboard.Load(keyboardFiles[0].FullName);
        }

        public void Parse()
        {
            _lang.RemoveAll();
            _lang.LoadXml(@"<tlLanguage/>");
            var g = Guid.NewGuid();
            Debug.Assert(_lang.DocumentElement != null, "_lang.DocumentElement != null");
            _lang.DocumentElement.AppendChild(Elem("id", g.ToString().Replace("-","").Substring(1,24)));
        }

        private XmlElement Elem(string name, string value)
        {
            var e = _lang.CreateElement(name);
            e.InnerText = value;
            return e;
        }
    }
}
