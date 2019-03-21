namespace Voice.Visual
{
    partial class VinilControl
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.VinilCombo = new System.Windows.Forms.ComboBox();
            this.VinilEffectsPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ButtonCombo5 = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ButtonCombo4 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonCombo3 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonCombo2 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ButtonCombo1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonS2 = new System.Windows.Forms.Button();
            this.buttonS1 = new System.Windows.Forms.Button();
            this.buttonS5 = new System.Windows.Forms.Button();
            this.buttonS3 = new System.Windows.Forms.Button();
            this.buttonS4 = new System.Windows.Forms.Button();
            this.VinilLabel = new System.Windows.Forms.Label();
            ReactionTrack = new EConTech.Windows.MACUI.MACTrackBar();
            this.VinilEffectsPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // VinilCombo
            // 
            this.VinilCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VinilCombo.FormattingEnabled = true;
            this.VinilCombo.Location = new System.Drawing.Point(0, 0);
            this.VinilCombo.Name = "VinilCombo";
            this.VinilCombo.Size = new System.Drawing.Size(110, 21);
            this.VinilCombo.TabIndex = 7;
            this.VinilCombo.SelectedIndexChanged += new System.EventHandler(this.VinilCombo_SelectedIndexChanged);
            // 
            // VinilEffectsPanel
            // 
            this.VinilEffectsPanel.BackColor = System.Drawing.Color.White;
            this.VinilEffectsPanel.Controls.Add(this.label7);
            this.VinilEffectsPanel.Controls.Add(ReactionTrack);
            this.VinilEffectsPanel.Controls.Add(this.panel5);
            this.VinilEffectsPanel.Controls.Add(this.panel6);
            this.VinilEffectsPanel.Controls.Add(this.panel2);
            this.VinilEffectsPanel.Controls.Add(this.panel3);
            this.VinilEffectsPanel.Controls.Add(this.panel4);
            this.VinilEffectsPanel.Controls.Add(this.panel1);
            this.VinilEffectsPanel.Controls.Add(this.label6);
            this.VinilEffectsPanel.Controls.Add(this.label5);
            this.VinilEffectsPanel.Controls.Add(this.label4);
            this.VinilEffectsPanel.Controls.Add(this.label3);
            this.VinilEffectsPanel.Controls.Add(this.label2);
            this.VinilEffectsPanel.Controls.Add(this.label1);
            this.VinilEffectsPanel.Location = new System.Drawing.Point(311, 23);
            this.VinilEffectsPanel.Name = "VinilEffectsPanel";
            this.VinilEffectsPanel.Size = new System.Drawing.Size(135, 344);
            this.VinilEffectsPanel.TabIndex = 91;
            this.VinilEffectsPanel.Tag = "Винил";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(20, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 88;
            this.label7.Text = "Отдача";
            // 
            // ReactionTrack
            // 
            ReactionTrack.BackColor = System.Drawing.Color.White;
            ReactionTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            ReactionTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            ReactionTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ReactionTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            ReactionTrack.IndentHeight = 6;
            ReactionTrack.Location = new System.Drawing.Point(8, 300);
            ReactionTrack.Maximum = 20;
            ReactionTrack.Minimum = 0;
            ReactionTrack.Name = "ReactionTrack";
            ReactionTrack.Size = new System.Drawing.Size(109, 27);
            ReactionTrack.TabIndex = 89;
            ReactionTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            ReactionTrack.TickColor = System.Drawing.Color.DarkGray;
            ReactionTrack.TickFrequency = 2;
            ReactionTrack.TickHeight = 2;
            ReactionTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            ReactionTrack.TrackerSize = new System.Drawing.Size(12, 12);
            ReactionTrack.TrackLineColor = System.Drawing.Color.Black;
            ReactionTrack.TrackLineHeight = 1;
            ReactionTrack.Value = 20;
            ReactionTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.ReactionTrack_ValueChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ButtonCombo5);
            this.panel5.Location = new System.Drawing.Point(8, 249);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(110, 21);
            this.panel5.TabIndex = 87;
            // 
            // ButtonCombo5
            // 
            this.ButtonCombo5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCombo5.FormattingEnabled = true;
            this.ButtonCombo5.Location = new System.Drawing.Point(0, 0);
            this.ButtonCombo5.Name = "ButtonCombo5";
            this.ButtonCombo5.Size = new System.Drawing.Size(110, 21);
            this.ButtonCombo5.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ButtonCombo4);
            this.panel6.Location = new System.Drawing.Point(8, 206);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(110, 21);
            this.panel6.TabIndex = 87;
            // 
            // ButtonCombo4
            // 
            this.ButtonCombo4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCombo4.FormattingEnabled = true;
            this.ButtonCombo4.Location = new System.Drawing.Point(0, 0);
            this.ButtonCombo4.Name = "ButtonCombo4";
            this.ButtonCombo4.Size = new System.Drawing.Size(110, 21);
            this.ButtonCombo4.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ButtonCombo3);
            this.panel2.Location = new System.Drawing.Point(8, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(110, 21);
            this.panel2.TabIndex = 86;
            // 
            // ButtonCombo3
            // 
            this.ButtonCombo3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCombo3.FormattingEnabled = true;
            this.ButtonCombo3.Location = new System.Drawing.Point(0, 0);
            this.ButtonCombo3.Name = "ButtonCombo3";
            this.ButtonCombo3.Size = new System.Drawing.Size(110, 21);
            this.ButtonCombo3.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ButtonCombo2);
            this.panel3.Location = new System.Drawing.Point(8, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(110, 21);
            this.panel3.TabIndex = 86;
            // 
            // ButtonCombo2
            // 
            this.ButtonCombo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCombo2.FormattingEnabled = true;
            this.ButtonCombo2.Location = new System.Drawing.Point(0, 0);
            this.ButtonCombo2.Name = "ButtonCombo2";
            this.ButtonCombo2.Size = new System.Drawing.Size(110, 21);
            this.ButtonCombo2.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ButtonCombo1);
            this.panel4.Location = new System.Drawing.Point(8, 77);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(110, 21);
            this.panel4.TabIndex = 86;
            // 
            // ButtonCombo1
            // 
            this.ButtonCombo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCombo1.FormattingEnabled = true;
            this.ButtonCombo1.Location = new System.Drawing.Point(0, 0);
            this.ButtonCombo1.Name = "ButtonCombo1";
            this.ButtonCombo1.Size = new System.Drawing.Size(110, 21);
            this.ButtonCombo1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.VinilCombo);
            this.panel1.Location = new System.Drawing.Point(8, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 21);
            this.panel1.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(19, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 84;
            this.label6.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(19, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 15);
            this.label5.TabIndex = 82;
            this.label5.Text = "4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(19, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 80;
            this.label4.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(19, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 78;
            this.label3.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(19, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 76;
            this.label2.Text = "1";
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
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 74;
            this.label1.Text = "Винил";
            // 
            // buttonS2
            // 
            this.buttonS2.BackColor = System.Drawing.Color.White;
            this.buttonS2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonS2.ForeColor = System.Drawing.Color.Black;
            this.buttonS2.Location = new System.Drawing.Point(77, 332);
            this.buttonS2.Name = "buttonS2";
            this.buttonS2.Size = new System.Drawing.Size(52, 52);
            this.buttonS2.TabIndex = 12;
            this.buttonS2.Text = "2";
            this.buttonS2.UseVisualStyleBackColor = false;
            this.buttonS2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyUp);
            this.buttonS2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyDown);
            // 
            // buttonS1
            // 
            this.buttonS1.BackColor = System.Drawing.Color.White;
            this.buttonS1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonS1.ForeColor = System.Drawing.Color.Black;
            this.buttonS1.Location = new System.Drawing.Point(19, 332);
            this.buttonS1.Name = "buttonS1";
            this.buttonS1.Size = new System.Drawing.Size(52, 52);
            this.buttonS1.TabIndex = 11;
            this.buttonS1.Text = "1";
            this.buttonS1.UseVisualStyleBackColor = false;
            this.buttonS1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyUp);
            this.buttonS1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyDown);
            // 
            // buttonS5
            // 
            this.buttonS5.BackColor = System.Drawing.Color.White;
            this.buttonS5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonS5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonS5.ForeColor = System.Drawing.Color.Black;
            this.buttonS5.Location = new System.Drawing.Point(251, 332);
            this.buttonS5.Name = "buttonS5";
            this.buttonS5.Size = new System.Drawing.Size(52, 52);
            this.buttonS5.TabIndex = 10;
            this.buttonS5.Text = "5";
            this.buttonS5.UseVisualStyleBackColor = false;
            this.buttonS5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyUp);
            this.buttonS5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyDown);
            // 
            // buttonS3
            // 
            this.buttonS3.BackColor = System.Drawing.Color.White;
            this.buttonS3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonS3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonS3.ForeColor = System.Drawing.Color.Black;
            this.buttonS3.Location = new System.Drawing.Point(135, 332);
            this.buttonS3.Name = "buttonS3";
            this.buttonS3.Size = new System.Drawing.Size(52, 52);
            this.buttonS3.TabIndex = 9;
            this.buttonS3.Text = "3";
            this.buttonS3.UseVisualStyleBackColor = false;
            this.buttonS3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyUp);
            this.buttonS3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyDown);
            // 
            // buttonS4
            // 
            this.buttonS4.BackColor = System.Drawing.Color.White;
            this.buttonS4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonS4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonS4.ForeColor = System.Drawing.Color.Black;
            this.buttonS4.Location = new System.Drawing.Point(193, 332);
            this.buttonS4.Name = "buttonS4";
            this.buttonS4.Size = new System.Drawing.Size(52, 52);
            this.buttonS4.TabIndex = 8;
            this.buttonS4.Text = "4";
            this.buttonS4.UseVisualStyleBackColor = false;
            this.buttonS4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyUp);
            this.buttonS4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyDown);
            // 
            // VinilLabel
            // 
            this.VinilLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(165)))));
            this.VinilLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VinilLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VinilLabel.Image = global::Zвук.Properties.Resources.vinil;
            this.VinilLabel.Location = new System.Drawing.Point(16, 23);
            this.VinilLabel.Name = "VinilLabel";
            this.VinilLabel.Size = new System.Drawing.Size(289, 290);
            this.VinilLabel.TabIndex = 6;
            this.VinilLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VinilLabel_MouseDown);
            this.VinilLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VinilLabel_MouseUp);
            this.VinilLabel.MouseEnter += new System.EventHandler(this.VinilLabel_MouseEnter);
            // 
            // VinilControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(165)))));
            this.Controls.Add(this.VinilEffectsPanel);
            this.Controls.Add(this.buttonS2);
            this.Controls.Add(this.buttonS1);
            this.Controls.Add(this.buttonS5);
            this.Controls.Add(this.buttonS3);
            this.Controls.Add(this.buttonS4);
            this.Controls.Add(this.VinilLabel);
            this.DoubleBuffered = true;
            this.Name = "VinilControl";
            this.Size = new System.Drawing.Size(325, 405);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyUp);
            this.EnabledChanged += new System.EventHandler(this.VinilControl_EnabledChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VinilControl_KeyDown);
            this.VinilEffectsPanel.ResumeLayout(false);
            this.VinilEffectsPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label VinilLabel;
        private System.Windows.Forms.ComboBox VinilCombo;
        private System.Windows.Forms.Button buttonS4;
        private System.Windows.Forms.Button buttonS3;
        private System.Windows.Forms.Button buttonS5;
        private System.Windows.Forms.Button buttonS1;
        private System.Windows.Forms.Button buttonS2;
        private System.Windows.Forms.Panel VinilEffectsPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox ButtonCombo5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox ButtonCombo4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ButtonCombo3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox ButtonCombo2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox ButtonCombo1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        EConTech.Windows.MACUI.MACTrackBar ReactionTrack;
    }
}

