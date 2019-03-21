using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using VoiceEngine.Logic.Sound;
using VoiceEngine.Utils;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Voice.Visual;

namespace Voice
{
    public partial class SoundEditor : UserControl
    {
        AudioFrame  _audioFrame;
        Bitmap      _img;
        int         _partStart = 0;
        int         _partEnd = 0;
        int         _lastViewPoint = 0;
        List<Label> _storedParts;
        List<Label> _intervalLabels;
        int         _partTotalID = 0;

        HatchBrush  _brushChoose;
        Color[]     _colors;
        int _colorID = 0;

        public SoundEditor(Control parent)
        {
            this.Parent = parent;
            InitializeComponent();
            wavePanel1.Init(parent);
            // pixels per second
            ToolButton100MS.Tag = 1000;
            ToolButton1S.Tag = 100;
            ToolButton10S.Tag = 10;
            ListenToolButton.Tag = WavePanelState.Listen;
            EditToolButton.Tag = WavePanelState.Edit;
            initPanels();
            _intervalLabels = new List<Label>();
            ResultPicture.MouseEnter += new EventHandler(ResultPicture_MouseEnter);
            ResultPicture.Location = new Point(3, 3);
            ResultPicture.BackColor = Color.White;
            ResultPicture.Image = null;
            SrcPic.Location = new Point(3, 3);//Microsoft Sans Serif
            _colors = new Color[] { Color.Violet, Color.LimeGreen, Color.Blue, Color.Orange, Color.DarkTurquoise, Color.Red};
            _brushChoose = new HatchBrush(HatchStyle.Percent10, Color.Orange, Color.Transparent);
            _storedParts = new List<Label>();
            _audioFrame = new AudioFrame(false);
            eb1.Parent = this;
            eb1.BringToFront();
            eb1.SetEditMode();
           // eb1.Dra
        }

        void ResultPicture_MouseEnter(object sender, EventArgs e)
        {
            ResultPanel.Focus();
        }

        const int SB_HORZ = 0;
        [DllImport("user32.dll")]
        static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        public void OnShow()
        {
            //ShowScrollBar(this.SrcPanel.Handle, SB_HORZ, false);
            //ShowScrollBar(this.SrcPanel.Handle, 1, false);
        }

        private void initPanels()
        {
            SrcPanel.Height = PartsPanel.Height = ResultPanel.Height = (this.Parent.Height - 40) / 3;
            SrcPanel.Width = PartsPanel.Width = ResultPanel.Width = (this.Parent.Width - 3);
            SrcPic.Height = ResultPicture.Height = SrcPanel.Height - 29;
            wavePanel1.Height = SrcPic.Height + 2;
            PartsPanel.Top = SrcPanel.Top + SrcPanel.Height + 6;
            ResultPanel.Top = PartsPanel.Top + PartsPanel.Height + 6;
            ListenToolButton.Width = EditToolButton.Width = ToolButton100MS.Width = 
                ToolButton1S.Width = ToolButton10S.Width = (this.Parent.Width - 8) / 5;

            //SrcPanel.MouseWheel  += new MouseEventHandler(SrcPanel_MouseWheel);
            //SrcPanel.MouseWheel += new MouseEventHandler(SrcPanel_MouseWheel);
            //this.MouseWheel += new MouseEventHandler(SrcPanel_MouseWheel);
           // button1.MouseWheel += new MouseEventHandler(SrcPanel_MouseWheel);
        }

        /*void SrcPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            SrcPanel.HorizontalScroll.Maximum = 1000;
            if (e.Delta < 0)
            {
                if (SrcPanel.HorizontalScroll.Maximum > SrcPanel.HorizontalScroll.Value)
                    SrcPanel.HorizontalScroll.Value += 1;
            }
            else if (SrcPanel.HorizontalScroll.Minimum < SrcPanel.HorizontalScroll.Value)
                SrcPanel.HorizontalScroll.Value -= 1;// e.Delta;
        }*/

        /*private void initVisualParts()
        {
            _img = new Bitmap(SrcPic.Width, SrcPic.Height);
            Graphics g = Graphics.FromImage(_img);
            g.DrawImage(SrcPic.Image, 0, 0);
            g.Dispose();
            SrcPanel.HorizontalScroll.Value = 0;
            //addIntervals(SrcPic);
            SrcPanel.Refresh();
            
        }*/

