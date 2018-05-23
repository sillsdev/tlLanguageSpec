// ---------------------------------------------------------------------------------------------
#region // Copyright (c) 2015, SIL International.
// <copyright from='2015' to='2015' company='SIL International'>
//		Copyright (c) 2015, SIL International.
//    
//		This software is distributed under the MIT License, as specified in the LICENSE.txt file.
// </copyright> 
#endregion
//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace tlLanguageSpec
{
    public class CldrLang
    {
        private readonly XmlDocument _cldrMain = new XmlDocument{XmlResolver = null};
        private readonly XmlDocument _cldrKeyboard = new XmlDocument { XmlResolver = null };
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
            Debug.Assert(nameNodes != null, "nameNodes != null");
            foreach (XmlNode nameNode in nameNodes)
            {
                Debug.Assert(nameNode.Attributes != null, "nameNode.Attributes != null");
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
                var countryBegin = fileInfo.Name.IndexOf("_", StringComparison.Ordinal) + 1;
                var countryLen = fileInfo.Name.IndexOf(".", StringComparison.Ordinal) - countryBegin;
                var countryCode = fileInfo.Name.Substring(countryBegin, countryLen);
                var node = _cldrMain.SelectSingleNode(string.Format("//territory[@type='{0}']", countryCode));
                Debug.Assert(node != null, "territory node != null");
                countries.Add(node.InnerText);
            }
            return countries.ToArray();
        }

        public string[] Keyboards(string code)
        {
            var keyboards = new List<string>();
            var info = new DirectoryInfo(Path.Combine(_path, "..", "keyboards", "windows")).GetFiles(code + "-*.xml");
            foreach (FileInfo fileInfo in info)
            {
                _cldrKeyboard.RemoveAll();
                _cldrKeyboard.Load(fileInfo.FullName);
                var keyboardName = _cldrKeyboard.SelectSingleNode("//name/@value");
                Debug.Assert(keyboardName != null, "keyboardName != null");
                keyboards.Add(keyboardName.InnerText);
            }
            return keyboards.ToArray();
        }
    }
}
