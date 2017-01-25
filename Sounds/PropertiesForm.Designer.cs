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
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.albumArtInfo = new System.Windows.Forms.Label();
            this.albumArtSelector = new System.Windows.Forms.ComboBox();
            this.albumArtBox = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.intrinisicsTab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(197, 324);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "O&K";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.intrinisicsTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 306);
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
            this.intrinisicsTab.Size = new System.Drawing.Size(252, 280);
            this.intrinisicsTab.TabIndex = 0;
            this.intrinisicsTab.Text = "Intrinisics";
            this.intrinisicsTab.UseVisualStyleBackColor = true;
            // 
            // durationBox
            // 
            this.durationBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.sampleRateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // channelsBox
            // 
            this.channelsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // bitrateBox
            // 
            this.bitrateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // fileNameBox
            // 
            this.fileNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameBox.Location = new System.Drawing.Point(80, 6);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.ReadOnly = true;
            this.fileNameBox.Size = new System.Drawing.Size(166, 20);
            this.fileNameBox.TabIndex = 1;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.yearBox);
            this.tabPage2.Controls.Add(this.yearLabel);
            this.tabPage2.Controls.Add(this.genresBox);
            this.tabPage2.Controls.Add(this.genreLabel);
            this.tabPage2.Controls.Add(this.composersBox);
            this.tabPage2.Controls.Add(this.composersLabel);
            this.tabPage2.Controls.Add(this.artistsBox);
            this.tabPage2.Controls.Add(this.artistsLabel);
            this.tabPage2.Controls.Add(this.discBox);
            this.tabPage2.Controls.Add(this.discLabel);
            this.tabPage2.Controls.Add(this.trackBox);
            this.tabPage2.Controls.Add(this.trackLabel);
            this.tabPage2.Controls.Add(this.albumBox);
            this.tabPage2.Controls.Add(this.albumLabel);
            this.tabPage2.Controls.Add(this.titleBox);
            this.tabPage2.Controls.Add(this.titleLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(252, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Metadata";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // yearBox
            // 
            this.yearBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yearBox.Location = new System.Drawing.Point(80, 257);
            this.yearBox.Name = "yearBox";
            this.yearBox.ReadOnly = true;
            this.yearBox.Size = new System.Drawing.Size(166, 20);
            this.yearBox.TabIndex = 21;
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(6, 260);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(29, 13);
            this.yearLabel.TabIndex = 20;
            this.yearLabel.Text = "&Year";
            // 
            // genresBox
            // 
            this.genresBox.FormattingEnabled = true;
            this.genresBox.HorizontalScrollbar = true;
            this.genresBox.Location = new System.Drawing.Point(80, 208);
            this.genresBox.Name = "genresBox";
            this.genresBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.genresBox.Size = new System.Drawing.Size(166, 43);
            this.genresBox.TabIndex = 19;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(6, 211);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(41, 13);
            this.genreLabel.TabIndex = 18;
            this.genreLabel.Text = "&Genres";
            // 
            // composersBox
            // 
            this.composersBox.FormattingEnabled = true;
            this.composersBox.HorizontalScrollbar = true;
            this.composersBox.Location = new System.Drawing.Point(80, 159);
            this.composersBox.Name = "composersBox";
            this.composersBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.composersBox.Size = new System.Drawing.Size(166, 43);
            this.composersBox.TabIndex = 17;
            // 
            // composersLabel
            // 
            this.composersLabel.AutoSize = true;
            this.composersLabel.Location = new System.Drawing.Point(6, 162);
            this.composersLabel.Name = "composersLabel";
            this.composersLabel.Size = new System.Drawing.Size(59, 13);
            this.composersLabel.TabIndex = 16;
            this.composersLabel.Text = "&Composers";
            // 
            // artistsBox
            // 
            this.artistsBox.FormattingEnabled = true;
            this.artistsBox.HorizontalScrollbar = true;
            this.artistsBox.Location = new System.Drawing.Point(80, 110);
            this.artistsBox.Name = "artistsBox";
            this.artistsBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.artistsBox.Size = new System.Drawing.Size(166, 43);
            this.artistsBox.TabIndex = 15;
            // 
            // artistsLabel
            // 
            this.artistsLabel.AutoSize = true;
            this.artistsLabel.Location = new System.Drawing.Point(6, 113);
            this.artistsLabel.Name = "artistsLabel";
            this.artistsLabel.Size = new System.Drawing.Size(35, 13);
            this.artistsLabel.TabIndex = 14;
            this.artistsLabel.Text = "A&rtists";
            // 
            // discBox
            // 
            this.discBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discBox.Location = new System.Drawing.Point(80, 84);
            this.discBox.Name = "discBox";
            this.discBox.ReadOnly = true;
            this.discBox.Size = new System.Drawing.Size(166, 20);
            this.discBox.TabIndex = 13;
            // 
            // discLabel
            // 
            this.discLabel.AutoSize = true;
            this.discLabel.Location = new System.Drawing.Point(6, 87);
            this.discLabel.Name = "discLabel";
            this.discLabel.Size = new System.Drawing.Size(28, 13);
            this.discLabel.TabIndex = 12;
            this.discLabel.Text = "&Disc";
            // 
            // trackBox
            // 
            this.trackBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBox.Location = new System.Drawing.Point(80, 58);
            this.trackBox.Name = "trackBox";
            this.trackBox.ReadOnly = true;
            this.trackBox.Size = new System.Drawing.Size(166, 20);
            this.trackBox.TabIndex = 11;
            // 
            // trackLabel
            // 
            this.trackLabel.AutoSize = true;
            this.trackLabel.Location = new System.Drawing.Point(6, 61);
            this.trackLabel.Name = "trackLabel";
            this.trackLabel.Size = new System.Drawing.Size(35, 13);
            this.trackLabel.TabIndex = 10;
            this.trackLabel.Text = "Trac&k";
            // 
            // albumBox
            // 
            this.albumBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.albumBox.Location = new System.Drawing.Point(80, 32);
            this.albumBox.Name = "albumBox";
            this.albumBox.ReadOnly = true;
            this.albumBox.Size = new System.Drawing.Size(166, 20);
            this.albumBox.TabIndex = 9;
            // 
            // albumLabel
            // 
            this.albumLabel.AutoSize = true;
            this.albumLabel.Location = new System.Drawing.Point(6, 35);
            this.albumLabel.Name = "albumLabel";
            this.albumLabel.Size = new System.Drawing.Size(36, 13);
            this.albumLabel.TabIndex = 8;
            this.albumLabel.Text = "&Album";
            // 
            // titleBox
            // 
            this.titleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleBox.Location = new System.Drawing.Point(80, 6);
            this.titleBox.Name = "titleBox";
            this.titleBox.ReadOnly = true;
            this.titleBox.Size = new System.Drawing.Size(166, 20);
            this.titleBox.TabIndex = 7;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(6, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "&Title";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.albumArtInfo);
            this.tabPage1.Controls.Add(this.albumArtSelector);
            this.tabPage1.Controls.Add(this.albumArtBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(252, 280);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Pictures";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // albumArtInfo
            // 
            this.albumArtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.albumArtInfo.Location = new System.Drawing.Point(6, 256);
            this.albumArtInfo.Name = "albumArtInfo";
            this.albumArtInfo.Size = new System.Drawing.Size(240, 21);
            this.albumArtInfo.TabIndex = 2;
            // 
            // albumArtSelector
            // 
            this.albumArtSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.albumArtSelector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.albumArtSelector.FormattingEnabled = true;
            this.albumArtSelector.Location = new System.Drawing.Point(6, 6);
            this.albumArtSelector.Name = "albumArtSelector";
            this.albumArtSelector.Size = new System.Drawing.Size(240, 21);
            this.albumArtSelector.TabIndex = 0;
            this.albumArtSelector.SelectedIndexChanged += new System.EventHandler(this.albumArtSelector_SelectedIndexChanged);
            // 
            // albumArtBox
            // 
            this.albumArtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.albumArtBox.Location = new System.Drawing.Point(6, 33);
            this.albumArtBox.Name = "albumArtBox";
            this.albumArtBox.Size = new System.Drawing.Size(240, 220);
            this.albumArtBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.albumArtBox.TabIndex = 1;
            this.albumArtBox.TabStop = false;
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(284, 359);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Properties";
            this.tabControl1.ResumeLayout(false);
            this.intrinisicsTab.ResumeLayout(false);
            this.intrinisicsTab.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox albumArtBox;
        private System.Windows.Forms.ComboBox albumArtSelector;
        private System.Windows.Forms.Label albumArtInfo;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.Label yearLabel;
    }
}