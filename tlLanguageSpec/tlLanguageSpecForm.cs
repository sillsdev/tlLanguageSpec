using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tlLanguageSpec
{
    public partial class TlLangSpec : Form
    {
        public static string UiLang = "en";

        public TlLangSpec()
        {
            InitializeComponent();
        }

        private void cldrBrowse_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            dlg.Description = "Common Language Data Repository";
            dlg.ShowDialog();
            cldrFullPath.Text = dlg.SelectedPath;
        }

        private void langCombo_MouseEnter(object sender, EventArgs e)
        {
            if (langCombo.Items.Count == 0)
            {
                var cldrMain = new CldrLang(UiLang, cldrFullPath.Text);
                langCombo.Items.AddRange(cldrMain.NameWithCode());
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            var code = GetCode();
            var lang = new TlLanguage(UiLang, code, cldrFullPath.Text);
            lang.Parse(fontName.Text, countryCombo.Text);
        }

        private string GetCode()
        {
            var lText = langCombo.SelectedItem.ToString();
            if (string.IsNullOrEmpty(lText) || !lText.Contains("(") || !lText.Contains(")"))
                return "";
            var openParen = lText.IndexOf("(", StringComparison.Ordinal) + 1;
            var len = lText.IndexOf(")", StringComparison.Ordinal) - openParen;
            var code = lText.Substring(openParen, len);
            return code;
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            var dlg = new FontDialog();
            dlg.ShowDialog();
            fontName.Text = dlg.Font.Name;
        }

        private void langCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cldrMain = new CldrLang(UiLang, cldrFullPath.Text);
            countryCombo.Items.AddRange(cldrMain.Countries(GetCode()));
            countryCombo.SelectedIndex = 0;
        }

    }
}
