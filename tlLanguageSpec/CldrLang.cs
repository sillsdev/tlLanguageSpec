using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tlLanguageSpec
{
    public class CldrLang
    {
        XmlDocument cldrMain = new XmlDocument{XmlResolver = null};

        public CldrLang(string uiLang, string cldrFullName)
        {
            var fullName = Path.Combine(cldrFullName, "main", uiLang + ".xml");
            cldrMain.Load(fullName);
        }

        public string[] NameWithCode()
        {
            var names = new List<string>();
            var nameNodes = cldrMain.SelectNodes("//languages/language");
            foreach (XmlNode nameNode in nameNodes)
            {
                names.Add(string.Format("{0} ({1})", nameNode.InnerText, nameNode.Attributes["type"].Value));
            }
            names.Sort();
            return names.ToArray();
        }
    }
}
