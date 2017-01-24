namespace Sounds
{
    partial class PropertiesForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.intrinisicsTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.bitrateBox = new System.Windows.Forms.TextBox();
            this.bitrateLabel = new System.Windows.Forms.Label();
            this.channelsBox = new System.Windows.Forms.TextBox();
            this.channelsLabel = new System.Windows.Forms.Label();
            this.durationBox = new System.Windows.Forms.TextBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.sampleRateBox = new System.Windows.Forms.TextBox();
            this.sampleRateLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.intrinisicsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(197, 226);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "O&K";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.intrinisicsTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 208);
            this.tabControl1.TabIndex = 1;
            // 
            // intrinisicsTab
            // 
            this.intrinisicsTab.Controls.Add(this.durationBox);
            this.intrinisicsTab.Controls.Add(this.durationLabel);
            this.intrinisicsTab.Controls.Add(this.sampleRateBox);
            this.intrinisicsTab.Controls.Add(this.sampleRateLabel);
            this.intrinisicsTab.Controls.Add(this.channelsBox);
            this.intrinisicsTab.Controls.Add(this.channelsLabel);
            this.intrinisicsTab.Controls.Add(this.bitrateBox);
            this.intrinisicsTab.Controls.Add(this.bitrateLabel);
            this.intrinisicsTab.Controls.Add(this.fileNameBox);
            this.intrinisicsTab.Controls.Add(this.fileNameLabel);
            this.intrinisicsTab.Location = new System.Drawing.Point(4, 22);
            this.intrinisicsTab.Name = "intrinisicsTab";
            this.intrinisicsTab.Padding = new System.Windows.Forms.Padding(3);
            this.intrinisicsTab.Size = new System.Drawing.Size(252, 182);
            this.intrinisicsTab.TabIndex = 0;
            this.intrinisicsTab.Text = "Intrinisics";
            this.intrinisicsTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(252, 182);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Metadata";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(6, 9);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(54, 13);
            this.fileNameLabel.TabIndex = 0;
            this.fileNameLabel.Text = "File &Name";
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(80, 6);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.ReadOnly = true;
            this.fileNameBox.Size = new System.Drawing.Size(166, 20);
            this.fileNameBox.TabIndex = 1;
            // 
            // bitrateBox
            // 
            this.bitrateBox.Location = new System.Drawing.Point(80, 32);
            this.bitrateBox.Name = "bitrateBox";
            this.bitrateBox.ReadOnly = true;
            this.bitrateBox.Size = new System.Drawing.Size(166, 20);
            this.bitrateBox.TabIndex = 3;
            // 
            // bitrateLabel
            // 
            this.bitrateLabel.AutoSize = true;
            this.bitrateLabel.Location = new System.Drawing.Point(6, 35);
            this.bitrateLabel.Name = "bitrateLabel";
            this.bitrateLabel.Size = new System.Drawing.Size(37, 13);
            this.bitrateLabel.TabIndex = 2;
            this.bitrateLabel.Text = "&Bitrate";
            // 
            // channelsBox
            // 
            this.channelsBox.Location = new System.Drawing.Point(80, 58);
            this.channelsBox.Name = "channelsBox";
            this.channelsBox.ReadOnly = true;
            this.channelsBox.Size = new System.Drawing.Size(166, 20);
            this.channelsBox.TabIndex = 5;
            // 
            // channelsLabel
            // 
            this.channelsLabel.AutoSize = true;
            this.channelsLabel.Location = new System.Drawing.Point(6, 61);
            this.channelsLabel.Name = "channelsLabel";
            this.channelsLabel.Size = new System.Drawing.Size(51, 13);
            this.channelsLabel.TabIndex = 4;
            this.channelsLabel.Text = "&Channels";
            // 
            // durationBox
            // 
            this.durationBox.Location = new System.Drawing.Point(80, 110);
            this.durationBox.Name = "durationBox";
            this.durationBox.ReadOnly = true;
            this.durationBox.Size = new System.Drawing.Size(166, 20);
            this.durationBox.TabIndex = 9;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(6, 113);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(47, 13);
            this.durationLabel.TabIndex = 8;
            this.durationLabel.Text = "&Duration";
            // 
            // sampleRateBox
            // 
            this.sampleRateBox.Location = new System.Drawing.Point(80, 84);
            this.sampleRateBox.Name = "sampleRateBox";
            this.sampleRateBox.ReadOnly = true;
            this.sampleRateBox.Size = new System.Drawing.Size(166, 20);
            this.sampleRateBox.TabIndex = 7;
            // 
            // sampleRateLabel
            // 
            this.sampleRateLabel.AutoSize = true;
            this.sampleRateLabel.Location = new System.Drawing.Point(6, 87);
            this.sampleRateLabel.Name = "sampleRateLabel";
            this.sampleRateLabel.Size = new System.Drawing.Size(68, 13);
            this.sampleRateLabel.TabIndex = 6;
            this.sampleRateLabel.Text = "&Sample Rate";
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Properties";
            this.tabControl1.ResumeLayout(false);
            this.intrinisicsTab.ResumeLayout(false);
            this.intrinisicsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage intrinisicsTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox channelsBox;
        private System.Windows.Forms.Label channelsLabel;
        private System.Windows.Forms.TextBox bitrateBox;
        private System.Windows.Forms.Label bitrateLabel;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.TextBox durationBox;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.TextBox sampleRateBox;
        private System.Windows.Forms.Label sampleRateLabel;
    }
}