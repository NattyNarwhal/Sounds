namespace Sounds
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.versionLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.licensePage = new System.Windows.Forms.TabPage();
            this.licenseBox = new System.Windows.Forms.TextBox();
            this.authorsTab = new System.Windows.Forms.TabPage();
            this.authorsBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.taglineLabel = new System.Windows.Forms.Label();
            this.websiteLink = new System.Windows.Forms.LinkLabel();
            this.attributionBox = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.licensePage.SuspendLayout();
            this.authorsTab.SuspendLayout();
            this.attributionBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.versionLabel.Name = "versionLabel";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.licensePage);
            this.tabControl.Controls.Add(this.authorsTab);
            this.tabControl.Controls.Add(this.attributionBox);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // licensePage
            // 
            this.licensePage.Controls.Add(this.licenseBox);
            resources.ApplyResources(this.licensePage, "licensePage");
            this.licensePage.Name = "licensePage";
            this.licensePage.UseVisualStyleBackColor = true;
            // 
            // licenseBox
            // 
            resources.ApplyResources(this.licenseBox, "licenseBox");
            this.licenseBox.Name = "licenseBox";
            this.licenseBox.ReadOnly = true;
            // 
            // authorsTab
            // 
            this.authorsTab.Controls.Add(this.authorsBox);
            resources.ApplyResources(this.authorsTab, "authorsTab");
            this.authorsTab.Name = "authorsTab";
            this.authorsTab.UseVisualStyleBackColor = true;
            // 
            // authorsBox
            // 
            resources.ApplyResources(this.authorsBox, "authorsBox");
            this.authorsBox.Name = "authorsBox";
            this.authorsBox.ReadOnly = true;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // taglineLabel
            // 
            this.taglineLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.taglineLabel, "taglineLabel");
            this.taglineLabel.Name = "taglineLabel";
            // 
            // websiteLink
            // 
            resources.ApplyResources(this.websiteLink, "websiteLink");
            this.websiteLink.Name = "websiteLink";
            this.websiteLink.TabStop = true;
            this.websiteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLink_LinkClicked);
            // 
            // attributionBox
            // 
            this.attributionBox.Controls.Add(this.textBox1);
            resources.ApplyResources(this.attributionBox, "attributionBox");
            this.attributionBox.Name = "attributionBox";
            this.attributionBox.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ControlBox = false;
            this.Controls.Add(this.websiteLink);
            this.Controls.Add(this.taglineLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.versionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tabControl.ResumeLayout(false);
            this.licensePage.ResumeLayout(false);
            this.licensePage.PerformLayout();
            this.authorsTab.ResumeLayout(false);
            this.authorsTab.PerformLayout();
            this.attributionBox.ResumeLayout(false);
            this.attributionBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage licensePage;
        private System.Windows.Forms.TabPage authorsTab;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox licenseBox;
        private System.Windows.Forms.Label taglineLabel;
        private System.Windows.Forms.TextBox authorsBox;
        private System.Windows.Forms.LinkLabel websiteLink;
        private System.Windows.Forms.TabPage attributionBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}