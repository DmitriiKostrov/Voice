using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic.Sound;
using System.Threading;
using VoiceEngine.Utils;
using System.Drawing.Drawing2D;

namespace Voice.Visual
{
    public enum WavePanelState
    {
        Edit,
        Listen
    }

    public partial class WavePanel : UserControl
    {
        public volatile bool Playing = false;

        //Thread      _runningThread = null;
        Object          _lock = new Object();
        Image           _img;
        byte[]          _bytes = null;
        MediaPlayer     _player = null;
        int             _resolution = 100;
        WavePanelState  _state = WavePanelState.Edit;
        AudioFrame      _audioFrame;
        List<Label>     _intervalLabels;
        int             _partStart = 0;
        int             _partEnd = 0;
        HatchBrush      _brush;

        System.Windows.Forms.Timer       _timer;

        public WavePanelState State
        {
            get { return _state;}
            set
            {
                if (value == WavePanelState.Edit)
                {
                    setEditState();
                }
                else if (value == WavePanelState.Listen)
                {
                    setListenState();
                }
            }
        }

        public int Resolution
        {
            get { return _resolution; }
            set
            {
                _resolution = value;
                if (_bytes != null)
                {
                    updateWave();
                }
            }
        }

        public Color Color
        {
            set { _audioFrame.Color = value; }
            get { return _audioFrame.Color; }
        }

        public int WaveWidth
        {
            set { this.Width = value + 2;}
        }
        public WavePanel()
        {
            InitializeComponent();
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 10;
            _audioFrame = new AudioFrame(false);
        }

        public void Init(Control parent)
        {
            _player = new MediaPlayer(parent);
            _state = WavePanelState.Listen;
            _intervalLabels = new List<Label>();
            _brush = new HatchBrush(HatchStyle.Percent10, Color.Orange, Color.Transparent);
            //PictureBox.SizeChanged += new EventHandler(PictureBox_SizeChanged);
        }

        void PictureBox_SizeChanged(object sender, EventArgs e)
        {
            this.Size = PictureBox.Size;
        }


        public void SetWave(Image img, byte[] bytes, bool hasHeader)
        {
            _img = img;
            PictureBox.Image = (Image)img.Clone();
            // save bytes with added header
            if (hasHeader)
            {
                _bytes = new byte[bytes.Length];
                Array.Copy(bytes, _bytes, bytes.Length);
            }
            else
            {
                _bytes = AudioUtils.AddAudioHeader(bytes);
            }
            this.Width = img.Width;
            _audioFrame.Process(ref _bytes, true);
        }

        public void SetWave(byte[] bytes, bool hasHeader)
        {
            if (hasHeader)
            {
                _bytes = new byte[bytes.Length];
                Array.Copy(bytes, _bytes, bytes.Length);
            }
            else
            {
                _bytes = AudioUtils.AddAudioHeader(bytes);
            }
            _audioFrame.Process(ref _bytes, true);
            updateWave();
        }

        private void addIntervals()
        {
            foreach (Label l in _intervalLabels)
            {
                l.Dispose();
            }
            _intervalLabels.Clear();
            double step = 100.0 / _audioFrame.Resolution;
            double pos = 0;
            for (int i = 0; i < PictureBox.Width; i += 100)
            {
                Label l = new Label();
                l.Text = pos.ToString();
                l.TextAlign = ContentAlignment.MiddleLeft;
                pos = Math.Round(pos + step, (step > 0.05) ? 1 : 2);
                l.BackColor = Color.White;
                l.Top = PictureBox.Height + PictureBox.Top - 18;
                l.Left = i + PictureBox.Left;
                l.Height = 16;
                l.Width = (i == 0 ? 10 : ((double)i).ToString().Length * 5);
                l.Parent = PictureBox;
                l.BringToFront();
                _intervalLabels.Add(l);
            }
        }

        private void updateWave()
        {
            _audioFrame.Resolution = _resolution;
            this.WaveWidth = _audioFrame.PictureSize;
            _audioFrame.RenderTimeDomain(ref PictureBox);
            _img = (Image)PictureBox.Image.Clone();
            addIntervals();
            this.Refresh();
        }

        private void setMouseEvents()
        {
            PictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            PictureBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            PictureBox.MouseMove -= new MouseEventHandler(PictureBox_MouseMove);
        }