        public void ShowAmplitudes(byte []bytes)
        {
            _audioFrame.Color = _colors[_colorID];
            wavePanel1.Color = _colors[_colorID]; 
            //_audioFrame.Resolution = int.Parse(ResolutionTB.Text);
            _audioFrame.Process(ref bytes, true);
            //_audioFrame.RenderTimeDomain(ref SrcPic);
            wavePanel1.SetWave( bytes, true);
            //wavePanel1.SetWave(SrcPic.Image, bytes, true);
            initVisualParts();
            _colorID = (_colorID + 1) % _colors.Length;
            //_audioFrame.RenderFrequencyDomain(ref DiagPicture);

        }

        private void addIntervals(PictureBox pic)
        {
            foreach (Label l in _intervalLabels)
            {
                l.Dispose();
            }
            _intervalLabels.Clear();
            double step = 100.0 / _audioFrame.Resolution;
            double pos = 0;
            for (int i = 0; i < pic.Width; i += 100)
            {
                Label l = new Label();
                l.Text = pos.ToString();
                l.TextAlign = ContentAlignment.MiddleLeft;
                pos = Math.Round(pos + step, (step > 0.05) ? 1 : 2);
                l.BackColor = Color.White;
                l.Top = pic.Height + pic.Top - 18;
                l.Left = i + pic.Left;
                l.Height = 16;
                l.Width = ((double)i).ToString().Length * 10;
                l.Parent = pic;
                l.BringToFront();
                _intervalLabels.Add(l);
            }
        }

        private void copyImagePart(int start, int end)
        {
            int lastPos = (_storedParts.Count > 0) ?
                            _storedParts[_storedParts.Count - 1].Location.X + _storedParts[_storedParts.Count - 1].Width : 0;
            Label box = new Label();
            box.BackColor = Color.White;
            box.Image = getImagePart(_img, start, 0, end - start, _img.Height);
            box.Location = new Point(lastPos + 3, 3);
            box.FlatStyle = FlatStyle.Flat;
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Width = end - start;
            box.Height = _img.Height;
            box.Parent = PartsPanel;
            box.DoubleClick += new EventHandler(box_DoubleClick);
            box.MouseClick += new MouseEventHandler(box_MouseClick);
            box.Enabled = true;
            box.Tag = _storedParts.Count;
            box.MouseEnter += new EventHandler(box_MouseEnter);
            info1.Visible = false;
            info2.Visible = false;
            info3.Visible = false;

            // pseudo button for moving
            /*Button but = new Button();
            but.Location = box.Location;
            but.Width = box.Width;
            but.Height = box.Height;
            but.FlatStyle = FlatStyle.Flat;
            but.Parent = MainPanel;*/

            box.BringToFront();
            _storedParts.Add(box);
        }

        void box_MouseEnter(object sender, EventArgs e)
        {
            PartsPanel.Focus();
        }

        private Bitmap combineImages(Bitmap where, Bitmap what)
        {
            Bitmap res = new Bitmap((where != null ? where.Width : 0) + what.Width, what.Height);
            Graphics graph = Graphics.FromImage(res);
            if (where != null)
            {
                graph.DrawImage(where, new Point(0, 0));
            }
            graph.DrawImage(what, new Point((where != null ? where.Width : 0), 0));
            graph.Dispose();
            return res;
        }

        void box_DoubleClick(object sender, EventArgs e)
        {
            ResultPicture.Image = combineImages((Bitmap)ResultPicture.Image, (Bitmap)((Label)sender).Image);
            ResultPicture.Width = ResultPicture.Image.Width;
        }

