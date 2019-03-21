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
    public struct DragDropWaveArgs
    {
        public byte[] bytes;
        public Color color;
    }

    public partial class WavePanel : UserControl
    {
        public event EventHandler RememberEvent = null;
        public event EventHandler DeleteEvent = null;
        public event EventHandler SaveEvent = null;
        public volatile bool Playing = false;

        //Thread      _runningThread = null;
        Object          _lock = new Object();
        Image           _img;
        byte[]          _bytes = null;
        MediaPlayer     _player = null;
        int             _resolution = 100;
        AudioFrame      _audioFrame;
        List<Label>     _intervalLabels;
        int             _partStart = -1;
        int             _partEnd = -1;
        HatchBrush      _brush;

        System.Windows.Forms.Timer       _timer;

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
            _intervalLabels = new List<Label>();
            _brush = new HatchBrush(HatchStyle.Percent10, Color.Orange, Color.Transparent);
            PictureBox.AllowDrop = true;
            PictureBox.DragDrop += new DragEventHandler(PictureBox_DragDrop);
            setMouseEvents();
            _audioFrame.Color = Color.LimeGreen;
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
            _partStart = _partEnd = -1;
            stopPlay();
            _audioFrame.Process(ref _bytes, true);
            updateWave();
        }

        public byte[] GetSelectedWave()
        {
            // return all wave if nothing is selected.
            if (_partStart != -1 && _partEnd != -1)
            {
                int startWav = (_partStart >= _partEnd ? _partEnd : _partStart);
                int endWav = (_partStart >= _partEnd ? _partStart : _partEnd);
                startWav = getPosInWavBuffer(startWav);
                endWav = getPosInWavBuffer(endWav);
                if (endWav >= _bytes.Length)
                {
                    endWav = _bytes.Length - 1;
                }
                return AudioUtils.GetWavePart(_bytes, startWav, endWav, true);
            }
            else
            {
                return _bytes;
            }
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
                l.Width = ((double)i).ToString().Length * 10;
                l.Parent = PictureBox;
                l.BringToFront();
                _intervalLabels.Add(l);
            }
        }

        private void updateWave()
        {
            _audioFrame.Resolution = _resolution;
            if (_bytes != null)
            {
                this.WaveWidth = _audioFrame.PictureSize;
                _audioFrame.RenderTimeDomain(ref PictureBox);
                _img = (Image)PictureBox.Image.Clone();
                addIntervals();
                this.Refresh();
            }
        }

        private void setMouseEvents()
        {
            PictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            PictureBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            PictureBox.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            PictureBox.DoubleClick += new EventHandler(PictureBox_DoubleClick);
            _timer.Tick += new EventHandler(timer_Tick);
        }

        public void SelectAll()
        {
            PictureBox.Image = (Image)_img.Clone();
            Graphics graph = Graphics.FromImage(PictureBox.Image);

            Pen pen = new Pen(Color.Black);
            _partEnd = PictureBox.Width - 1;
            _partStart = 0;
            int start = _partStart;
            int end = _partEnd;
            graph.DrawRectangle(pen, start, 0, end - start, PictureBox.Height - 1);
            graph.FillRectangle(_brush, start + 1, 1, end - start - 2, PictureBox.Height - 3);
            PictureBox.Refresh();
        }

        public void UnselectAll()
        {
            PictureBox.Image = (Image)_img.Clone();
            _partEnd = _partStart = - 1;
            PictureBox.Refresh();
        }

        private bool isAllSelected()
        {
            return _partStart == 0 && _partEnd == PictureBox.Width - 1;
        }

        void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (_player != null && _player.IsPlaying)
            {
                stopPlay();
            }
            if (_bytes != null)
            {
                if (!isAllSelected())
                {
                    SelectAll();
                }
                else
                {
                    UnselectAll();
                }
            }
        }

        void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _bytes != null)
            {
                if(_partStart != -1 && _partEnd == -1)
                {
                    _partEnd = e.X;
                    if (Math.Abs(_partEnd - _partStart) < 5)
                    {
                        startPlay();
                    }
                    else
                    {
                        // part will be selected and highlighted
                    }
                }
            }
        }

        void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _bytes != null)
            {
                Point pos = PictureBox.PointToClient(Control.MousePosition);
                if (_partStart != -1 && _partEnd != -1 && !(_player != null && _player.IsPlaying))
                {
                    if (!((pos.X >= _partStart && pos.X <= _partEnd) || (pos.X <= _partStart && pos.X >= _partEnd)))
                    {
                        _partStart = _partEnd = -1;
                        PictureBox.Image = (Image)_img.Clone();
                        PictureBox.Refresh();
                    }
                    else
                    {
                        int startWav = (_partStart >= _partEnd ? _partEnd : _partStart);
                        int endWav = (_partStart >= _partEnd ? _partStart : _partEnd);
                        startWav = getPosInWavBuffer(startWav); 
                        endWav = getPosInWavBuffer(endWav);
                        if (endWav >= _bytes.Length)
                        {
                            endWav = _bytes.Length - 1;
                        }
                        //_partStart = _partEnd = -1;
                        //PictureBox.Image = (Image)_img.Clone();
                        //PictureBox.Refresh();
                        DragDropWaveArgs args;
                        args.bytes = AudioUtils.GetWavePart(_bytes, startWav, endWav);
                        args.color = this.Color;
                        PictureBox.DoDragDrop(args, DragDropEffects.Move | DragDropEffects.Copy);
                    }
                }
                else
                {
                    PictureBox.Image = (Image)_img.Clone();
                    PictureBox.Refresh();
                    if (_player != null && _player.IsPlaying)
                    {
                        _partStart = _partEnd = -1;
                        stopPlay();
                    }
                    else if (_partStart == -1)
                    {
                        _partStart = e.X;
                    }
                }
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _img != null && _partStart != -1)
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
            _player = new MediaPlayer(this.Parent);
            // start lay from the position of the mouse
             Point loc = PictureBox.PointToClient(Control.MousePosition);
             int wavPos = getPosInWavBuffer(loc.X);
            _player.Play(_bytes, wavPos);
            _timer.Start();
        }

        void stopPlay()
        {
            _timer.Stop();
            _player.Stop();
            if (_img != null)
            {
                PictureBox.Image = (Image)_img.Clone();
            }
            _partStart = _partEnd = -1;
        }

        void timer_Tick(object sender, EventArgs e)
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
            }
        }

        private void перевернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point pos = PictureBox.PointToClient(Control.MousePosition);
            if(_partStart != -1 && _partEnd != -1 && 
                ((pos.X >= _partStart && pos.X <= _partEnd) || (pos.X <= _partStart && pos.X >= _partEnd)))
            {
                int startWav = (_partStart >= _partEnd ? _partEnd : _partStart);
                int endWav = (_partStart >= _partEnd ? _partStart : _partEnd);
                startWav = getPosInWavBuffer(startWav); 
                endWav = getPosInWavBuffer(endWav);
                if (endWav >= _bytes.Length)
                {
                    endWav = _bytes.Length - 1;
                }
                _bytes = AudioUtils.ReverseWave(_bytes, startWav, endWav);
                _audioFrame.Process(ref _bytes, true);
                updateWave();
            }
            else
            {
                _bytes = AudioUtils.ReverseWave(ref _bytes);
                _audioFrame.Process(ref _bytes, true);
                updateWave();
            }
            _partStart = _partEnd = -1;
        }

        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move | DragDropEffects.Copy;
        }

        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (sender == (object)PictureBox && isAllSelected())
            {
                UnselectAll();
                return;
            }
            // add bytes to the specified position
            DragDropWaveArgs args = (DragDropWaveArgs)e.Data.GetData("Voice.Visual.DragDropWaveArgs");
            Point pos = PictureBox.PointToClient(Control.MousePosition);
            int addTo = (_bytes == null) ? 0 :_bytes.Length;
            if (_bytes != null && pos.X < this.Width - 10)
            {
                addTo = getPosInWavBuffer(pos.X);
            }
            AddWavePart(args.bytes, addTo);
        }

        public void AddWavePart(byte []bytes, int startPos)
        {
            if (startPos == -1)
            {
                startPos = _bytes.Length;
            }
            _bytes = AudioUtils.AddWavePart(_bytes, startPos, bytes);
            _audioFrame.Process(ref _bytes, true);
            _partStart = _partEnd = -1;
            updateWave();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int startWav = (_partStart >= _partEnd ? _partEnd : _partStart);
            int endWav = (_partStart >= _partEnd ? _partStart : _partEnd);
            if (startWav != -1 && endWav != -1)
            {
                startWav = getPosInWavBuffer(startWav);
                if (startWav < AudioUtils.WavHeadSize)
                {
                    startWav = AudioUtils.WavHeadSize;
                }
                endWav = getPosInWavBuffer(endWav);
                if (endWav >= _bytes.Length)
                {
                    endWav = _bytes.Length;
                }
                _bytes = AudioUtils.DeleteWavePart(_bytes, startWav, endWav);
                _audioFrame.Process(ref _bytes, true);
                _partStart = _partEnd = -1;
                updateWave();
            }
            else
            {
                _img = null;
                Bitmap newPic = new Bitmap(100, PictureBox.Height);
                PictureBox.Image = newPic;
                this.Width = 100;
                _intervalLabels.Clear();
                PictureBox.Refresh();
                _bytes = null;
                _partStart = _partEnd = -1;
                //this.Dispose();
                if (DeleteEvent != null)
                {
                    DeleteEvent(this, e);
                }
                // Raise event also here
            }
        }

        private int getPosInWavBuffer(int screenPos)
        {
            return (int)Math.Round((double)screenPos * ((double)44100 / (double)_resolution * 2)) + AudioUtils.WavHeadSize;
        }

        private void запомнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RememberEvent != null)
            {
                RememberEvent(this, e);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SaveEvent != null)
            {
                SaveEvent(this, e);
            }
        }

    }
}
