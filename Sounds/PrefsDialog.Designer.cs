namespace Sounds
{
    partial class PrefsDialog
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
            this.displayGroup = new System.Windows.Forms.GroupBox();
            this.generalBox = new System.Windows.Forms.GroupBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.showToolbarBox = new System.Windows.Forms.CheckBox();
            this.showStatusbarBox = new System.Windows.Forms.CheckBox();
            this.showInfoPaneBox = new System.Windows.Forms.CheckBox();
            this.deleteOnTrackChangeBox = new System.Windows.Forms.CheckBox();
            this.recursiveBox = new System.Windows.Forms.CheckBox();
            this.volIncrementLabel = new System.Windows.Forms.Label();
            this.volIncrementBox = new System.Windows.Forms.NumericUpDown();
            this.timeIncrementBox = new System.Windows.Forms.NumericUpDown();
            this.timeIncrementLabel = new System.Windows.Forms.Label();
            this.displayGroup.SuspendLayout();
            this.generalBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volIncrementBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeIncrementBox)).BeginInit();
            this.SuspendLayout();
            // 
            // displayGroup
            // 
            this.displayGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayGroup.Controls.Add(this.showInfoPaneBox);
            this.displayGroup.Controls.Add(this.showStatusbarBox);
            this.displayGroup.Controls.Add(this.showToolbarBox);
            this.displayGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.displayGroup.Location = new System.Drawing.Point(12, 12);
            this.displayGroup.Name = "displayGroup";
            this.displayGroup.Size = new System.Drawing.Size(260, 88);
            this.displayGroup.TabIndex = 0;
            this.displayGroup.TabStop = false;
            this.displayGroup.Text = "Display";
            // 
            // generalBox
            // 
            this.generalBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generalBox.Controls.Add(this.timeIncrementBox);
            this.generalBox.Controls.Add(this.timeIncrementLabel);
            this.generalBox.Controls.Add(this.volIncrementBox);
            this.generalBox.Controls.Add(this.volIncrementLabel);
            this.generalBox.Controls.Add(this.recursiveBox);
            this.generalBox.Controls.Add(this.deleteOnTrackChangeBox);
            this.generalBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.generalBox.Location = new System.Drawing.Point(12, 106);
            this.generalBox.Name = "generalBox";
            this.generalBox.Size = new System.Drawing.Size(260, 121);
            this.generalBox.TabIndex = 1;
            this.generalBox.TabStop = false;
            this.generalBox.Text = "General";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(116, 233);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "O&K";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(197, 233);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // showToolbarBox
            // 
            this.showToolbarBox.AutoSize = true;
            this.showToolbarBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.showToolbarBox.Location = new System.Drawing.Point(6, 19);
            this.showToolbarBox.Name = "showToolbarBox";
            this.showToolbarBox.Size = new System.Drawing.Size(98, 18);
            this.showToolbarBox.TabIndex = 0;
            this.showToolbarBox.Text = "Show Toolbar";
            this.showToolbarBox.UseVisualStyleBackColor = true;
            // 
            // showStatusbarBox
            // 
            this.showStatusbarBox.AutoSize = true;
            this.showStatusbarBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.showStatusbarBox.Location = new System.Drawing.Point(6, 42);
            this.showStatusbarBox.Name = "showStatusbarBox";
            this.showStatusbarBox.Size = new System.Drawing.Size(107, 18);
            this.showStatusbarBox.TabIndex = 1;
            this.showStatusbarBox.Text = "Show Statusbar";
            this.showStatusbarBox.UseVisualStyleBackColor = true;
            // 
            // showInfoPaneBox
            // 
            this.showInfoPaneBox.AutoSize = true;
            this.showInfoPaneBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.showInfoPaneBox.Location = new System.Drawing.Point(6, 65);
            this.showInfoPaneBox.Name = "showInfoPaneBox";
            this.showInfoPaneBox.Size = new System.Drawing.Size(108, 18);
            this.showInfoPaneBox.TabIndex = 2;
            this.showInfoPaneBox.Text = "Show Info Pane";
            this.showInfoPaneBox.UseVisualStyleBackColor = true;
            // 
            // deleteOnTrackChangeBox
            // 
            this.deleteOnTrackChangeBox.AutoSize = true;
            this.deleteOnTrackChangeBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.deleteOnTrackChangeBox.Location = new System.Drawing.Point(6, 19);
            this.deleteOnTrackChangeBox.Name = "deleteOnTrackChangeBox";
            this.deleteOnTrackChangeBox.Size = new System.Drawing.Size(200, 18);
            this.deleteOnTrackChangeBox.TabIndex = 0;
            this.deleteOnTrackChangeBox.Text = "Remove track when playback ends";
            this.deleteOnTrackChangeBox.UseVisualStyleBackColor = true;
            // 
            // recursiveBox
            // 
            this.recursiveBox.AutoSize = true;
            this.recursiveBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recursiveBox.Location = new System.Drawing.Point(6, 43);
            this.recursiveBox.Name = "recursiveBox";
            this.recursiveBox.Size = new System.Drawing.Size(195, 18);
            this.recursiveBox.TabIndex = 1;
            this.recursiveBox.Text = "Recursively add music from folders";
            this.recursiveBox.UseVisualStyleBackColor = true;
            // 
            // volIncrementLabel
            // 
            this.volIncrementLabel.AutoSize = true;
            this.volIncrementLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.volIncrementLabel.Location = new System.Drawing.Point(6, 69);
            this.volIncrementLabel.Name = "volIncrementLabel";
            this.volIncrementLabel.Size = new System.Drawing.Size(92, 13);
            this.volIncrementLabel.TabIndex = 2;
            this.volIncrementLabel.Text = "Volume Increment";
            // 
            // volIncrementBox
            // 
            this.volIncrementBox.Location = new System.Drawing.Point(101, 67);
            this.volIncrementBox.Name = "volIncrementBox";
            this.volIncrementBox.Size = new System.Drawing.Size(153, 20);
            this.volIncrementBox.TabIndex = 3;
            // 
            // timeIncrementBox
            // 
            this.timeIncrementBox.Location = new System.Drawing.Point(101, 93);
            this.timeIncrementBox.Name = "timeIncrementBox";
            this.timeIncrementBox.Size = new System.Drawing.Size(153, 20);
            this.timeIncrementBox.TabIndex = 5;
            // 
            // timeIncrementLabel
            // 
            this.timeIncrementLabel.AutoSize = true;
            this.timeIncrementLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timeIncrementLabel.Location = new System.Drawing.Point(6, 95);
            this.timeIncrementLabel.Name = "timeIncrementLabel";
            this.timeIncrementLabel.Size = new System.Drawing.Size(80, 13);
            this.timeIncrementLabel.TabIndex = 4;
            this.timeIncrementLabel.Text = "Time Increment";
            // 
            // PrefsDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(284, 268);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.generalBox);
            this.Controls.Add(this.displayGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrefsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Preferences";
            this.displayGroup.ResumeLayout(false);
            this.displayGroup.PerformLayout();
            this.generalBox.ResumeLayout(false);
            this.generalBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volIncrementBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeIncrementBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox displayGroup;
        private System.Windows.Forms.GroupBox generalBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox showInfoPaneBox;
        private System.Windows.Forms.CheckBox showStatusbarBox;
        private System.Windows.Forms.CheckBox showToolbarBox;
        private System.Windows.Forms.NumericUpDown timeIncrementBox;
        private System.Windows.Forms.Label timeIncrementLabel;
        private System.Windows.Forms.NumericUpDown volIncrementBox;
        private System.Windows.Forms.Label volIncrementLabel;
        private System.Windows.Forms.CheckBox recursiveBox;
        private System.Windows.Forms.CheckBox deleteOnTrackChangeBox;
    }
}