using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using VoiceEngine.Core;
using VoiceEngine.Logic;
using VoiceEngine.Utils;
using VoiceEngine.Logic.Sound;
using System.IO;
using System.Diagnostics;

namespace Voice.Visual
{
    public partial class VinilControl : VisualControl
    {
        public static double Degree1;
        public static double DefaultRotateSpeed = 5;

        private Configer _conf;

        // Yellow color: 255; 255; 165
        int     _defaultTimerInterval = 50;
        int     _userTimerInterval = 50;
        double  _rotateDegrees = 1;
        double  _rotateSpeed = 0;//DefaultRotateSpeed;
        bool    _highDetailRotation = false;
        Bitmap  _initVinil;
        double  _reaction = 0;

        int     _radius;
        int     _radius2;
        int     _centerPortSize = 5;
        int     _centerPortSize2;
        Point   _center;
        Point   _lastLocation;

        double   _movingRadius2;
        double   _movingRadius;

        List<MediaPlayer> _players;
        List<Button> _soundButtons;
        bool[] _keys;

        MediaPlayer _vinilPlayer = null;
        int _vinilBytesNum = 0;



        public VinilControl()
        { }


        override public string ToString()
        {
            return "Винил";
        }

        override public string[] GetSpecificSoundTypes()
        {
            return new string[] { "музыка" };
        }

        override public void Init(Profile profile, Form parent)
        {
            base.Init(profile, parent);
            InitializeComponent();
            Degree1 = Math.PI / 180;
            timer1.Interval = _defaultTimerInterval;
            _initVinil = (Bitmap)VinilLabel.Image;
            // Vinil image must be fully docked in Label!
            _radius = VinilLabel.Width / 2;
            _radius2 = _radius * _radius;
            _center = new Point(VinilLabel.Width / 2, VinilLabel.Height / 2);
            _centerPortSize2 = _centerPortSize * _centerPortSize;
            _lastLocation = new Point(-1, -1);
            _conf = new Configer();
            initPlayers();
        }


        override public Panel[] GetEffectsPanels()
        {
            return new Panel[] { VinilEffectsPanel };
        }

        override public void Play()
        {
            _rotateSpeed = DefaultRotateSpeed * ((double)_conf.Freqq.Value / (double)44100);
            if (_conf.Reverse.HasValue && _conf.Reverse.Value)
            {
                _rotateSpeed *= -1;
            }
            if (_vinilBytesNum > 0)
            {
                _vinilPlayer = _players[(_rotateSpeed > 0) ? 0 : 1];
                if (State == VisualControlState.Paused)
                {
                    _vinilPlayer.Play(true, -1);
                }
                else
                {
                    _vinilPlayer.Play();
                }
            }
            timer1.Start();
            base.Play();
        }

        override public void Pause()
        {
            timer1.Stop();
            if (_vinilPlayer != null)
            {
                _vinilPlayer.Stop();
            }
            base.Pause();
        }

        override public void Stop()
        {
            timer1.Stop();
            _players[1].Stop();
            _players[0].Stop();
            _vinilPlayer = null;
            base.Stop();
        }

        override public void OpenFile()
        {
            try
            {
                OpenFileDialog ofDialog = new OpenFileDialog();
                ofDialog.Filter = "mp3 файлы|*.mp3";
                if (ofDialog.ShowDialog() == DialogResult.OK)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = Path.Combine(Configer.StartFolder, "lame.exe");
                    p.StartInfo.Arguments = "--decode \"" + ofDialog.FileName + "\"";
                    p.Start();
                    p.WaitForExit();

                    if (_vinilPlayer != null)
                    {
                        _vinilPlayer.Stop();
                    }
                    byte[] bytes = File.ReadAllBytes(ofDialog.FileName + ".wav");
                    bytes = AudioUtils.JoinChannels(ref bytes);
                    /*_players[0].SetBuffer(bytes);
                    _players[1].SetBuffer(AudioUtils.ReverseWave(ref bytes));
                    _vinilBytesNum = bytes.Length;*/
                    _profile.AddSound("музыка", ".mp3", bytes);
                    VinilCombo.SelectedIndex = VinilCombo.Items.Add(".mp3");
                    File.Delete(ofDialog.FileName + ".wav");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to load sound file");
            }
        }