        void box_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Label box = (Label)sender;
                int boxLeft = box.Width + 3;
                _storedParts.RemoveAt((int)box.Tag);
                box.Dispose();
                PartsPanel.Refresh();
                for (int i = (int)box.Tag; i < _storedParts.Count; i++)
                {
                    _storedParts[i].Left -= boxLeft;
                    _storedParts[i].Tag = (int)_storedParts[i].Tag - 1;
                }
                if (_storedParts.Count == 0)
                {
                    info1.Visible = true;
                    info2.Visible = true;
                    info3.Visible = true;
                }
                PartsPanel.Refresh();
            }
        }

        private Bitmap getImagePart(Bitmap src, int x0, int y0, int width, int height)
        {
            Bitmap res = new Bitmap(width, height);
            //res.
            Graphics graph = Graphics.FromImage(res);
            //SolidBrush brush = new SolidBrush(Color.Black);
            graph.DrawImage(src, new Rectangle(0, 0, width, height), new Rectangle(x0, y0, width, height), GraphicsUnit.Pixel);
            //graph.DrawString(_partTotalID.ToString(), _fontDigits, Brushes.Azure, new PointF(2f, 2f));
            _partTotalID++;
            graph.Dispose();
            return res;
        }

        #region Mouse Events
        private void MainPic_MouseDown(object sender, MouseEventArgs e)
        {
            if (_img == null)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                if (e.X > _partStart && e.X < _partEnd)
                {
                    //copy image part
                    copyImagePart(_partStart, _partEnd);
                }
                else
                {
                    _partStart = e.X;
                    _partEnd = 0;
                    //SrcPic.Image = (Image)_img.Clone();
                    SrcPic.Refresh();
                }
                //MessageBox.Show("Left: " + e.Location.ToString() + ". clicks: " + e.Clicks.ToString());
            }
            else if (e.Button == MouseButtons.Right)
            {
                //MessageBox.Show("Right: " + e.Location.ToString());
                // delete image part
                //SrcPic.Image = (Image)_img.Clone();
            }
        }

        private void MainPic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Double: " + e.Location.ToString());
        }

        private void MainPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _img != null)
            {
                SrcPic.Image = (Image)_img.Clone();
                Graphics graph = Graphics.FromImage(SrcPic.Image);

                Pen pen = new Pen(Color.Black);
                _partEnd = e.X;
                int start = (_partStart < e.X) ? _partStart : e.X;
                int end = (_partStart > e.X) ? _partStart : e.X;
                graph.DrawRectangle(pen, start, 0, end - start, SrcPic.Height - 1);
                graph.FillRectangle(_brushChoose, start + 1, 1, end - start - 2, SrcPic.Height - 3);
                SrcPic.Refresh();
                //MainPic.Image = (Image)graph;
            }
        }

        private void MainPic_MouseUp(object sender, MouseEventArgs e)
        {
            if (_partStart > _partEnd)
            {
                int tmp = _partStart;
                _partStart = _partEnd;
                _partEnd = tmp;
            }
        }

        #endregion

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            if (PartsPanel.AutoScrollPosition.X > 0)
            {
                PartsPanel.AutoScroll = true;
                PartsPanel.AutoScrollPosition = new Point(PartsPanel.AutoScrollPosition.X - 20, 0);
                //MainPanel.AutoScroll = false;
                PartsPanel.Invalidate();
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (PartsPanel.AutoScrollPosition.X + PartsPanel.Width < _lastViewPoint)
            {
                PartsPanel.AutoScroll = true;
                PartsPanel.AutoScrollPosition = new Point(PartsPanel.AutoScrollPosition.X + 20, 0);
                //MainPanel.AutoScroll = false;
                PartsPanel.Invalidate();
            }
        }

        private void ResultPicture_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ResultPicture.Image.Dispose();
                ResultPicture.Width = 0;
                ResultPicture.Image = null;
            }
        }

        private void MainPic_MouseEnter(object sender, EventArgs e)
        {
            SrcPanel.Focus();
        }

        private void ToolButtonResolution_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            ToolButton100MS.Checked = false;
            ToolButton1S.Checked = false;
            ToolButton10S.Checked = false;
            tsb.Checked = true;
            if ((int)tsb.Tag != _audioFrame.Resolution)
            {
                wavePanel1.Resolution = (int)tsb.Tag;
                _audioFrame.Resolution = (int)tsb.Tag;
                _audioFrame.RenderTimeDomain(ref SrcPic);
                initVisualParts();
            }
        }

        private void ListenEditToolButton_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            EditToolButton.Checked = false;
            ListenToolButton.Checked = false;
            tsb.Checked = true;
            /*if ((WavePanelState)tsb.Tag != wavePanel1.State)
            {
                wavePanel1.State = (WavePanelState)tsb.Tag;
            }*/
        }

        private void wavePanel1_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.Data.ToString());
        }

        private void ResultPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect= DragDropEffects.Move;
        }

    }
}
