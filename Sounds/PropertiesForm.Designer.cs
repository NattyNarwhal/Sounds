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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesForm));
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.intrinisicsTab = new System.Windows.Forms.TabPage();
            this.durationBox = new System.Windows.Forms.TextBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.sampleRateBox = new System.Windows.Forms.TextBox();
            this.sampleRateLabel = new System.Windows.Forms.Label();
            this.channelsBox = new System.Windows.Forms.TextBox();
            this.channelsLabel = new System.Windows.Forms.Label();
            this.bitrateBox = new System.Windows.Forms.TextBox();
            this.bitrateLabel = new System.Windows.Forms.Label();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.metadataTab = new System.Windows.Forms.TabPage();
            this.lyricsBox = new System.Windows.Forms.TextBox();
            this.lyricsLabel = new System.Windows.Forms.Label();
            this.commentsBox = new System.Windows.Forms.TextBox();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.copyrightBox = new System.Windows.Forms.TextBox();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.yearBox = new System.Windows.Forms.TextBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.genresBox = new System.Windows.Forms.ListBox();
            this.genreLabel = new System.Windows.Forms.Label();
            this.composersBox = new System.Windows.Forms.ListBox();
            this.composersLabel = new System.Windows.Forms.Label();
            this.artistsBox = new System.Windows.Forms.ListBox();
            this.artistsLabel = new System.Windows.Forms.Label();
            this.discBox = new System.Windows.Forms.TextBox();
            this.discLabel = new System.Windows.Forms.Label();
            this.trackBox = new System.Windows.Forms.TextBox();
            this.trackLabel = new System.Windows.Forms.Label();
            this.albumBox = new System.Windows.Forms.TextBox();
            this.albumLabel = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.picturesTab = new System.Windows.Forms.TabPage();
            this.copyImageButton = new System.Windows.Forms.Button();
            this.albumArtInfo = new System.Windows.Forms.Label();
            this.albumArtSelector = new System.Windows.Forms.ComboBox();
            this.albumArtBox = new System.Windows.Forms.PictureBox();
            this.fileSelector = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.intrinisicsTab.SuspendLayout();
            this.metadataTab.SuspendLayout();
            this.picturesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.intrinisicsTab);
            this.tabControl1.Controls.Add(this.metadataTab);
            this.tabControl1.Controls.Add(this.picturesTab);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
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
            resources.ApplyResources(this.intrinisicsTab, "intrinisicsTab");
            this.intrinisicsTab.Name = "intrinisicsTab";
            this.intrinisicsTab.UseVisualStyleBackColor = true;
            // 
            // durationBox
            // 
            resources.ApplyResources(this.durationBox, "durationBox");
            this.durationBox.Name = "durationBox";
            this.durationBox.ReadOnly = true;
            // 
            // durationLabel
            // 
            resources.ApplyResources(this.durationLabel, "durationLabel");
            this.durationLabel.Name = "durationLabel";
            // 
            // sampleRateBox
            // 
            resources.ApplyResources(this.sampleRateBox, "sampleRateBox");
            this.sampleRateBox.Name = "sampleRateBox";
            this.sampleRateBox.ReadOnly = true;
            // 
            // sampleRateLabel
            // 
            resources.ApplyResources(this.sampleRateLabel, "sampleRateLabel");
            this.sampleRateLabel.Name = "sampleRateLabel";
            // 
            // channelsBox
            // 
            resources.ApplyResources(this.channelsBox, "channelsBox");
            this.channelsBox.Name = "channelsBox";
            this.channelsBox.ReadOnly = true;
            // 
            // channelsLabel
            // 
            resources.ApplyResources(this.channelsLabel, "channelsLabel");
            this.channelsLabel.Name = "channelsLabel";
            // 
            // bitrateBox
            // 
            resources.ApplyResources(this.bitrateBox, "bitrateBox");
            this.bitrateBox.Name = "bitrateBox";
            this.bitrateBox.ReadOnly = true;
            // 
            // bitrateLabel
            // 
            resources.ApplyResources(this.bitrateLabel, "bitrateLabel");
            this.bitrateLabel.Name = "bitrateLabel";
            // 
            // fileNameBox
            // 
            resources.ApplyResources(this.fileNameBox, "fileNameBox");
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.ReadOnly = true;
            // 
            // fileNameLabel
            // 
            resources.ApplyResources(this.fileNameLabel, "fileNameLabel");
            this.fileNameLabel.Name = "fileNameLabel";
            // 
            // metadataTab
            // 
            this.metadataTab.Controls.Add(this.lyricsBox);
            this.metadataTab.Controls.Add(this.lyricsLabel);
            this.metadataTab.Controls.Add(this.commentsBox);
            this.metadataTab.Controls.Add(this.commentsLabel);
            this.metadataTab.Controls.Add(this.copyrightBox);
            this.metadataTab.Controls.Add(this.copyrightLabel);
            this.metadataTab.Controls.Add(this.yearBox);
            this.metadataTab.Controls.Add(this.yearLabel);
            this.metadataTab.Controls.Add(this.genresBox);
            this.metadataTab.Controls.Add(this.genreLabel);
            this.metadataTab.Controls.Add(this.composersBox);
            this.metadataTab.Controls.Add(this.composersLabel);
            this.metadataTab.Controls.Add(this.artistsBox);
            this.metadataTab.Controls.Add(this.artistsLabel);
            this.metadataTab.Controls.Add(this.discBox);
            this.metadataTab.Controls.Add(this.discLabel);
            this.metadataTab.Controls.Add(this.trackBox);
            this.metadataTab.Controls.Add(this.trackLabel);
            this.metadataTab.Controls.Add(this.albumBox);
            this.metadataTab.Controls.Add(this.albumLabel);
            this.metadataTab.Controls.Add(this.titleBox);
            this.metadataTab.Controls.Add(this.titleLabel);
            resources.ApplyResources(this.metadataTab, "metadataTab");
            this.metadataTab.Name = "metadataTab";
            this.metadataTab.UseVisualStyleBackColor = true;
            // 
            // lyricsBox
            // 
            resources.ApplyResources(this.lyricsBox, "lyricsBox");
            this.lyricsBox.Name = "lyricsBox";
            this.lyricsBox.ReadOnly = true;
            // 
            // lyricsLabel
            // 
            resources.ApplyResources(this.lyricsLabel, "lyricsLabel");
            this.lyricsLabel.Name = "lyricsLabel";
            // 
            // commentsBox
            // 
            resources.ApplyResources(this.commentsBox, "commentsBox");
            this.commentsBox.Name = "commentsBox";
            this.commentsBox.ReadOnly = true;
            // 
            // commentsLabel
            // 
            resources.ApplyResources(this.commentsLabel, "commentsLabel");
            this.commentsLabel.Name = "commentsLabel";
            // 
            // copyrightBox
            // 
            resources.ApplyResources(this.copyrightBox, "copyrightBox");
            this.copyrightBox.Name = "copyrightBox";
            this.copyrightBox.ReadOnly = true;
            // 
            // copyrightLabel
            // 
            resources.ApplyResources(this.copyrightLabel, "copyrightLabel");
            this.copyrightLabel.Name = "copyrightLabel";
            // 
            // yearBox
            // 
            resources.ApplyResources(this.yearBox, "yearBox");
            this.yearBox.Name = "yearBox";
            this.yearBox.ReadOnly = true;
            // 
            // yearLabel
            // 
            resources.ApplyResources(this.yearLabel, "yearLabel");
            this.yearLabel.Name = "yearLabel";
            // 
            // genresBox
            // 
            resources.ApplyResources(this.genresBox, "genresBox");
            this.genresBox.FormattingEnabled = true;
            this.genresBox.Name = "genresBox";
            this.genresBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // genreLabel
            // 
            resources.ApplyResources(this.genreLabel, "genreLabel");
            this.genreLabel.Name = "genreLabel";
            // 
            // composersBox
            // 
            resources.ApplyResources(this.composersBox, "composersBox");
            this.composersBox.FormattingEnabled = true;
            this.composersBox.Name = "composersBox";
            this.composersBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // composersLabel
            // 
            resources.ApplyResources(this.composersLabel, "composersLabel");
            this.composersLabel.Name = "composersLabel";
            // 
            // artistsBox
            // 
            resources.ApplyResources(this.artistsBox, "artistsBox");
            this.artistsBox.FormattingEnabled = true;
            this.artistsBox.Name = "artistsBox";
            this.artistsBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // artistsLabel
            // 
            resources.ApplyResources(this.artistsLabel, "artistsLabel");
            this.artistsLabel.Name = "artistsLabel";
            // 
            // discBox
            // 
            resources.ApplyResources(this.discBox, "discBox");
            this.discBox.Name = "discBox";
            this.discBox.ReadOnly = true;
            // 
            // discLabel
            // 
            resources.ApplyResources(this.discLabel, "discLabel");
            this.discLabel.Name = "discLabel";
            // 
            // trackBox
            // 
            resources.ApplyResources(this.trackBox, "trackBox");
            this.trackBox.Name = "trackBox";
            this.trackBox.ReadOnly = true;
            // 
            // trackLabel
            // 
            resources.ApplyResources(this.trackLabel, "trackLabel");
            this.trackLabel.Name = "trackLabel";
            // 
            // albumBox
            // 
            resources.ApplyResources(this.albumBox, "albumBox");
            this.albumBox.Name = "albumBox";
            this.albumBox.ReadOnly = true;
            // 
            // albumLabel
            // 
            resources.ApplyResources(this.albumLabel, "albumLabel");
            this.albumLabel.Name = "albumLabel";
            // 
            // titleBox
            // 
            resources.ApplyResources(this.titleBox, "titleBox");
            this.titleBox.Name = "titleBox";
            this.titleBox.ReadOnly = true;
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // picturesTab
            // 
            this.picturesTab.Controls.Add(this.copyImageButton);
            this.picturesTab.Controls.Add(this.albumArtInfo);
            this.picturesTab.Controls.Add(this.albumArtSelector);
            this.picturesTab.Controls.Add(this.albumArtBox);
            resources.ApplyResources(this.picturesTab, "picturesTab");
            this.picturesTab.Name = "picturesTab";
            this.picturesTab.UseVisualStyleBackColor = true;
            // 
            // copyImageButton
            // 
            resources.ApplyResources(this.copyImageButton, "copyImageButton");
            this.copyImageButton.Name = "copyImageButton";
            this.copyImageButton.UseVisualStyleBackColor = true;
            this.copyImageButton.Click += new System.EventHandler(this.copyImageButton_Click);
            // 
            // albumArtInfo
            // 
            resources.ApplyResources(this.albumArtInfo, "albumArtInfo");
            this.albumArtInfo.Name = "albumArtInfo";
            // 
            // albumArtSelector
            // 
            resources.ApplyResources(this.albumArtSelector, "albumArtSelector");
            this.albumArtSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.albumArtSelector.FormattingEnabled = true;
            this.albumArtSelector.Name = "albumArtSelector";
            this.albumArtSelector.SelectedIndexChanged += new System.EventHandler(this.albumArtSelector_SelectedIndexChanged);
            // 
            // albumArtBox
            // 
            resources.ApplyResources(this.albumArtBox, "albumArtBox");
            this.albumArtBox.Name = "albumArtBox";
            this.albumArtBox.TabStop = false;
            // 
            // fileSelector
            // 
            resources.ApplyResources(this.fileSelector, "fileSelector");
            this.fileSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileSelector.FormattingEnabled = true;
            this.fileSelector.Name = "fileSelector";
            this.fileSelector.SelectedIndexChanged += new System.EventHandler(this.fileSelector_SelectedIndexChanged);
            // 
            // PropertiesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.Controls.Add(this.fileSelector);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.okButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tabControl1.ResumeLayout(false);
            this.intrinisicsTab.ResumeLayout(false);
            this.intrinisicsTab.PerformLayout();
            this.metadataTab.ResumeLayout(false);
            this.metadataTab.PerformLayout();
            this.picturesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage intrinisicsTab;
        private System.Windows.Forms.TabPage metadataTab;
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
        private System.Windows.Forms.TextBox discBox;
        private System.Windows.Forms.Label discLabel;
        private System.Windows.Forms.TextBox trackBox;
        private System.Windows.Forms.Label trackLabel;
        private System.Windows.Forms.TextBox albumBox;
        private System.Windows.Forms.Label albumLabel;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListBox artistsBox;
        private System.Windows.Forms.Label artistsLabel;
        private System.Windows.Forms.ListBox genresBox;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.ListBox composersBox;
        private System.Windows.Forms.Label composersLabel;
        private System.Windows.Forms.TabPage picturesTab;
        private System.Windows.Forms.PictureBox albumArtBox;
        private System.Windows.Forms.ComboBox albumArtSelector;
        private System.Windows.Forms.Label albumArtInfo;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.ComboBox fileSelector;
        private System.Windows.Forms.TextBox lyricsBox;
        private System.Windows.Forms.Label lyricsLabel;
        private System.Windows.Forms.TextBox commentsBox;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.TextBox copyrightBox;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Button copyImageButton;
    }
}