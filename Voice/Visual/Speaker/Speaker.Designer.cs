namespace Voice.Visual
{
    partial class Speaker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Speaker));
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SpeakerEffectsPanel = new System.Windows.Forms.Panel();
            this.EditFaceCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RightEyeCenter = new Voice.Visual.EditableButton();
            this.LeftEyeCenter = new Voice.Visual.EditableButton();
            this.ButtonEyeLeft = new Voice.Visual.EditableButton();
            this.ButtonEyeRight = new Voice.Visual.EditableButton();
            this.tooth3 = new Voice.Visual.EditableButton();
            this.tooth1 = new Voice.Visual.EditableButton();
            this.tooth4 = new Voice.Visual.EditableButton();
            this.tooth2 = new Voice.Visual.EditableButton();
            this.MouseButton = new Voice.Visual.EditableButton();
            this.PlayNoseButton = new Voice.Visual.EditableButton();
            this.hair2 = new Voice.Visual.EditableButton();
            this.hair9 = new Voice.Visual.EditableButton();
            this.hair10 = new Voice.Visual.EditableButton();
            this.hair4 = new Voice.Visual.EditableButton();
            this.hair5 = new Voice.Visual.EditableButton();
            this.hair6 = new Voice.Visual.EditableButton();
            this.hair1 = new Voice.Visual.EditableButton();
            this.hair8 = new Voice.Visual.EditableButton();
            this.hair7 = new Voice.Visual.EditableButton();
            this.hair3 = new Voice.Visual.EditableButton();
            this.FaceLabel = new Voice.Visual.EditableButton();
            NervesTrack = new EConTech.Windows.MACUI.MACTrackBar();
            this.SpeakerEffectsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // TextBox
            // 
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Location = new System.Drawing.Point(0, 0);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(310, 520);
            this.TextBox.TabIndex = 0;
            this.TextBox.Text = resources.GetString("TextBox.Text");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(18, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 72;
            this.label8.Text = "Беспокойство";
            // 
            // SpeakerEffectsPanel
            // 
            this.SpeakerEffectsPanel.BackColor = System.Drawing.Color.White;
            this.SpeakerEffectsPanel.Controls.Add(NervesTrack);
            this.SpeakerEffectsPanel.Controls.Add(this.EditFaceCheckBox);
            this.SpeakerEffectsPanel.Controls.Add(this.label1);
            this.SpeakerEffectsPanel.Location = new System.Drawing.Point(295, 95);
            this.SpeakerEffectsPanel.Name = "SpeakerEffectsPanel";
            this.SpeakerEffectsPanel.Size = new System.Drawing.Size(135, 257);
            this.SpeakerEffectsPanel.TabIndex = 90;
            this.SpeakerEffectsPanel.Tag = "Говорун";
            // 
            // NervesTrack
            // 
            NervesTrack.BackColor = System.Drawing.Color.White;
            NervesTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            NervesTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            NervesTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NervesTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            NervesTrack.IndentHeight = 6;
            NervesTrack.Location = new System.Drawing.Point(8, 21);
            NervesTrack.Maximum = 100;
            NervesTrack.Minimum = 0;
            NervesTrack.Name = "NervesTrack";
            NervesTrack.Size = new System.Drawing.Size(109, 27);
            NervesTrack.TabIndex = 77;
            NervesTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            NervesTrack.TickColor = System.Drawing.Color.DarkGray;
            NervesTrack.TickFrequency = 10;
            NervesTrack.TickHeight = 2;
            NervesTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            NervesTrack.TrackerSize = new System.Drawing.Size(12, 12);
            NervesTrack.TrackLineColor = System.Drawing.Color.Black;
            NervesTrack.TrackLineHeight = 1;
            NervesTrack.Value = 100;
            NervesTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.NervesTrack_ValueChanged);
            // 
            // EditFaceCheckBox
            // 
            this.EditFaceCheckBox.AutoSize = true;
            this.EditFaceCheckBox.Location = new System.Drawing.Point(8, 62);
            this.EditFaceCheckBox.Name = "EditFaceCheckBox";
            this.EditFaceCheckBox.Size = new System.Drawing.Size(90, 17);
            this.EditFaceCheckBox.TabIndex = 76;
            this.EditFaceCheckBox.Text = "Конструктор";
            this.EditFaceCheckBox.UseVisualStyleBackColor = true;
            this.EditFaceCheckBox.CheckedChanged += new System.EventHandler(this.EditFaceCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(19, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 74;
            this.label1.Text = "Беспокойство";
            // 
            // RightEyeCenter
            // 
            this.RightEyeCenter.BackColor = System.Drawing.Color.Black;
            this.RightEyeCenter.FlatAppearance.BorderSize = 5;
            this.RightEyeCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightEyeCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RightEyeCenter.Location = new System.Drawing.Point(203, 217);
            this.RightEyeCenter.Name = "RightEyeCenter";
            this.RightEyeCenter.Size = new System.Drawing.Size(32, 32);
            this.RightEyeCenter.TabIndex = 89;
            this.RightEyeCenter.UseVisualStyleBackColor = false;
            // 
            // LeftEyeCenter
            // 
            this.LeftEyeCenter.BackColor = System.Drawing.Color.Black;
            this.LeftEyeCenter.FlatAppearance.BorderSize = 5;
            this.LeftEyeCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftEyeCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LeftEyeCenter.Location = new System.Drawing.Point(73, 217);
            this.LeftEyeCenter.Name = "LeftEyeCenter";
            this.LeftEyeCenter.Size = new System.Drawing.Size(32, 32);
            this.LeftEyeCenter.TabIndex = 88;
            this.LeftEyeCenter.UseVisualStyleBackColor = false;
            // 
            // ButtonEyeLeft
            // 
            this.ButtonEyeLeft.BackColor = System.Drawing.Color.White;
            this.ButtonEyeLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.ButtonEyeLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEyeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonEyeLeft.Location = new System.Drawing.Point(47, 197);
            this.ButtonEyeLeft.Name = "ButtonEyeLeft";
            this.ButtonEyeLeft.Size = new System.Drawing.Size(95, 92);
            this.ButtonEyeLeft.TabIndex = 63;
            this.ButtonEyeLeft.UseVisualStyleBackColor = false;
            this.ButtonEyeLeft.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // ButtonEyeRight
            // 
            this.ButtonEyeRight.BackColor = System.Drawing.Color.White;
            this.ButtonEyeRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEyeRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonEyeRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonEyeRight.Location = new System.Drawing.Point(177, 199);
            this.ButtonEyeRight.Name = "ButtonEyeRight";
            this.ButtonEyeRight.Size = new System.Drawing.Size(86, 77);
            this.ButtonEyeRight.TabIndex = 64;
            this.ButtonEyeRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonEyeRight.UseVisualStyleBackColor = false;
            this.ButtonEyeRight.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // tooth3
            // 
            this.tooth3.BackColor = System.Drawing.Color.White;
            this.tooth3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tooth3.Location = new System.Drawing.Point(157, 413);
            this.tooth3.Name = "tooth3";
            this.tooth3.Size = new System.Drawing.Size(17, 17);
            this.tooth3.TabIndex = 82;
            this.tooth3.UseVisualStyleBackColor = false;
            // 
            // tooth1
            // 
            this.tooth1.BackColor = System.Drawing.Color.White;
            this.tooth1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tooth1.Location = new System.Drawing.Point(125, 413);
            this.tooth1.Name = "tooth1";
            this.tooth1.Size = new System.Drawing.Size(17, 15);
            this.tooth1.TabIndex = 79;
            this.tooth1.UseVisualStyleBackColor = false;
            // 
            // tooth4
            // 
            this.tooth4.BackColor = System.Drawing.Color.White;
            this.tooth4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tooth4.Location = new System.Drawing.Point(173, 413);
            this.tooth4.Name = "tooth4";
            this.tooth4.Size = new System.Drawing.Size(17, 15);
            this.tooth4.TabIndex = 81;
            this.tooth4.UseVisualStyleBackColor = false;
            // 
            // tooth2
            // 
            this.tooth2.BackColor = System.Drawing.Color.White;
            this.tooth2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tooth2.Location = new System.Drawing.Point(141, 413);
            this.tooth2.Name = "tooth2";
            this.tooth2.Size = new System.Drawing.Size(17, 17);
            this.tooth2.TabIndex = 80;
            this.tooth2.UseVisualStyleBackColor = false;
            // 
            // MouseButton
            // 
            this.MouseButton.BackColor = System.Drawing.Color.LightCoral;
            this.MouseButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.MouseButton.FlatAppearance.BorderSize = 9;
            this.MouseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MouseButton.Location = new System.Drawing.Point(110, 413);
            this.MouseButton.Name = "MouseButton";
            this.MouseButton.Size = new System.Drawing.Size(99, 20);
            this.MouseButton.TabIndex = 68;
            this.MouseButton.UseVisualStyleBackColor = false;
            // 
            // PlayNoseButton
            // 
            this.PlayNoseButton.BackColor = System.Drawing.Color.Bisque;
            this.PlayNoseButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.PlayNoseButton.FlatAppearance.BorderSize = 0;
            this.PlayNoseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlayNoseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayNoseButton.Location = new System.Drawing.Point(135, 318);
            this.PlayNoseButton.Name = "PlayNoseButton";
            this.PlayNoseButton.Size = new System.Drawing.Size(48, 34);
            this.PlayNoseButton.TabIndex = 65;
            this.PlayNoseButton.Text = ". .";
            this.PlayNoseButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PlayNoseButton.UseMnemonic = false;
            this.PlayNoseButton.UseVisualStyleBackColor = true;
            // 
            // hair2
            // 
            this.hair2.BackColor = System.Drawing.Color.Tan;
            this.hair2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair2.Location = new System.Drawing.Point(110, 144);
            this.hair2.Name = "hair2";
            this.hair2.Size = new System.Drawing.Size(10, 29);
            this.hair2.TabIndex = 78;
            this.hair2.UseVisualStyleBackColor = false;
            this.hair2.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // hair9
            // 
            this.hair9.BackColor = System.Drawing.Color.Tan;
            this.hair9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair9.Location = new System.Drawing.Point(177, 144);
            this.hair9.Name = "hair9";
            this.hair9.Size = new System.Drawing.Size(14, 29);
            this.hair9.TabIndex = 77;
            this.hair9.UseVisualStyleBackColor = false;
            this.hair9.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // hair10
            // 
            this.hair10.BackColor = System.Drawing.Color.Tan;
            this.hair10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair10.Location = new System.Drawing.Point(189, 127);
            this.hair10.Name = "hair10";
            this.hair10.Size = new System.Drawing.Size(10, 46);
            this.hair10.TabIndex = 76;
            this.hair10.UseVisualStyleBackColor = false;
            this.hair10.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // hair4
            // 
            this.hair4.BackColor = System.Drawing.Color.Tan;
            this.hair4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair4.Location = new System.Drawing.Point(126, 134);
            this.hair4.Name = "hair4";
            this.hair4.Size = new System.Drawing.Size(14, 39);
            this.hair4.TabIndex = 75;
            this.hair4.UseVisualStyleBackColor = false;
            this.hair4.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // hair5
            // 
            this.hair5.BackColor = System.Drawing.Color.Tan;
            this.hair5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair5.Location = new System.Drawing.Point(137, 108);
            this.hair5.Name = "hair5";
            this.hair5.Size = new System.Drawing.Size(14, 65);
            this.hair5.TabIndex = 74;
            this.hair5.UseVisualStyleBackColor = false;
            this.hair5.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // hair6
            // 
            this.hair6.BackColor = System.Drawing.Color.Tan;
            this.hair6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair6.Location = new System.Drawing.Point(146, 156);
            this.hair6.Name = "hair6";
            this.hair6.Size = new System.Drawing.Size(17, 17);
            this.hair6.TabIndex = 73;
            this.hair6.UseVisualStyleBackColor = false;
            this.hair6.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // hair1
            // 
            this.hair1.BackColor = System.Drawing.Color.Tan;
            this.hair1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair1.Location = new System.Drawing.Point(106, 117);
            this.hair1.Name = "hair1";
            this.hair1.Size = new System.Drawing.Size(10, 56);
            this.hair1.TabIndex = 72;
            this.hair1.UseVisualStyleBackColor = false;
            this.hair1.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // hair8
            // 
            this.hair8.BackColor = System.Drawing.Color.Tan;
            this.hair8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair8.Location = new System.Drawing.Point(169, 127);
            this.hair8.Name = "hair8";
            this.hair8.Size = new System.Drawing.Size(14, 46);
            this.hair8.TabIndex = 71;
            this.hair8.UseVisualStyleBackColor = false;
            this.hair8.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // hair7
            // 
            this.hair7.BackColor = System.Drawing.Color.Tan;
            this.hair7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair7.Location = new System.Drawing.Point(157, 122);
            this.hair7.Name = "hair7";
            this.hair7.Size = new System.Drawing.Size(14, 51);
            this.hair7.TabIndex = 70;
            this.hair7.UseVisualStyleBackColor = false;
            this.hair7.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // hair3
            // 
            this.hair3.BackColor = System.Drawing.Color.Tan;
            this.hair3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hair3.Location = new System.Drawing.Point(117, 122);
            this.hair3.Name = "hair3";
            this.hair3.Size = new System.Drawing.Size(14, 51);
            this.hair3.TabIndex = 69;
            this.hair3.UseVisualStyleBackColor = false;
            this.hair3.Paint += new System.Windows.Forms.PaintEventHandler(this.Hair_Paint);
            // 
            // FaceLabel
            // 
            this.FaceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(175)))));
            this.FaceLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FaceLabel.Location = new System.Drawing.Point(29, 156);
            this.FaceLabel.Name = "FaceLabel";
            this.FaceLabel.Size = new System.Drawing.Size(251, 349);
            this.FaceLabel.TabIndex = 0;
            this.FaceLabel.UseVisualStyleBackColor = false;
            // 
            // Speaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RightEyeCenter);
            this.Controls.Add(this.LeftEyeCenter);
            this.Controls.Add(this.ButtonEyeLeft);
            this.Controls.Add(this.ButtonEyeRight);
            this.Controls.Add(this.tooth3);
            this.Controls.Add(this.tooth1);
            this.Controls.Add(this.tooth4);
            this.Controls.Add(this.tooth2);
            this.Controls.Add(this.MouseButton);
            this.Controls.Add(this.PlayNoseButton);
            this.Controls.Add(this.hair2);
            this.Controls.Add(this.hair9);
            this.Controls.Add(this.hair10);
            this.Controls.Add(this.hair4);
            this.Controls.Add(this.hair5);
            this.Controls.Add(this.hair6);
            this.Controls.Add(this.hair1);
            this.Controls.Add(this.hair8);
            this.Controls.Add(this.hair7);
            this.Controls.Add(this.hair3);
            this.Controls.Add(this.SpeakerEffectsPanel);
            this.Controls.Add(this.FaceLabel);
            this.Controls.Add(this.TextBox);
            this.Name = "Speaker";
            this.Size = new System.Drawing.Size(310, 520);
            this.SpeakerEffectsPanel.ResumeLayout(false);
            this.SpeakerEffectsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        volatile private EditableButton tooth3;
        volatile private EditableButton tooth1;
        volatile private EditableButton tooth4;
        volatile private EditableButton tooth2;
        volatile private EditableButton ButtonEyeLeft;
        volatile private EditableButton MouseButton;
        volatile private EditableButton PlayNoseButton;
        volatile private EditableButton ButtonEyeRight;
        volatile private System.Windows.Forms.Panel SpeakerEffectsPanel;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private EditableButton hair2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private EditableButton hair9;
        private EditableButton hair10;
        private EditableButton hair4;
        private EditableButton hair5;
        private EditableButton hair6;
        private EditableButton hair1;
        private EditableButton hair8;
        private EditableButton hair7;
        private System.Windows.Forms.TextBox TextBox;
        private EditableButton FaceLabel;
        private EditableButton hair3;
        private EditableButton LeftEyeCenter;
        private EditableButton RightEyeCenter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox EditFaceCheckBox;
        EConTech.Windows.MACUI.MACTrackBar NervesTrack;
    }
}
