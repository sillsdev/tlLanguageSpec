namespace tlLanguageSpec
{
    partial class TlLangSpec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cldrFullPath = new System.Windows.Forms.TextBox();
            this.cldrBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.langCombo = new System.Windows.Forms.ComboBox();
            this.ok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.fontName = new System.Windows.Forms.TextBox();
            this.fontButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.countryCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLDR";
            // 
            // cldrFullPath
            // 
            this.cldrFullPath.Location = new System.Drawing.Point(63, 6);
            this.cldrFullPath.Name = "cldrFullPath";
            this.cldrFullPath.Size = new System.Drawing.Size(333, 22);
            this.cldrFullPath.TabIndex = 0;
            this.cldrFullPath.Text = "E:\\Ref\\cldr";
            // 
            // cldrBrowse
            // 
            this.cldrBrowse.Location = new System.Drawing.Point(402, 6);
            this.cldrBrowse.Name = "cldrBrowse";
            this.cldrBrowse.Size = new System.Drawing.Size(75, 23);
            this.cldrBrowse.TabIndex = 1;
            this.cldrBrowse.Text = "Browse";
            this.cldrBrowse.UseVisualStyleBackColor = true;
            this.cldrBrowse.Click += new System.EventHandler(this.cldrBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Download From:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(129, 39);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(267, 17);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.unicode.org/Public/cldr/27.0.1/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Language:";
            // 
            // langCombo
            // 
            this.langCombo.FormattingEnabled = true;
            this.langCombo.Location = new System.Drawing.Point(95, 66);
            this.langCombo.Name = "langCombo";
            this.langCombo.Size = new System.Drawing.Size(213, 24);
            this.langCombo.TabIndex = 2;
            this.langCombo.SelectedIndexChanged += new System.EventHandler(this.langCombo_SelectedIndexChanged);
            this.langCombo.MouseEnter += new System.EventHandler(this.langCombo_MouseEnter);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(402, 166);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 6;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Font:";
            // 
            // fontName
            // 
            this.fontName.Location = new System.Drawing.Point(95, 145);
            this.fontName.Name = "fontName";
            this.fontName.Size = new System.Drawing.Size(164, 22);
            this.fontName.TabIndex = 4;
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(274, 145);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(101, 23);
            this.fontButton.TabIndex = 5;
            this.fontButton.Text = "Choose Font";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Country:";
            // 
            // countryCombo
            // 
            this.countryCombo.FormattingEnabled = true;
            this.countryCombo.Location = new System.Drawing.Point(95, 105);
            this.countryCombo.Name = "countryCombo";
            this.countryCombo.Size = new System.Drawing.Size(213, 24);
            this.countryCombo.TabIndex = 3;
            // 
            // TlLangSpec
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 201);
            this.Controls.Add(this.countryCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fontButton);
            this.Controls.Add(this.fontName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.langCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cldrBrowse);
            this.Controls.Add(this.cldrFullPath);
            this.Controls.Add(this.label1);
            this.Name = "TlLangSpec";
            this.Text = "Transparent Language - Langauge Spec";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cldrFullPath;
        private System.Windows.Forms.Button cldrBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox langCombo;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fontName;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox countryCombo;
    }
}

