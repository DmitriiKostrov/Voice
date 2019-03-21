using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;
using System.Threading;
using VoiceEngine.Core;

namespace Voice.Visual
{
    public partial class BoomBox : VisualControl
    {
        #region Types
        private struct MusicLine
        {
            public TextBox text;
            public MediaProcessor processor;
            public MusicLine(TextBox t, MediaProcessor p)
            {
                text = t;
                processor = p;
            }
        }

        private enum PlayEnum
        {
            PlayEnum_Empty = 0,
            PlayEnum_StartPlay,
            PlayEnum_StartLoop,
            PlayEnum_StopLoop,
            PlayEnum_StopPlay
        }
        #endregion

        #region Properties
        public bool Looping = true;
        private static int Rows = 12;
        private static int Columns = 24;

        private List<MediaProcessor> _processors;
        private bool _playing = false;
        private int _startPos = 0;
        private int _endPos = 16;
        private List<MusicLine> _musicLines;
        private Configer _conf;
        private int _pos = 0;
        private int _lastMusicBox = -1;
        private Thread  _runningThread = null;
        private Color[] _buttonColors;
        private int _sleep = 100;
        #endregion

        #region Init
        public BoomBox()
        {
             
        }

        override public string ToString()
        {
            return "БумБум";
        }

        override public string[] GetSpecificSoundTypes()
        {
            return new string[] { "музыка" };
        }

        private void initColors()
        {
            //white, green, yellow, orange, red.
            _buttonColors = new Color[] {   Color.White,    Color.FromArgb(189, 233, 154), Color.FromArgb(255, 255, 192), 
                                                            Color.FromArgb(242, 192, 125), Color.FromArgb(243, 166, 139) };
        }

        override public void Init(Profile profile, Form parent)
        {
            base.Init(profile, parent);
            InitializeComponent();
            initColors();
            _conf = new Configer();
            //_processor = new MediaProcessor(_parent, _profile);
            //_processor.Processed += new Action(SetPlayIcon);
            _processors = new List<MediaProcessor>();
            _musicLines = new List<MusicLine>();
            for (int i = 0; i < Rows; i++)
            {
                BoomDataGrid.Rows.Add();
                // init media processors
                VoiceMediaOutput voice = new VoiceMediaOutput();
                voice.Init(this, new Configer());
                List<MediaOutput> outs = new List<MediaOutput>();
                outs.Add(voice);
                List<string> types = Profile.DefaultSpecfifcTypes.ToList();
                types.AddRange(this.GetSpecificSoundTypes());
                MediaProcessor proc = new MediaProcessor(profile, types.ToArray(), outs, _conf);
                TextBox tb = new TextBox();
                tb.BorderStyle = BorderStyle.FixedSingle;
                tb.Parent = this;
                tb.Top = (i + 1)*22 + 6;
                tb.Width = MusicComboBox.Width;
                tb.Left = MusicComboBox.Left;
                tb.Click += new EventHandler(tb_Click);
                tb.TextChanged += new EventHandler(tb_TextChanged);
                tb.DoubleClick += new EventHandler(tb_DoubleClick);
                tb.Tag = i;
                MusicLine ml = new MusicLine(tb, proc);
                _musicLines.Add(ml);
                _processors.Add(proc);
            }
            Label l = new Label();
            l.Text = "Звуки Звуки Звуки Звуки Звуки";
            l.Parent = this;
            l.Top = (Rows + 1)* 22 + 6;
            l.Left = MusicComboBox.Left + 10;
            l.Width = MusicComboBox.Width;
            l.BorderStyle = BorderStyle.None;
            l.BackColor = Color.FromArgb(255, 255, 192);
            BoomDataGrid.Height = Rows * 25 + 10;
            this.Height = Rows * 25 + 12;

            for (int i = 0; i < Columns; i++)
            {
                int n = BoomDataGrid.Columns.Count;
                DataGridViewTextBoxColumn C1 = new DataGridViewTextBoxColumn();
                C1.Name = n.ToString();
                //C1.State == n.ToString();
                //C1.FlatStyle = FlatStyle.System;
                C1.ReadOnly = true;
                C1.CellTemplate.Style.BackColor = Color.White;

                C1.Width = 25;
                BoomDataGrid.Columns.Add(C1);//"Frame" + n.ToString(), n.ToString());
//                BoomDataGrid.Columns[n].Width = 25;
                for (int j = 0; j < Rows; j++)
                {
                    BoomDataGrid[i, j].Tag = 0;
                    BoomDataGrid[i, j].Style.SelectionBackColor = Color.White;
                    //(DataGridViewButton)BoomDataGrid[i, j].Clik
                }
            }
            //MusicComboBox.Items.AddRange(_profile.GetSpecificSoundsByType("музыка"));
        }

