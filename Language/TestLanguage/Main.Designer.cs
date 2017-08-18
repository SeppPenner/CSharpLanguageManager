namespace TestLanguage
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelSelectLanguage = new System.Windows.Forms.Label();
            this.buttonReloadLanguageFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(165, 12);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(139, 21);
            this.comboBoxLanguage.TabIndex = 1;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // labelSelectLanguage
            // 
            this.labelSelectLanguage.AutoSize = true;
            this.labelSelectLanguage.Location = new System.Drawing.Point(12, 15);
            this.labelSelectLanguage.Name = "labelSelectLanguage";
            this.labelSelectLanguage.Size = new System.Drawing.Size(97, 13);
            this.labelSelectLanguage.TabIndex = 2;
            this.labelSelectLanguage.Text = "Choose Language:";
            // 
            // buttonReloadLanguageFiles
            // 
            this.buttonReloadLanguageFiles.Location = new System.Drawing.Point(165, 53);
            this.buttonReloadLanguageFiles.Name = "buttonReloadLanguageFiles";
            this.buttonReloadLanguageFiles.Size = new System.Drawing.Size(139, 23);
            this.buttonReloadLanguageFiles.TabIndex = 3;
            this.buttonReloadLanguageFiles.Text = "Reload language files";
            this.buttonReloadLanguageFiles.UseVisualStyleBackColor = true;
            this.buttonReloadLanguageFiles.Click += new System.EventHandler(this.ButtonReloadLanguageFiles_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 101);
            this.Controls.Add(this.buttonReloadLanguageFiles);
            this.Controls.Add(this.labelSelectLanguage);
            this.Controls.Add(this.comboBoxLanguage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "TestApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelSelectLanguage;
        private System.Windows.Forms.Button buttonReloadLanguageFiles;
    }
}

