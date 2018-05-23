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
using System.Windows.Forms;

namespace tlLanguageSpec
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.Newtonsoft
        /// <remarks>http://json.codeplex.com/</remarks>
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TlLangSpec());
        }
    }
}
