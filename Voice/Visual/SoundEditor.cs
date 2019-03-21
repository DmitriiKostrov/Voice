using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic.Sound;
using VoiceEngine.Utils;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Voice.Visual;

namespace Voice
{
    public partial class SoundEditor : UserControl
    {
        public event SaveWavDelegate SaveEvent;

        List<WavePanel> _storedParts;
        Color[]         _colors;

        HatchBrush      _brushChoose;
        int             _partTotalID   = 0;
        int             _lastViewPoint = 0;
        int             _colorID       = 0;
        int             _resolution = 100;

        public SoundEditor(Control parent)
        {
            this.Parent = parent;
            InitializeComponent();
            SrcPic.Init(parent);
            ResultPic.Init(parent);
            // pixels per second
            ToolButton100MS.Tag = 1000;
            ToolButton1S.Tag = 100;
            ToolButton10S.Tag = 10;
            initPanels();
            SrcPic.Location = new Point(8, 2);
            ResultPic.Location = new Point(8, 2);
            SrcPic.RememberEvent += new EventHandler(OnRememberEvent);
            ResultPic.RememberEvent += new EventHandler(OnRememberEvent);
            SrcPic.SaveEvent += new EventHandler(Pic_SaveEvent);
            ResultPic.SaveEvent += new EventHandler(Pic_SaveEvent);
            ResultPic.Name = "";
            _colors = new Color[] { Color.Violet, Color.LimeGreen, Color.Blue, Color.Orange, Color.DarkTurquoise, Color.Red};
            _brushChoose = new HatchBrush(HatchStyle.Percent10, Color.Orange, Color.Transparent);
            _storedParts = new List<WavePanel>();
        }

        void Pic_SaveEvent(object sender, EventArgs e)
        {
            if (SaveEvent != null)
            {
                WavePanel pnl = (WavePanel)sender;
                SaveEvent(this, new SaveWavEventArgs(pnl.Name, pnl.GetSelectedWave()));
            }
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
            ResultPic.Height = SrcPic.Height = SrcPanel.Height - 27;
            PartsPanel.Top = SrcPanel.Top + SrcPanel.Height + 6;
            ResultPanel.Top = PartsPanel.Top + PartsPanel.Height + 6;
            ToolButton100MS.Width = ToolButton1S.Width = ToolButton10S.Width = (this.Parent.Width - 8) / 5;
            PartsPanel.DragDrop += new DragEventHandler(PartsPanel_DragDrop);

            //SrcPanel.MouseWheel  += new MouseEventHandler(SrcPanel_MouseWheel);
            //SrcPanel.MouseWheel += new MouseEventHandler(SrcPanel_MouseWheel);
            //this.MouseWheel += new MouseEventHandler(SrcPanel_MouseWheel);
           // button1.MouseWheel += new MouseEventHandler(SrcPanel_MouseWheel);
        }

        void PartsPanel_DragDrop(object sender, DragEventArgs e)
        {
            DragDropWaveArgs args = (DragDropWaveArgs)e.Data.GetData("Voice.Visual.DragDropWaveArgs");
            addPart(args.bytes, args.color, PartsPanel.PointToClient(Control.MousePosition).X, "name0");
        }

        public void ShowAmplitudes(byte []bytes, string name)
        {
            SrcPic.Name = name;
            SrcPic.Color = _colors[_colorID]; 
            SrcPic.SetWave(bytes, true);
            _colorID = (_colorID + 1) % _colors.Length;
        }

