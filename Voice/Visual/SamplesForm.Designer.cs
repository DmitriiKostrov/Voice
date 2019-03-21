namespace Voice.Visual
{
    partial class SamplesForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.AddSoundButton = new System.Windows.Forms.Button();
            this.ButtonRename = new System.Windows.Forms.Button();
            this.ButtonChange = new System.Windows.Forms.Button();
            this.ButtonRecord = new System.Windows.Forms.Button();
            this.ButtonPlay = new System.Windows.Forms.Button();
            this.DeleteProfile = new System.Windows.Forms.Button();
            this.AddProfile = new System.Windows.Forms.Button();
            this.ProfileComboBox = new System.Windows.Forms.ComboBox();
            this.CharBox = new System.Windows.Forms.ListBox();
            this.CharListView = new System.Windows.Forms.ListView();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CharsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.CharsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.CharsStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ButtonRemove);
            this.splitContainer1.Panel1.Controls.Add(this.AddSoundButton);
            this.splitContainer1.Panel1.Controls.Add(this.ButtonRename);
            this.splitContainer1.Panel1.Controls.Add(this.ButtonChange);
            this.splitContainer1.Panel1.Controls.Add(this.ButtonRecord);
            this.splitContainer1.Panel1.Controls.Add(this.ButtonPlay);
            this.splitContainer1.Panel1.Controls.Add(this.DeleteProfile);
            this.splitContainer1.Panel1.Controls.Add(this.AddProfile);
            this.splitContainer1.Panel1.Controls.Add(this.ProfileComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.CharBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CharListView);
            this.splitContainer1.Size = new System.Drawing.Size(234, 533);
            this.splitContainer1.SplitterDistance = 109;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonRemove.Enabled = false;
            this.ButtonRemove.Location = new System.Drawing.Point(8, 448);
            this.ButtonRemove.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(92, 23);
            this.ButtonRemove.TabIndex = 1;
            this.ButtonRemove.Text = "Удалить";
            this.ButtonRemove.UseVisualStyleBackColor = false;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // AddSoundButton
            // 
            this.AddSoundButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AddSoundButton.Enabled = false;
            this.AddSoundButton.Location = new System.Drawing.Point(8, 473);
            this.AddSoundButton.Margin = new System.Windows.Forms.Padding(1);
            this.AddSoundButton.Name = "AddSoundButton";
            this.AddSoundButton.Size = new System.Drawing.Size(92, 23);
            this.AddSoundButton.TabIndex = 11;
            this.AddSoundButton.Text = "Добавить";
            this.AddSoundButton.UseVisualStyleBackColor = false;
            this.AddSoundButton.Click += new System.EventHandler(this.AddSoundButton_Click);
            // 
            // ButtonRename
            // 
            this.ButtonRename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonRename.Enabled = false;
            this.ButtonRename.Location = new System.Drawing.Point(8, 498);
            this.ButtonRename.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonRename.Name = "ButtonRename";
            this.ButtonRename.Size = new System.Drawing.Size(92, 23);
            this.ButtonRename.TabIndex = 12;
            this.ButtonRename.Text = "Назвать";
            this.ButtonRename.UseVisualStyleBackColor = false;
            this.ButtonRename.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // ButtonChange
            // 
            this.ButtonChange.AutoEllipsis = true;
            this.ButtonChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonChange.Enabled = false;
            this.ButtonChange.Location = new System.Drawing.Point(8, 390);
            this.ButtonChange.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonChange.Name = "ButtonChange";
            this.ButtonChange.Size = new System.Drawing.Size(92, 23);
            this.ButtonChange.TabIndex = 10;
            this.ButtonChange.Text = "Изменить";
            this.ButtonChange.UseVisualStyleBackColor = false;
            this.ButtonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // ButtonRecord
            // 
            this.ButtonRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonRecord.Enabled = false;
            this.ButtonRecord.Location = new System.Drawing.Point(8, 365);
            this.ButtonRecord.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonRecord.Name = "ButtonRecord";
            this.ButtonRecord.Size = new System.Drawing.Size(92, 23);
            this.ButtonRecord.TabIndex = 5;
            this.ButtonRecord.Text = "Запись";
            this.ButtonRecord.UseVisualStyleBackColor = false;
            this.ButtonRecord.Click += new System.EventHandler(this.ButtonRecord_Click);
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonPlay.Enabled = false;
            this.ButtonPlay.Location = new System.Drawing.Point(8, 340);
            this.ButtonPlay.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(92, 23);
            this.ButtonPlay.TabIndex = 0;
            this.ButtonPlay.Text = "Играть";
            this.ButtonPlay.UseVisualStyleBackColor = false;
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // DeleteProfile
            // 
            this.DeleteProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DeleteProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteProfile.Image = global::Zвук.Properties.Resources.minus_gray;
            this.DeleteProfile.Location = new System.Drawing.Point(57, 12);
            this.DeleteProfile.Name = "DeleteProfile";
            this.DeleteProfile.Size = new System.Drawing.Size(43, 31);
            this.DeleteProfile.TabIndex = 8;
            this.DeleteProfile.Text = "-";
            this.DeleteProfile.UseVisualStyleBackColor = false;
            this.DeleteProfile.Click += new System.EventHandler(this.DeleteProfile_Click);
            // 
            // AddProfile
            // 
            this.AddProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AddProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddProfile.Image = global::Zвук.Properties.Resources.plus_gray;
            this.AddProfile.Location = new System.Drawing.Point(8, 12);
            this.AddProfile.Name = "AddProfile";
            this.AddProfile.Size = new System.Drawing.Size(43, 31);
            this.AddProfile.TabIndex = 6;
            this.AddProfile.Text = "+";
            this.AddProfile.UseVisualStyleBackColor = false;
            this.AddProfile.Click += new System.EventHandler(this.AddProfile_Click);
            // 
            // ProfileComboBox
            // 
            this.ProfileComboBox.BackColor = System.Drawing.Color.White;
            this.ProfileComboBox.FormattingEnabled = true;
            this.ProfileComboBox.Location = new System.Drawing.Point(8, 49);
            this.ProfileComboBox.Name = "ProfileComboBox";
            this.ProfileComboBox.Size = new System.Drawing.Size(92, 21);
            this.ProfileComboBox.TabIndex = 4;
            this.ProfileComboBox.Text = "Профиль";
            this.ProfileComboBox.SelectedIndexChanged += new System.EventHandler(this.ProfileComboBox_SelectedIndexChanged);
            // 
            // CharBox
            // 
            this.CharBox.BackColor = System.Drawing.Color.White;
            this.CharBox.Enabled = false;
            this.CharBox.FormattingEnabled = true;
            this.CharBox.Location = new System.Drawing.Point(8, 76);
            this.CharBox.Name = "CharBox";
            this.CharBox.Size = new System.Drawing.Size(92, 251);
            this.CharBox.TabIndex = 2;
            this.CharBox.SelectedIndexChanged += new System.EventHandler(this.CharBox_SelectedIndexChanged);
            // 
            // CharListView
            // 
            this.CharListView.BackColor = System.Drawing.Color.White;
            this.CharListView.FullRowSelect = true;
            this.CharListView.GridLines = true;
            this.CharListView.Location = new System.Drawing.Point(3, 5);
            this.CharListView.Margin = new System.Windows.Forms.Padding(3, 5, 5, 3);
            this.CharListView.MultiSelect = false;
            this.CharListView.Name = "CharListView";
            this.CharListView.ShowItemToolTips = true;
            this.CharListView.Size = new System.Drawing.Size(115, 525);
            this.CharListView.TabIndex = 0;
            this.CharListView.TileSize = new System.Drawing.Size(100, 10);
            this.CharListView.UseCompatibleStateImageBehavior = false;
            this.CharListView.View = System.Windows.Forms.View.List;
            this.CharListView.SelectedIndexChanged += new System.EventHandler(this.CharListView_SelectedIndexChanged);
            this.CharListView.Leave += new System.EventHandler(this.CharListView_Leave);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.splitContainer1);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.CharsStatusStrip);
            this.MainSplitContainer.Size = new System.Drawing.Size(234, 563);
            this.MainSplitContainer.SplitterDistance = 533;
            this.MainSplitContainer.TabIndex = 1;
            // 
            // CharsStatusStrip
            // 
            this.CharsStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CharsStatusLabel});
            this.CharsStatusStrip.Location = new System.Drawing.Point(0, 0);
            this.CharsStatusStrip.Name = "CharsStatusStrip";
            this.CharsStatusStrip.Size = new System.Drawing.Size(234, 26);
            this.CharsStatusStrip.SizingGrip = false;
            this.CharsStatusStrip.TabIndex = 1;
            // 
            // CharsStatusLabel
            // 
            this.CharsStatusLabel.AutoSize = false;
            this.CharsStatusLabel.Name = "CharsStatusLabel";
            this.CharsStatusLabel.Size = new System.Drawing.Size(219, 21);
            this.CharsStatusLabel.Spring = true;
            this.CharsStatusLabel.Text = "Выберите профиль";
            this.CharsStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditorPanel
            // 
            this.EditorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.EditorPanel.Location = new System.Drawing.Point(236, 2);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(699, 561);
            this.EditorPanel.TabIndex = 2;
            // 
            // SamplesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(238)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1148, 561);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.EditorPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SamplesForm";
            this.Text = "Звуки";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.Panel2.PerformLayout();
            this.MainSplitContainer.ResumeLayout(false);
            this.CharsStatusStrip.ResumeLayout(false);
            this.CharsStatusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.Button ButtonPlay;
        private System.Windows.Forms.ListBox CharBox;
        private System.Windows.Forms.ListView CharListView;
        private System.Windows.Forms.ComboBox ProfileComboBox;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.StatusStrip CharsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel CharsStatusLabel;
        private System.Windows.Forms.Button ButtonRecord;
        private System.Windows.Forms.Button AddProfile;
        private System.Windows.Forms.Button DeleteProfile;
        private System.Windows.Forms.Button AddSoundButton;
        private System.Windows.Forms.Button ButtonChange;
        private System.Windows.Forms.Button ButtonRename;
        private System.Windows.Forms.Panel EditorPanel;
    }
}