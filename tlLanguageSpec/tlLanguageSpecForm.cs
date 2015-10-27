using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private static ArrayList _lang = new ArrayList();

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count == 0)
            {
                var cldrMain = new CldrLang(UiLang, cldrFullPath.Text);
                comboBox1.Items.AddRange(cldrMain.NameWithCode());
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            var lText = comboBox1.SelectedItem.ToString();
            var openParen = lText.IndexOf("(") + 1;
            var len = lText.IndexOf(")") - openParen;
            var code = lText.Substring(openParen, len);
            var lang = new tlLanguage(code, cldrFullPath.Text);
            lang.Parse();
        }

    }
}
