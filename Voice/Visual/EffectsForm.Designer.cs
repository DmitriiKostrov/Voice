namespace Voice.Visual
{
    partial class EffectsForm
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
            this.SoundControl = new System.Windows.Forms.TabControl();
            this.SoundTab = new System.Windows.Forms.TabPage();
            this.ReverseCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            SpeedTrack = new EConTech.Windows.MACUI.MACTrackBar();
            DiffusionTrack = new EConTech.Windows.MACUI.MACTrackBar();
            VolumeTrack = new EConTech.Windows.MACUI.MACTrackBar();
            FlangerTrack = new EConTech.Windows.MACUI.MACTrackBar();
            ChorusTrack = new EConTech.Windows.MACUI.MACTrackBar();
            ReverbTrack = new EConTech.Windows.MACUI.MACTrackBar();
            DistorsnTrack = new EConTech.Windows.MACUI.MACTrackBar();
            EchoTrack = new EConTech.Windows.MACUI.MACTrackBar();
            NervesTrack = new EConTech.Windows.MACUI.MACTrackBar();
            this.SoundControl.SuspendLayout();
            this.SoundTab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SoundControl
            // 
            this.SoundControl.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.SoundControl.Controls.Add(this.SoundTab);
            this.SoundControl.Controls.Add(this.tabPage2);
            this.SoundControl.Controls.Add(this.tabPage1);
            this.SoundControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoundControl.HotTrack = true;
            this.SoundControl.ItemSize = new System.Drawing.Size(115, 24);
            this.SoundControl.Location = new System.Drawing.Point(0, 0);
            this.SoundControl.Multiline = true;
            this.SoundControl.Name = "SoundControl";
            this.SoundControl.SelectedIndex = 0;
            this.SoundControl.Size = new System.Drawing.Size(155, 351);
            this.SoundControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.SoundControl.TabIndex = 68;
            // 
            // SoundTab
            // 
            this.SoundTab.BackColor = System.Drawing.Color.White;
            this.SoundTab.Controls.Add(this.ReverseCheckBox);
            this.SoundTab.Controls.Add(this.label2);
            this.SoundTab.Controls.Add(this.label3);
            this.SoundTab.Controls.Add(SpeedTrack);
            this.SoundTab.Controls.Add(DiffusionTrack);
            this.SoundTab.Controls.Add(VolumeTrack);
            this.SoundTab.Controls.Add(this.label1);
            this.SoundTab.Location = new System.Drawing.Point(4, 4);
            this.SoundTab.Name = "SoundTab";
            this.SoundTab.Padding = new System.Windows.Forms.Padding(3);
            this.SoundTab.Size = new System.Drawing.Size(123, 343);
            this.SoundTab.TabIndex = 0;
            this.SoundTab.Text = "Звучание ";
            // 
            // ReverseCheckBox
            // 
            this.ReverseCheckBox.AutoSize = true;
            this.ReverseCheckBox.Location = new System.Drawing.Point(6, 176);
            this.ReverseCheckBox.Name = "ReverseCheckBox";
            this.ReverseCheckBox.Size = new System.Drawing.Size(74, 17);
            this.ReverseCheckBox.TabIndex = 69;
            this.ReverseCheckBox.Text = "Обратить";
            this.ReverseCheckBox.UseVisualStyleBackColor = true;
            this.ReverseCheckBox.CheckedChanged += new System.EventHandler(this.ReverseCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(18, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 67;
            this.label2.Text = "Слитность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(18, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 63;
            this.label3.Text = "Громкость";
            // 
            // SpeedTrack
            // 
            SpeedTrack.BackColor = System.Drawing.Color.White;
            SpeedTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            SpeedTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            SpeedTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SpeedTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            SpeedTrack.IndentHeight = 6;
            SpeedTrack.Location = new System.Drawing.Point(6, 73);
            SpeedTrack.Maximum = 100;
            SpeedTrack.Minimum = -100;
            SpeedTrack.Name = "SpeedTrack";
            SpeedTrack.Size = new System.Drawing.Size(109, 27);
            SpeedTrack.TabIndex = 66;
            SpeedTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            SpeedTrack.TickColor = System.Drawing.Color.DarkGray;
            SpeedTrack.TickFrequency = 100;
            SpeedTrack.TickHeight = 2;
            SpeedTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            SpeedTrack.TrackerSize = new System.Drawing.Size(12, 12);
            SpeedTrack.TrackLineColor = System.Drawing.Color.Black;
            SpeedTrack.TrackLineHeight = 1;
            SpeedTrack.Value = 0;
            SpeedTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.SpeedTrack_ValueChanged);
            // 
            // DiffusionTrack
            // 
            DiffusionTrack.BackColor = System.Drawing.Color.White;
            DiffusionTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            DiffusionTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            DiffusionTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DiffusionTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            DiffusionTrack.IndentHeight = 6;
            DiffusionTrack.Location = new System.Drawing.Point(6, 123);
            DiffusionTrack.Maximum = 100;
            DiffusionTrack.Minimum = -100;
            DiffusionTrack.Name = "DiffusionTrack";
            DiffusionTrack.Size = new System.Drawing.Size(109, 27);
            DiffusionTrack.TabIndex = 68;
            DiffusionTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            DiffusionTrack.TickColor = System.Drawing.Color.DarkGray;
            DiffusionTrack.TickFrequency = 100;
            DiffusionTrack.TickHeight = 2;
            DiffusionTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            DiffusionTrack.TrackerSize = new System.Drawing.Size(12, 12);
            DiffusionTrack.TrackLineColor = System.Drawing.Color.Black;
            DiffusionTrack.TrackLineHeight = 1;
            DiffusionTrack.Value = 0;
            DiffusionTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.DiffusionTrack_ValueChanged);
            // 
            // VolumeTrack
            // 
            VolumeTrack.BackColor = System.Drawing.Color.White;
            VolumeTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            VolumeTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            VolumeTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VolumeTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            VolumeTrack.IndentHeight = 6;
            VolumeTrack.Location = new System.Drawing.Point(6, 25);
            VolumeTrack.Maximum = 100;
            VolumeTrack.Minimum = 0;
            VolumeTrack.Name = "VolumeTrack";
            VolumeTrack.Size = new System.Drawing.Size(109, 27);
            VolumeTrack.TabIndex = 64;
            VolumeTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            VolumeTrack.TickColor = System.Drawing.Color.DarkGray;
            VolumeTrack.TickFrequency = 50;
            VolumeTrack.TickHeight = 2;
            VolumeTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            VolumeTrack.TrackerSize = new System.Drawing.Size(12, 12);
            VolumeTrack.TrackLineColor = System.Drawing.Color.Black;
            VolumeTrack.TrackLineHeight = 1;
            VolumeTrack.Value = 100;
            VolumeTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.VolumeTrack_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(18, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 65;
            this.label1.Text = "Скорость";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(FlangerTrack);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(ChorusTrack);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(ReverbTrack);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(DistorsnTrack);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(EchoTrack);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(123, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " Эффекты  ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(18, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 80;
            this.label9.Text = "Сдвиг";
            // 
            // FlangerTrack
            // 
            FlangerTrack.BackColor = System.Drawing.Color.White;
            FlangerTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            FlangerTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            FlangerTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            FlangerTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            FlangerTrack.IndentHeight = 5;
            FlangerTrack.IndentWidth = 5;
            FlangerTrack.Location = new System.Drawing.Point(6, 116);
            FlangerTrack.Maximum = 40;
            FlangerTrack.Minimum = 0;
            FlangerTrack.Name = "FlangerTrack";
            FlangerTrack.Size = new System.Drawing.Size(110, 24);
            FlangerTrack.TabIndex = 81;
            FlangerTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            FlangerTrack.TickColor = System.Drawing.Color.DarkGray;
            FlangerTrack.TickFrequency = 8;
            FlangerTrack.TickHeight = 1;
            FlangerTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            FlangerTrack.TrackerSize = new System.Drawing.Size(12, 12);
            FlangerTrack.TrackLineColor = System.Drawing.Color.Black;
            FlangerTrack.TrackLineHeight = 1;
            FlangerTrack.Value = 0;
            FlangerTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.FlangerTrack_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(18, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 78;
            this.label7.Text = "Хор";
            // 
            // ChorusTrack
            // 
            ChorusTrack.BackColor = System.Drawing.Color.White;
            ChorusTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            ChorusTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            ChorusTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ChorusTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            ChorusTrack.IndentHeight = 5;
            ChorusTrack.IndentWidth = 5;
            ChorusTrack.Location = new System.Drawing.Point(6, 164);
            ChorusTrack.Maximum = 40;
            ChorusTrack.Minimum = 0;
            ChorusTrack.Name = "ChorusTrack";
            ChorusTrack.Size = new System.Drawing.Size(110, 24);
            ChorusTrack.TabIndex = 79;
            ChorusTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            ChorusTrack.TickColor = System.Drawing.Color.DarkGray;
            ChorusTrack.TickFrequency = 8;
            ChorusTrack.TickHeight = 1;
            ChorusTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            ChorusTrack.TrackerSize = new System.Drawing.Size(12, 12);
            ChorusTrack.TrackLineColor = System.Drawing.Color.Black;
            ChorusTrack.TrackLineHeight = 1;
            ChorusTrack.Value = 0;
            ChorusTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.ChorusTrack_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(18, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 76;
            this.label6.Text = "Реверберация";
            // 
            // ReverbTrack
            // 
            ReverbTrack.BackColor = System.Drawing.Color.White;
            ReverbTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            ReverbTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            ReverbTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ReverbTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            ReverbTrack.IndentHeight = 5;
            ReverbTrack.IndentWidth = 5;
            ReverbTrack.Location = new System.Drawing.Point(6, 20);
            ReverbTrack.Maximum = 10;
            ReverbTrack.Minimum = 0;
            ReverbTrack.Name = "ReverbTrack";
            ReverbTrack.Size = new System.Drawing.Size(110, 24);
            ReverbTrack.TabIndex = 77;
            ReverbTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            ReverbTrack.TickColor = System.Drawing.Color.DarkGray;
            ReverbTrack.TickFrequency = 2;
            ReverbTrack.TickHeight = 1;
            ReverbTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            ReverbTrack.TrackerSize = new System.Drawing.Size(12, 12);
            ReverbTrack.TrackLineColor = System.Drawing.Color.Black;
            ReverbTrack.TrackLineHeight = 1;
            ReverbTrack.Value = 0;
            ReverbTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.ReverbTrack_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(18, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 74;
            this.label5.Text = "Усиление";
            // 
            // DistorsnTrack
            // 
            DistorsnTrack.BackColor = System.Drawing.Color.White;
            DistorsnTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            DistorsnTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            DistorsnTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DistorsnTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            DistorsnTrack.IndentHeight = 5;
            DistorsnTrack.IndentWidth = 5;
            DistorsnTrack.Location = new System.Drawing.Point(6, 68);
            DistorsnTrack.Maximum = 10;
            DistorsnTrack.Minimum = 0;
            DistorsnTrack.Name = "DistorsnTrack";
            DistorsnTrack.Size = new System.Drawing.Size(110, 24);
            DistorsnTrack.TabIndex = 75;
            DistorsnTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            DistorsnTrack.TickColor = System.Drawing.Color.DarkGray;
            DistorsnTrack.TickFrequency = 2;
            DistorsnTrack.TickHeight = 1;
            DistorsnTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            DistorsnTrack.TrackerSize = new System.Drawing.Size(12, 12);
            DistorsnTrack.TrackLineColor = System.Drawing.Color.Black;
            DistorsnTrack.TrackLineHeight = 1;
            DistorsnTrack.Value = 0;
            DistorsnTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.DistorsnTrack_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(18, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 72;
            this.label4.Text = "Эхо";
            // 
            // EchoTrack
            // 
            EchoTrack.BackColor = System.Drawing.Color.White;
            EchoTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            EchoTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            EchoTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            EchoTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            EchoTrack.IndentHeight = 5;
            EchoTrack.IndentWidth = 5;
            EchoTrack.Location = new System.Drawing.Point(6, 212);
            EchoTrack.Maximum = 80;
            EchoTrack.Minimum = 0;
            EchoTrack.Name = "EchoTrack";
            EchoTrack.Size = new System.Drawing.Size(110, 24);
            EchoTrack.TabIndex = 73;
            EchoTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            EchoTrack.TickColor = System.Drawing.Color.DarkGray;
            EchoTrack.TickFrequency = 16;
            EchoTrack.TickHeight = 1;
            EchoTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            EchoTrack.TrackerSize = new System.Drawing.Size(12, 12);
            EchoTrack.TrackLineColor = System.Drawing.Color.Black;
            EchoTrack.TrackLineHeight = 1;
            EchoTrack.Value = 0;
            EchoTrack.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.EchoTrack_ValueChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(NervesTrack);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(123, 343);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Эмоции";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // NervesTrack
            // 
            NervesTrack.BackColor = System.Drawing.Color.White;
            NervesTrack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            NervesTrack.BorderStyle = EConTech.Windows.MACUI.MACBorderStyle.Flat;
            NervesTrack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NervesTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            NervesTrack.IndentHeight = 5;
            NervesTrack.IndentWidth = 5;
            NervesTrack.Location = new System.Drawing.Point(6, 23);
            NervesTrack.Maximum = 100;
            NervesTrack.Minimum = 0;
            NervesTrack.Name = "NervesTrack";
            NervesTrack.Size = new System.Drawing.Size(110, 24);
            NervesTrack.TabIndex = 73;
            NervesTrack.TextTickStyle = System.Windows.Forms.TickStyle.None;
            NervesTrack.TickColor = System.Drawing.Color.DarkGray;
            NervesTrack.TickFrequency = 10;
            NervesTrack.TickHeight = 1;
            NervesTrack.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            NervesTrack.TrackerSize = new System.Drawing.Size(12, 12);
            NervesTrack.TrackLineColor = System.Drawing.Color.Black;
            NervesTrack.TrackLineHeight = 1;
            NervesTrack.Value = 10;
            // 
            // EffectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(155, 351);
            this.ControlBox = false;
            this.Controls.Add(this.SoundControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EffectsForm";
            this.ShowInTaskbar = false;
            this.SoundControl.ResumeLayout(false);
            this.SoundTab.ResumeLayout(false);
            this.SoundTab.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SoundControl;
        private System.Windows.Forms.TabPage SoundTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ReverseCheckBox;
        EConTech.Windows.MACUI.MACTrackBar SpeedTrack;
        EConTech.Windows.MACUI.MACTrackBar DiffusionTrack;
        EConTech.Windows.MACUI.MACTrackBar VolumeTrack;
        EConTech.Windows.MACUI.MACTrackBar FlangerTrack;
        EConTech.Windows.MACUI.MACTrackBar ChorusTrack;
        EConTech.Windows.MACUI.MACTrackBar ReverbTrack;
        EConTech.Windows.MACUI.MACTrackBar DistorsnTrack;
        EConTech.Windows.MACUI.MACTrackBar EchoTrack;
        EConTech.Windows.MACUI.MACTrackBar NervesTrack;
    }
}