        private int getPartIndex(int xLoc)
        {
            if (xLoc >= 0)
            {
                for (int i = 0; i < _storedParts.Count; i++)
                {
                    if (xLoc <= _storedParts[i].Left)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void addPart(byte[] bytes, Color color, string name)
        {
            addPart(bytes, color, -1, name);
        }

        private void addPart(byte []bytes, Color color, int x, string name)
        {
            int idx = getPartIndex(x);
            int lastPos = (idx >= 0) ? _storedParts[idx].Left - 8 : 
                                        (_storedParts.Count > 0) ?
                                         _storedParts[_storedParts.Count - 1].Location.X + 
                                         _storedParts[_storedParts.Count - 1].Width : 0;
            WavePanel part = new WavePanel();
            part.Name = "";
            part.Init(this);
            part.Color = color;
            part.Location = new Point(lastPos + 8, 3);
            part.Height = SrcPanel.Height - 27;
            part.Parent = PartsPanel;
            part.Tag = _storedParts.Count;
            part.RememberEvent += new EventHandler(OnRememberEvent);
            part.DeleteEvent += new EventHandler(part_DeleteEvent);
            part.SaveEvent += new EventHandler(Pic_SaveEvent);
            part.BringToFront();
            part.Resolution = _resolution;
            part.SetWave(bytes, false);
            part.SizeChanged += new EventHandler(part_SizeChanged);
            PartsPanel.Refresh();

            if (idx >= 0)
            {
                _storedParts.Insert(idx, part);
            }
            else
            {
                _storedParts.Add(part);
            }
            updatePartsView();
            info1.Visible = false;
            info2.Visible = false;
        }

        void updatePartsView()
        {
            for (int i = 0; i < _storedParts.Count; i++)
            {
                WavePanel wp = _storedParts[i];
                wp.Tag = i;
                if (i > 0)
                {
                    WavePanel wpPrev = _storedParts[i - 1];
                    wp.Left = wpPrev.Left + wpPrev.Width + 8;
                }
                else
                {
                    wp.Left = 8;
                }
            }
            PartsPanel.Refresh();
        }

        void part_DeleteEvent(object sender, EventArgs e)
        {
            WavePanel part = (WavePanel)sender;
            _storedParts.Remove(part);
            if (_storedParts.Count == 0)
            {
                info1.Visible = true;
                info2.Visible = true;
            }
            updatePartsView();
            part.Dispose();
        }

        public void OnRememberEvent(object sender, EventArgs e)
        {
            WavePanel pnl = (WavePanel)sender;
            addPart(pnl.GetSelectedWave(), pnl.Color, pnl.Name);
        }

        void part_SizeChanged(object sender, EventArgs e)
        {
            WavePanel part = (WavePanel)sender;
            for (int i = (int)(part.Tag); i < _storedParts.Count; i++)
            {
                if (i > 0)
                {
                    WavePanel wp = _storedParts[i];
                    WavePanel wpPrev = _storedParts[i - 1];
                    wp.Left = wpPrev.Left + wpPrev.Width + 6;
                }
            }
            PartsPanel.Refresh();
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

            _resolution = (int)tsb.Tag;
            setNewResolutionToAll();
        }

        private void setNewResolutionToAll()
        {
            ResultPic.Resolution = _resolution;
            SrcPic.Resolution = _resolution;
            foreach (WavePanel pnl in _storedParts)
            {
                pnl.Resolution = _resolution;
            }
            updatePartsView();
        }

        private void ListenEditToolButton_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            tsb.Checked = true;
            /*if ((WavePanelState)tsb.Tag != wavePanel1.State)
            {
                wavePanel1.State = (WavePanelState)tsb.Tag;
            }*/
        }

        private void ResultPanel_DragDrop(object sender, DragEventArgs e)
        {
            DragDropWaveArgs args = (DragDropWaveArgs)e.Data.GetData("Voice.Visual.DragDropWaveArgs");
            ResultPic.AddWavePart(args.bytes, (ResultPanel.PointToClient(Control.MousePosition)).X < ResultPic.Left ? 0 : -1);
            //if()
            //MessageBox.Show(e.Data.ToString() + "olala");
        }

        private void ResultPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect= DragDropEffects.Move | DragDropEffects.Copy;
        }

        private void wavePanel1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void ResultPanel_Layout(object sender, LayoutEventArgs e)
        {
            //this.Width = ResultPic.Width + 20;
        }

    }

    public struct SaveWavInfo
    {
        public byte[] bytes;
        public string name;
    }

    public class SaveWavEventArgs : EventArgs
    {
        public SaveWavInfo wavInfo;
        public SaveWavEventArgs(string name, byte[] bytes)
        {
            wavInfo.bytes = bytes;
            wavInfo.name = name;
        }
    }

    public delegate void SaveWavDelegate(object sender, SaveWavEventArgs e);
}