        override public void OnEffectsEvent(object sender, EffectsEventArgs e)
        {
            lock (_lock)
            {
                bool newEffects = _conf.Update(e.effects);
                foreach (MediaPlayer pl in _players)
                {
                    pl.UpdateSoundConfig(e.effects.SoundEffects.Count > 0, newEffects);
                }
               // _players[0].UpdateSoundConfig(e.effects.SoundEffects.Count > 0, newEffects);
                //_players[1].UpdateSoundConfig(e.effects.SoundEffects.Count > 0, newEffects);
                _rotateSpeed = DefaultRotateSpeed * ((double)_conf.Freqq.Value / (double)44100) * (_rotateSpeed > 0 ? 1 : -1);
                if (e.effects.Reverse.HasValue && e.effects.Reverse.Value ^ (_rotateSpeed < 0))
                {
                    _rotateSpeed *= -1;
                    if (_vinilPlayer != null && _vinilPlayer.IsPlaying)
                    {
                        _vinilPlayer.Stop();
                        int pos = _vinilBytesNum - _vinilPlayer.Pos - 1;
                        _vinilPlayer = _players[((int)_vinilPlayer.Tag + 1) % 2];
                        _vinilPlayer.Play(true, pos);
                    }
                }
            }
        }

        override public void ShowHelp()
        {
            MessageBox.Show( "1. Загрузите mp3 из меню Файл или \r\n" + 
                             "    выберите звук на панели конфигурации 'Винил'\r\n" +
                             "2. Нажмите кнопку Play, чтобы начать воспроизведение\r\n" +
                             "3. Изменяйте параметры звука на соответствующих панелях конфигурации\r\n" +
                             "4. Вращайте пластинку мышкой для получения эффектов винила\r\n" +
                             "5. Уменьшите значение 'Отдача', если ваш компьютер не успевает\r\n" +
                             "    своевременно обрабатывать манипуляции с пластинкой\r\n" +
                             "6. Используйте цифры 1-5 на клавиатуре или клик мышкой\r\n" +
                             "    для проигрыша звуков на соответствующих кнопках\r\n" +
                             "7. Звуки на кнопки можно выставить в меню конфигурации 'Винил'\r\n" +
                             "8. Новые звуки можно записать через раздел Профиля - музыка",
                             "Помощь - Винил"); 
        }

        private void initPlayers()
        {
            // 1 main player and 5 players for buttons. 
            _players = new List<MediaPlayer>();
            for (int i = 0; i < 7; i++)
            {
                MediaPlayer pl = new MediaPlayer(this._parent,  _conf);
                pl.Tag = i;
                _players.Add(pl);
            }
            _soundButtons = new List<Button>();

            _soundButtons.Add(buttonS1);
            _soundButtons.Add(buttonS2);
            _soundButtons.Add(buttonS3);
            _soundButtons.Add(buttonS4);
            _soundButtons.Add(buttonS5);
            for (int i = 0; i < _soundButtons.Count; i++)
            {
                _soundButtons[i].Tag = i + 2;
                _soundButtons[i].Click += new EventHandler(VinilControl_Click);
            }
            
            _keys = new bool[] { false, false, false, false, false };
            ComboBox[] boxes = new ComboBox[] { ButtonCombo1, ButtonCombo2, ButtonCombo3, ButtonCombo4, ButtonCombo5 };
            fillCombos();
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Tag = i + 2;
                boxes[i].SelectedIndexChanged += new EventHandler(ButtonCombo_SelectedIndexChanged);
                boxes[i].TextChanged += new EventHandler(ButtonCombo_SelectedTextChanged);
                if (boxes[i].Items.Count > i + 1)
                {
                    boxes[i].SelectedIndex = i + 1;
                }
            }
            if (VinilCombo.Items.Count > 0)
            {
                VinilCombo.SelectedIndex = 0;
                VinilCombo.SelectedText = VinilCombo.SelectedItem.ToString();
            }
        }

