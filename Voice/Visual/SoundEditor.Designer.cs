namespace Voice
{
    partial class SoundEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundEditor));
            this.SrcPanel = new System.Windows.Forms.Panel();
            this.SrcPic = new Voice.Visual.WavePanel();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.ResultPic = new Voice.Visual.WavePanel();
            this.PartsPanel = new System.Windows.Forms.Panel();
            this.info2 = new System.Windows.Forms.TextBox();
            this.info1 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolButton100MS = new System.Windows.Forms.ToolStripButton();
            this.ToolButton1S = new System.Windows.Forms.ToolStripButton();
            this.ToolButton10S = new System.Windows.Forms.ToolStripButton();
            this.SrcPanel.SuspendLayout();
            this.ResultPanel.SuspendLayout();
            this.PartsPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SrcPanel
            // 
            this.SrcPanel.AllowDrop = true;
            this.SrcPanel.AutoScroll = true;
            this.SrcPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SrcPanel.Controls.Add(this.SrcPic);
            this.SrcPanel.Location = new System.Drawing.Point(0, 0);
            this.SrcPanel.Name = "SrcPanel";
            this.SrcPanel.Size = new System.Drawing.Size(688, 121);
            this.SrcPanel.TabIndex = 6;
            this.SrcPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.ResultPanel_DragEnter);
            // 
            // SrcPic
            // 
            this.SrcPic.BackColor = System.Drawing.Color.White;
            this.SrcPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SrcPic.Color = System.Drawing.Color.Orange;
            this.SrcPic.Location = new System.Drawing.Point(2, 2);
            this.SrcPic.Name = "SrcPic";
            this.SrcPic.Resolution = 100;
            this.SrcPic.Size = new System.Drawing.Size(682, 94);
            this.SrcPic.TabIndex = 3;
            this.SrcPic.TabStop = false;
            this.SrcPic.MouseEnter += new System.EventHandler(this.MainPic_MouseEnter);
            // 
            // ResultPanel
            // 
            this.ResultPanel.AllowDrop = true;
            this.ResultPanel.AutoScroll = true;
            this.ResultPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(238)))), ((int)(((byte)(233)))));
            this.ResultPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultPanel.Controls.Add(this.ResultPic);
            this.ResultPanel.Location = new System.Drawing.Point(0, 256);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Size = new System.Drawing.Size(688, 121);
            this.ResultPanel.TabIndex = 5;
            this.ResultPanel.Layout += new System.Windows.Forms.LayoutEventHandler(this.ResultPanel_Layout);
            this.ResultPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.ResultPanel_DragDrop);
            this.ResultPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.ResultPanel_DragEnter);
            // 
            // ResultPic
            // 
            this.ResultPic.AllowDrop = true;
            this.ResultPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultPic.Color = System.Drawing.Color.Black;
            this.ResultPic.Location = new System.Drawing.Point(2, 2);
            this.ResultPic.Name = "ResultPic";
            this.ResultPic.Resolution = 100;
            this.ResultPic.Size = new System.Drawing.Size(683, 113);
            this.ResultPic.TabIndex = 1;
            this.ResultPic.DragDrop += new System.Windows.Forms.DragEventHandler(this.ResultPanel_DragDrop);
            // 
            // PartsPanel
            // 
            this.PartsPanel.AllowDrop = true;
            this.PartsPanel.AutoScroll = true;
            this.PartsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PartsPanel.Controls.Add(this.info2);
            this.PartsPanel.Controls.Add(this.info1);
            this.PartsPanel.Location = new System.Drawing.Point(0, 127);
            this.PartsPanel.Name = "PartsPanel";
            this.PartsPanel.Size = new System.Drawing.Size(688, 123);
            this.PartsPanel.TabIndex = 4;
            this.PartsPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.ResultPanel_DragEnter);
            // 
            // info2
            // 
            this.info2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(238)))), ((int)(((byte)(233)))));
            this.info2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.info2.Enabled = false;
            this.info2.ForeColor = System.Drawing.Color.DimGray;
            this.info2.Location = new System.Drawing.Point(247, 3);
            this.info2.Multiline = true;
            this.info2.Name = "info2";
            this.info2.Size = new System.Drawing.Size(419, 122);
            this.info2.TabIndex = 1;
            this.info2.Text = resources.GetString("info2.Text");
            // 
            // info1
            // 
            this.info1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(238)))), ((int)(((byte)(233)))));
            this.info1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.info1.Enabled = false;
            this.info1.ForeColor = System.Drawing.Color.DimGray;
            this.info1.Location = new System.Drawing.Point(9, 3);
            this.info1.Multiline = true;
            this.info1.Name = "info1";
            this.info1.Size = new System.Drawing.Size(227, 115);
            this.info1.TabIndex = 0;
            this.info1.Text = "Верхний ряд: исходный звук\r\nСредний ряд: запомненные фрагменты \r\nНижний ряд:  ско" +
                "нструированный звук\r\n\r\nИспользуйте мышь \r\nдля манупиляции звуками\r\n\r\n           " +
                "\r\n         ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButton100MS,
            this.ToolButton1S,
            this.ToolButton10S});
            this.toolStrip1.Location = new System.Drawing.Point(0, 392);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(695, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 7;
            // 
            // ToolButton100MS
            // 
            this.ToolButton100MS.AutoSize = false;
            this.ToolButton100MS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(238)))), ((int)(((byte)(233)))));
            this.ToolButton100MS.CheckOnClick = true;
            this.ToolButton100MS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolButton100MS.Image = ((System.Drawing.Image)(resources.GetObject("ToolButton100MS.Image")));
            this.ToolButton100MS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButton100MS.Name = "ToolButton100MS";
            this.ToolButton100MS.Size = new System.Drawing.Size(56, 22);
            this.ToolButton100MS.Tag = "1000";
            this.ToolButton100MS.Text = "100мсек";
            this.ToolButton100MS.Click += new System.EventHandler(this.ToolButtonResolution_CheckedChanged);
            // 
            // ToolButton1S
            // 
            this.ToolButton1S.AutoSize = false;
            this.ToolButton1S.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(238)))), ((int)(((byte)(233)))));
            this.ToolButton1S.Checked = true;
            this.ToolButton1S.CheckOnClick = true;
            this.ToolButton1S.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolButton1S.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolButton1S.Image = ((System.Drawing.Image)(resources.GetObject("ToolButton1S.Image")));
            this.ToolButton1S.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButton1S.Name = "ToolButton1S";
            this.ToolButton1S.Size = new System.Drawing.Size(35, 22);
            this.ToolButton1S.Tag = "100";
            this.ToolButton1S.Text = "1сек";
            this.ToolButton1S.Click += new System.EventHandler(this.ToolButtonResolution_CheckedChanged);
            // 
            // ToolButton10S
            // 
            this.ToolButton10S.AutoSize = false;
            this.ToolButton10S.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(238)))), ((int)(((byte)(233)))));
            this.ToolButton10S.CheckOnClick = true;
            this.ToolButton10S.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolButton10S.Image = ((System.Drawing.Image)(resources.GetObject("ToolButton10S.Image")));
            this.ToolButton10S.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButton10S.Name = "ToolButton10S";
            this.ToolButton10S.Size = new System.Drawing.Size(41, 22);
            this.ToolButton10S.Tag = "10";
            this.ToolButton10S.Text = "10сек";
            this.ToolButton10S.Click += new System.EventHandler(this.ToolButtonResolution_CheckedChanged);
            // 
            // SoundEditor
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(238)))), ((int)(((byte)(233)))));
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.SrcPanel);
            this.Controls.Add(this.ResultPanel);
            this.Controls.Add(this.PartsPanel);
            this.Name = "SoundEditor";
            this.Size = new System.Drawing.Size(695, 417);
            this.SrcPanel.ResumeLayout(false);
            this.ResultPanel.ResumeLayout(false);
            this.PartsPanel.ResumeLayout(false);
            this.PartsPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SrcPanel;
        Voice.Visual.WavePanel SrcPic;
        private System.Windows.Forms.Panel ResultPanel;
        private System.Windows.Forms.Panel PartsPanel;
        private System.Windows.Forms.TextBox info2;
        private System.Windows.Forms.TextBox info1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolButton1S;
        private System.Windows.Forms.ToolStripButton ToolButton100MS;
        private System.Windows.Forms.ToolStripButton ToolButton10S;
        private Voice.Visual.WavePanel ResultPic;
    }
}