        private void setListenState()
        {
            _timer.Stop();
            PictureBox.MouseDown -= new MouseEventHandler(PictureBox_MouseDownWhenEdit);
            PictureBox.MouseMove -= new MouseEventHandler(PictureBox_MouseMoveWhenEdit);

            PictureBox.MouseClick += new MouseEventHandler(PictureBox_MouseClick);
            _timer.Tick += new EventHandler(_timer_Tick_Listen);
            _state = WavePanelState.Listen;
        }

        private void setEditState()
        {
            _timer.Stop();
            _state = WavePanelState.Edit;
            PictureBox.MouseClick -= new MouseEventHandler(PictureBox_MouseClick);
            _timer.Tick -= new EventHandler(_timer_Tick_Listen);

            PictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDownWhenEdit);
            PictureBox.MouseMove += new MouseEventHandler(PictureBox_MouseMoveWhenEdit);
        }

        void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_player != null && _player.IsPlaying)
                {
                    stopPlay();
                }
                else
                {
                    startPlay();
                }
            }
        }

        void PictureBox_MouseClickToSave(object sender, MouseEventArgs e)
        {
            
        }

        private void PictureBox_MouseDownWhenEdit(object sender, MouseEventArgs e)
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
                    //copyImagePart(_partStart, _partEnd);
                }
                else
                {
                    _partStart = e.X;
                    _partEnd = 0;
                    PictureBox.Image = (Image)_img.Clone();
                    PictureBox.Refresh();
                }
                //MessageBox.Show("Left: " + e.Location.ToString() + ". clicks: " + e.Clicks.ToString());
            }
            else if (e.Button == MouseButtons.Right)
            {
                //MessageBox.Show("Right: " + e.Location.ToString());
                // delete image part
                //PictureBox.Image = (Image)_img.Clone();
                _bytes = AudioUtils.ReverseWave(_bytes);
                _audioFrame.Process(ref _bytes, true);
                updateWave();
            }
        }

        private void PictureBox_MouseMoveWhenEdit(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _img != null)
            {
                PictureBox.Image = (Image)_img.Clone();
                Graphics graph = Graphics.FromImage(PictureBox.Image);

                Pen pen = new Pen(Color.Black);
                _partEnd = e.X;
                int start = (_partStart < e.X) ? _partStart : e.X;
                int end = (_partStart > e.X) ? _partStart : e.X;
                graph.DrawRectangle(pen, start, 0, end - start, PictureBox.Height - 1);
                graph.FillRectangle(_brush, start + 1, 1, end - start - 2, PictureBox.Height - 3);
                PictureBox.Refresh();
                //MainPic.Image = (Image)graph;
            }
        }

        void startPlay()
        {
            //start play and start timer to draw play position\
            label1.Text = "Started";
            _player = new MediaPlayer(this.Parent);
            // start lay from the position of the mouse
             Point loc = PictureBox.PointToClient(Control.MousePosition);
             int wavPos = (int)Math.Round((double)loc.X * ((double)44100 / (double)_resolution * 2)) + AudioUtils.WavHeadSize;
            _player.Play(_bytes, wavPos);
            _timer.Start();
        }

        void stopPlay()
        {
            label1.Text = "Stopped";
            _timer.Stop();
            _player.Stop();
             PictureBox.Image = (Image)_img.Clone();
        }

        void _timer_Tick_Listen(object sender, EventArgs e)
        {
            if(!_player.IsPlaying)
            {
                stopPlay();
            }
            else
            {
                // play position line
                // 44100 by 16 bit. and devide by resolution
                int linePos = (int)Math.Round(((double)_player.PlayPosition - AudioUtils.WavHeadSize) / ((double)44100 * 2/ (double)_resolution));
                Bitmap img = (Bitmap)_img.Clone();
                Graphics g = Graphics.FromImage(img);
                Brush brush =  new HatchBrush(HatchStyle.SolidDiamond, Color.Orange, Color.Transparent);
                Pen pen = new Pen(Color.Black, 1);
                g.DrawRectangle(pen, linePos, 0, 3, img.Height - 1);
                g.FillRectangle(brush, linePos + 1, 1, 2, img.Height - 2);
                //g.DrawLine(pen, linePos, 0, linePos, img.Height);
                g.Dispose();
                PictureBox.Image = img;
                label1.Text = _player.PlayPosition.ToString();
            }
        }

    }
}