        #endregion

        #region Play
        override public void Play()
        {
            if (!_playing)
            {
                _pos = _startPos;
                _runningThread = new Thread(new ThreadStart(playing));
                _runningThread.IsBackground = true;
                _playing = true;
                _runningThread.Start();
            }
        }

        override public void Stop()
        {
            lock (_lock)
            {
                _playing = false;
            }
        }

        private void stopAll()
        {
            for (int i = 0; i < Rows; i++)
            {
                Stop(i);
            }
        }

        private void Play(int x, int y)
        {
            if (BoomDataGrid[x, y].Value != null)
            {
                _processors[y].Text = BoomDataGrid[x, y].Value.ToString();
                _processors[y].startProcess(true);
            }
        }

        private void Stop(int y)
        {
            _processors[y].stopProcessHard();
        }

        private void playing()
        {
            for (int i = _pos; i <= _endPos; i++)
            {
                if (!_playing)
                {
                    stopAll();
                    _pos = i;
                    break;
                }

                for (int j = 0; j < Rows; j++)
                {
                    switch ((PlayEnum)BoomDataGrid[i, j].Tag)
                    {
                        case PlayEnum.PlayEnum_StartLoop:
                            _musicLines[j].processor.stopProcessHard();
                            _musicLines[j].processor.Text = _musicLines[j].text.Text;
                            _musicLines[j].processor.startProcess(true);
                            break;
                        case PlayEnum.PlayEnum_StartPlay:
                            _musicLines[j].processor.stopProcessHard();
                            _musicLines[j].processor.Text = _musicLines[j].text.Text;
                            _musicLines[j].processor.startProcess();
                            break;
                        case PlayEnum.PlayEnum_StopLoop:
                            _musicLines[j].processor.stopLoop();
                            break;
                        case PlayEnum.PlayEnum_StopPlay:
                            _musicLines[j].processor.stopProcessHard();
                            break;
                        default: break;
                    }
                }

                int r = _sleep / 100;
                int q = _sleep % 100;
                for (int k = 0; k < r; k++)
                {
                    if (!_playing)
                    {
                        stopAll();
                        _pos = i;
                        break;
                    }
                    Thread.Sleep(100);
                }
                Thread.Sleep(q);

                if (i == _endPos && Looping)
                {
                    i = _startPos;
                    _pos = i;
                }
            }
        }

        #endregion

        #region Events

        override public void OnEffectsEvent(object sender, EffectsEventArgs e)
        {
            /*lock (_lock)
            {
                _currentRow_conf.Update(e.effects);
                _voiceOutput.UpdateSoundConfig();
            }*/
        }

        void tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            _lastMusicBox = (int)tb.Tag;
            _musicLines[_lastMusicBox].processor.Text = tb.Text;
        }

        void tb_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            _lastMusicBox = (int)tb.Tag;
            if (tb.Text == "" && MusicComboBox.SelectedItem != null)
            {
                tb.Text = MusicComboBox.SelectedItem.ToString();
                _musicLines[_lastMusicBox].processor.Text = tb.Text;
            }
        }

        private void BoomBox_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                MusicComboBox.Items.Clear();
                MusicComboBox.Items.AddRange(_profile.GetSpecificSoundsByType("музыка"));
            }
        }

        private void MusicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lastMusicBox > -1 && MusicComboBox.SelectedItem != null)
            {
                _musicLines[_lastMusicBox].text.Text = MusicComboBox.SelectedItem.ToString();
                _musicLines[_lastMusicBox].processor.Text = MusicComboBox.SelectedItem.ToString();
            }
        }

        private void BoomDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int y = e.RowIndex;
            int x = e.ColumnIndex;
            if (e.Button == MouseButtons.Right)
            {
                // set white color for the right click
                BoomDataGrid[x, y].Tag = _buttonColors.Length - 1;
            }
            if (x > 0 && y >= 0)
            {

                BoomDataGrid[x, y].Tag = ((int)(BoomDataGrid[x, y].Tag) + 1) % _buttonColors.Length;
                BoomDataGrid[x, y].Style.BackColor = _buttonColors[(int)(BoomDataGrid[x, y].Tag)];
                BoomDataGrid[x, y].Style.SelectionBackColor = BoomDataGrid[x, y].Style.BackColor;
            }
        }

        private void BoomDataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BoomDataGrid.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = _buttonColors[1];
        }

        void tb_DoubleClick(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            _lastMusicBox = (int)tb.Tag;
            if (tb.Text != "" && MusicComboBox.SelectedItem != null)
            {
                _musicLines[_lastMusicBox].processor.Text = tb.Text;
                _musicLines[_lastMusicBox].processor.startProcess();
            }
        }

        #endregion
    }
}