        void VinilControl_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MediaPlayer player = _players[(int)btn.Tag];
            if (player.HasSound)
            {
                if (btn.Height == 52)
                {
                    player.Play();
                    btn.Height -= 20;
                    btn.Top += 20;
                }
                else
                {
                    player.Stop();
                    btn.Height += 20;
                    btn.Top -= 20;
                }
            }
        }

        void ButtonCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCombo((ComboBox)sender, false, false);
        }

        void ButtonCombo_SelectedTextChanged(object sender, EventArgs e)
        {
           setPlayerText((ComboBox)sender);
        }

        private void fillCombos()
        {
            fillVinilCombo(VinilCombo);
            fillCombo(ButtonCombo1);
            fillCombo(ButtonCombo2);
            fillCombo(ButtonCombo3);
            fillCombo(ButtonCombo4);
            fillCombo(ButtonCombo5);
        }

        private void fillVinilCombo(ComboBox combo)
        {
            fillCombo(combo, true, true);
        }

        private void fillCombo(ComboBox combo)
        {
            fillCombo(combo, true, false);
        }

        private void fillCombo(ComboBox combo, bool updateItem, bool vinil)
        {
            string name = (combo.SelectedItem == null) ? "" : (string)combo.SelectedItem;
            if (updateItem)
            {
                combo.Items.Clear();
                combo.Items.AddRange(_profile.GetSpecificSoundsByType("музыка"));
                if (combo.Items.Count > 0)
                {
                    if (name != "")
                    {
                        if (combo.Items.IndexOf(name) != -1)
                        {
                            combo.SelectedItem = name;
                        }
                        else
                        {
                            combo.SelectedItem = combo.Items[0];
                        }
                    }
                }
            }
            if (!vinil)
            {
                setPlayer(combo);
            }
        }

        private void setPlayerText(ComboBox combo)
        {
            _players[(int)combo.Tag].SetBuffer(_profile.GetSoundMedia(combo.Text));
        }

        private void setPlayer(ComboBox combo)
        {
            string name = (combo.SelectedItem == null) ? "" : (string)combo.SelectedItem;
            if (name != "")
            {
                bool played = _players[(int)combo.Tag].IsPlaying ;
                _players[(int)combo.Tag].Stop();
                _players[(int)combo.Tag].SetBuffer(_profile.GetSpecificSoundMedia("музыка", name));
                if( played)
                {
                    _players[(int)combo.Tag].Play();
                }
            }
            else if(combo.Tag != null)
            {
                _players[(int)combo.Tag].Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_lastLocation.X == -1)
            {
                updateRotateDegrees(_rotateSpeed);
                VinilLabel.Image = ImageUtils.RotateImage(_initVinil, (float)_rotateDegrees, _highDetailRotation);
            }
            else
            {
                scratchVinil();
            }
        }

        #region Vinil scratching

        private void updateRotateDegrees(double angle)
        {
            _rotateDegrees += angle;
            if (_rotateDegrees > 360)
                _rotateDegrees -= 360;
            else if (_rotateDegrees > 360)
                _rotateDegrees += 360;
        }

        private bool isInsideVinil(Point p)
        {
            // compute center distance
            int d2 = (p.X - _center.X) * (p.X - _center.X) + (p.Y - _center.Y) * (p.Y - _center.Y);
            // note: there is small port in the center of the vinil :-)
            return (d2 < _radius2 && d2 > _centerPortSize2);
        }

        private void scratchVinil()
        {
            Point newLocation = VinilLabel.PointToClient(Control.MousePosition);
            if (false)// && (newLocation.X < 0 || newLocation.Y < 0 || !isInsideVinil(newLocation)))
            {
                _lastLocation = new Point(-1, -1);
                timer1.Interval = _defaultTimerInterval;
            }
            else
            {
                // user will move mouse every where he want.
                // really he is able to move vinil on circle way only.
                // so put mouse on the initial circle.
                // find intersection of circle and line from user point to vinil center for that.
                // use system coordinates starting from the center of vinil.
                // line is: y = _k*x.
                // circle is: x^2 + y^2 = _movingRadius2;
                // x, y from newLocation.
                // x^2 * (1 + _k^2) = _movingRadius2;
                // x = sqrt(_movingRadius2 / (1 + _k^2));
                int y = newLocation.Y - _center.Y;
                int x = newLocation.X - _center.X;
                int nx;
                int ny;
                // process supreme cases
                if(x == 0)
                {
                    nx = x;
                    ny = (int)Math.Round(_movingRadius) * Math.Sign(y);
                }
                else if(y == 0)
                {
                    ny = y;
                    nx = (int)Math.Round(_movingRadius) * Math.Sign(x);
                }
                else
                {
                    double k = (double)(y) / (double)(x);
                    double dx = Math.Sqrt(_movingRadius2 / (1 + k * k)) * Math.Sign(x);
                    nx = (int)Math.Round(dx);
                    ny = (int)Math.Round(dx * k);
                }

                // count rotate angle.
                int lx = _lastLocation.X - _center.X;
                int ly = _lastLocation.Y - _center.Y;
                if (ly == ny)
                {
                    nx = lx;
                    if (_vinilPlayer != null)
                    {
                        _vinilPlayer.Stop();
                    }
                    return;
                }
                double angleRadianse = Math.Asin(Math.Sqrt((lx - nx) * (lx - nx) + (ly - ny) * (ly - ny)) / (double)(2 * _movingRadius));
                // 2 degree min rotation available. hoho.
                if (angleRadianse < Degree1 * _reaction)
                {
                    return;
                }
                if((ny <= 0 && ly >= 0 && nx <= 0) || (ny >= 0 && ly <= 0 && nx >= 0) || (ny >= 0 && nx < lx) || (ny <= 0 && nx > lx))
                {
                }
                else if(angleRadianse != 0)
                {
                    angleRadianse = -angleRadianse;
                    //MessageBox.Show(string.Format("fuck! {0}", angleRadianse.ToString()));
                }
                double grad = (angleRadianse * (double)(180 * 2)) / Math.PI;
                if (_vinilPlayer != null)
                {
                    int freq = (int)(((grad * (double)_defaultTimerInterval) / ((double)_userTimerInterval * (double)_rotateSpeed)) * _conf.Freqq);
                    freq = Math.Abs(freq);
                    freq = freq - (freq % 1000) + 100;
                    _players[0].Freq = freq;
                    _players[1].Freq = freq;
                    int pos = _vinilPlayer.Pos;
                    // get valid player and play position
                    if (angleRadianse > 0 && _players[0] != _vinilPlayer)
                    {
                        _vinilPlayer.Stop();
                        _vinilPlayer = _players[0];
                        pos = _vinilBytesNum - _players[1].Pos - 1;
                    }
                    else if (angleRadianse < 0 && _players[1] != _vinilPlayer)
                    {
                        _vinilPlayer.Stop();
                        _vinilPlayer = _players[1];
                        pos = _vinilBytesNum - _players[0].Pos - 1;
                    }
                    if (!_vinilPlayer.IsPlaying)
                        _vinilPlayer.Play(true, pos);
                }
                // we can find half angle sin by dividing radius on the half size of the line between the points.
                // then obtain arcsin and multiply by 2 to have resulting angle
                updateRotateDegrees(grad);
                VinilLabel.Image = ImageUtils.RotateImage(_initVinil, _rotateDegrees, _highDetailRotation);
                _lastLocation = new Point(nx + _center.X, ny + _center.Y);
                Cursor.Position = VinilLabel.PointToScreen(new Point(nx + _center.X, ny + _center.Y));
            }
            //Cursor.Position = new Point(Control.MousePosition.X + 30, Control.MousePosition.Y + 30);// VinilLabel.PointToScreen(new Point(newLocation.X + 30, newLocation.Y + 30));
            //MessageBox.Show(local.ToString());
        }
        #endregion

        private void VinilLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isInsideVinil(e.Location))
                {
                    _lastLocation = e.Location;
                    timer1.Interval = _userTimerInterval;
                    int y = e.Location.Y - _center.Y;
                    int x = e.Location.X - _center.X;
                    // compute R^2 and R
                    _movingRadius2 = y * y + x * x;
                    _movingRadius = Math.Sqrt(_movingRadius2);
                }
            }
        }

        private void VinilLabel_MouseUp(object sender, MouseEventArgs e)
        {
            _lastLocation = new Point(-1, -1);
            timer1.Interval = _defaultTimerInterval;
            if (_vinilPlayer != null)
            {
                _vinilPlayer.Stop();
            }
            _players[0].Freq = (_conf.Freqq == null) ? 44100 : _conf.Freqq.Value;
            _players[1].Freq = (_conf.Freqq == null) ? 44100 : _conf.Freqq.Value;
            if (timer1.Enabled)
            {
                _rotateSpeed = DefaultRotateSpeed * ((double)_conf.Freqq.Value / (double)44100);
                if (_conf.Reverse.HasValue && _conf.Reverse.Value)
                {
                    _rotateSpeed *= -1;
                }
                if (_vinilBytesNum > 0)
                {
                    _vinilPlayer = _players[(_rotateSpeed > 0) ? 0 : 1];
                    _vinilPlayer.Play(true, -1);
                }
            }
        }

        private void VinilControl_KeyDown(object sender, KeyEventArgs e)
        {
            int code = (int)e.KeyCode - (int)Keys.D0;
            if (code > 0 && code < 6)
            {
                if (!_keys[code - 1])
                {
                    if (_soundButtons[code - 1].Height == 52)
                    {
                        _players[code + 1].Play();
                        _soundButtons[code - 1].Height -= 20;
                        _soundButtons[code - 1].Top += 20;
                    }
                    _keys[code - 1] = true;
                }
            }
        }

        private void VinilControl_EnabledChanged(object sender, EventArgs e)
        {
            fillCombos();
        }

        private void VinilControl_KeyUp(object sender, KeyEventArgs e)
        {
            int code = (int)e.KeyCode - (int)Keys.D0;
            if (code > 0 && code < 6)
            {
                if (_soundButtons[code - 1].Height == 32)
                {
                    _players[code + 1].Stop();
                    _soundButtons[code - 1].Height += 20;
                    _soundButtons[code - 1].Top -= 20;
                }
                _keys[code - 1] = false;
            }
        }

        private void VinilLabel_MouseEnter(object sender, EventArgs e)
        {
            buttonS1.Focus();
        }

        private void VinilCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string name = (combo.SelectedItem == null) ? "" : (string)combo.SelectedItem;
            if (name != "")
            {
                // straight and reverse players
                if (_vinilPlayer != null)
                {
                    _vinilPlayer.Stop();
                }
                byte[] bytes = _profile.GetSpecificSoundMedia("музыка", name);
                _vinilBytesNum = bytes.Length;
                _players[0].SetBuffer(bytes);
                _players[1].SetBuffer(AudioUtils.ReverseWave(ref bytes));
                if (timer1.Enabled)
                {
                    if (_vinilPlayer == null)
                    {
                        _vinilPlayer = _players[(_rotateSpeed > 0) ? 0 : 1];
                    }
                    _vinilPlayer.Play();
                }
            }
            else if(_vinilPlayer != null)
            {
                _vinilPlayer.Stop();
            }
        }

        private void ReactionTrack_ValueChanged(object sender, decimal value)
        {
            lock (_lock)
            {
                _userTimerInterval = 500 / (ReactionTrack.Value + 1);
                _reaction = 10 - (ReactionTrack.Value / 2);
            }
        }

    }
}
