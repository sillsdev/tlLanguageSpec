using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tlLanguageSpec
{
    public class CldrLang
    {
        private readonly XmlDocument _cldrMain = new XmlDocument{XmlResolver = null};
        private readonly string _path;

        public CldrLang(string uiLang, string cldrFullName)
        {
            _path = Path.Combine(cldrFullName, "main");
            var fullName = Path.Combine(_path, uiLang + ".xml");
            _cldrMain.Load(fullName);
        }

        public string[] NameWithCode()
        {
            var names = new List<string>();
            var nameNodes = _cldrMain.SelectNodes("//languages/language");
            foreach (XmlNode nameNode in nameNodes)
            {
                names.Add(string.Format("{0} ({1})", nameNode.InnerText, nameNode.Attributes["type"].Value));
            }
            names.Sort();
            return names.ToArray();
        }

        internal string[] Countries(string code)
        {
            var countries = new List<string>();
            var info = new DirectoryInfo(_path).GetFiles(code + "_*.xml");
            foreach (FileInfo fileInfo in info)
            {
                var countryBegin = fileInfo.Name.IndexOf("_") + 1;
                var countryLen = fileInfo.Name.IndexOf(".") - countryBegin;
                var countryCode = fileInfo.Name.Substring(countryBegin, countryLen);
                var node = _cldrMain.SelectSingleNode(string.Format("//territory[@type='{0}']", countryCode));
                Debug.Assert(node != null, "territory node != null");
                countries.Add(node.InnerText);
            }
            return countries.ToArray();
        }
    }
}
