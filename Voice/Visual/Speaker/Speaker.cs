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
using Voice.Visual;
using VoiceEngine.Core;
using System.Drawing.Drawing2D;
using System.IO;

namespace Voice.Visual
{
    public partial class Speaker : VisualControl
    {
        private MediaProcessor _processor;
        private FaceControl _faceControl;
        public Button []_faceElems;
        private VoiceMediaOutput _voiceOutput;
        private Configer _conf;
        List<EditableButton> _editableButtons;

        #region Init
        public Speaker(){}

        override public void Init(Profile profile, Form parent)
        {
            base.Init(profile, parent);
            InitializeComponent();
            _conf = new Configer();
            initEditableButtons();
            initSpeaker();
            NervesTrack.Value = (new Random()).Next(7, 27);
            NervesTrackBar_ValueChanged(null, 0);
        }

        public void _processor_Processed()
        {
            onProcessed();
        }

        private void initEditableButtons()
        {
            _editableButtons = new List<EditableButton>();
            EditableButton[] bt = new EditableButton[] { tooth1, tooth2, tooth3, tooth4 };
            foreach (EditableButton b in bt)
            {
                b.Tag = 0;
                b.LocationChanged += new EventHandler(ToothMoved);
                b.SizeChanged += new EventHandler(ToothMoved);
                b.Colors = new Color[] { Color.Gold, Color.Silver, Color.White };
            }
            _editableButtons.AddRange(bt); 
            LeftEyeCenter.BorderColor = true;
            RightEyeCenter.BorderColor = true;
            bt = new EditableButton[] { ButtonEyeLeft, ButtonEyeRight, RightEyeCenter, LeftEyeCenter };
            foreach (EditableButton b in bt)
            {
                b.Colors = new Color[] { Color.Black,Color.White, Color.ForestGreen, Color.LightBlue, Color.Gold,  Color.RosyBrown, 
                                        Color.Red, Color.Chartreuse, Color.DodgerBlue, Color.Magenta, Color.Orange };
            }
            _editableButtons.AddRange(bt);
            bt = new EditableButton[] {hair1, hair2, hair3, hair4, hair5, hair6, hair7, hair8, hair9, hair10};
            Random rnd = new Random();
            foreach (EditableButton b in bt)
            {
                b.Colors = new Color[] { Color.Black, Color.Tan, Color.ForestGreen, Color.LightBlue,
                                        Color.LightPink, Color.Magenta, Color.MediumAquamarine, 
                                        Color.Gold, Color.Fuchsia, Color.Olive, Color.RosyBrown };
                b.SetColor(rnd.Next());
            }
            _editableButtons.AddRange(bt);
            PlayNoseButton.Colors = new Color[] { Color.FromArgb(245, 248, 175), Color.Bisque, Color.Gainsboro, Color.SeaShell, Color.PeachPuff, 
                                                Color.Gold, Color.Honeydew, Color.LightCyan, Color.LightPink};
            MouseButton.Colors = new Color[] { Color.LightCoral, Color.OrangeRed};
            MouseButton.LocationChanged += new EventHandler(MouseButtons_Changed);
            MouseButton.SizeChanged += new EventHandler(MouseButtons_Changed);
            /*MouseButton.Top += rnd.Next(-20, 20);
            MouseButton.Height += rnd.Next(-5, 5);
            tmp = rnd.Next(-20, 20);
            MouseButton.Width += tmp;
            MouseButton.Left -= tmp / 2;*/
            FaceLabel.Colors = new Color[] { Color.FromArgb(245, 248, 175), Color.Bisque, Color.Gainsboro, Color.SeaShell, Color.PeachPuff, 
                                              Color.Gold, Color.Honeydew, Color.LightCyan, Color.LightPink};
            //FaceLabel.Height -= rnd.Next(0, 30);
            //tmp = rnd.Next(0, 200);
            //FaceLabel.Width -= tmp;
            //FaceLabel.Left += tmp / 2;
            _editableButtons.Add(PlayNoseButton);
            _editableButtons.Add(MouseButton);
            _editableButtons.Add(FaceLabel);
        }

        override public void OnClose()
        {
            _faceControl.StopAnimate();
        }

        public override void OpenFile()
        {
            try
            {
                OpenFileDialog ofDialog = new OpenFileDialog();
                if (ofDialog.ShowDialog() == DialogResult.OK)
                {
                    TextBox.Text = File.ReadAllText(ofDialog.FileName, Encoding.GetEncoding(1251));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to load file text");
            }
        }

        void ToothMoved(object sender, EventArgs e)
        {
            Button tooth = (Button)sender;
            if (Math.Abs(tooth.Top - MouseButton.Top) <=
                Math.Abs(tooth.Top + tooth.Height - MouseButton.Top - MouseButton.Height))
            {
                tooth.Top = MouseButton.Top;
                tooth.Tag = 0;
            }
            else
            {
                tooth.Top = MouseButton.Top + MouseButton.Height - tooth.Height;
                tooth.Tag = 1;
            }
        }

        void MouseButtons_Changed(object sender, EventArgs e)
        {
            moveTeeth();
        }

        void initSpeaker()
        {
            _faceControl = new FaceControl(ButtonEyeLeft, ButtonEyeRight, PlayNoseButton);
            _faceControl.FaceEvent += new FaceEventHandler(OnFaceEvent);
            _faceControl.Nerves = NervesTrack.Value;
            _faceElems = new Button[4];
            _faceElems[0] = ButtonEyeLeft;
            _faceElems[1] = ButtonEyeRight;
            _faceElems[2] = PlayNoseButton;
            _faceElems[3] = MouseButton;
            ButtonEyeLeft.Tag = LeftEyeCenter;
            ButtonEyeRight.Tag = RightEyeCenter;
            initProcessor((Form)_parent);
            _faceControl.StartAnimate();
            embedEyeCenter();
        }

        private void embedEyeCenter()
        {
            //LeftEyeCenter.Parent = ButtonEyeLeft;
            //RightEyeCenter.Parent = ButtonEyeRight;
            LeftEyeCenter.Left = ButtonEyeLeft.Width / 2 + ButtonEyeLeft.Left - LeftEyeCenter.Width / 2;
            LeftEyeCenter.Top = ButtonEyeLeft.Height / 2 + ButtonEyeLeft.Top - LeftEyeCenter.Height / 2;
            RightEyeCenter.Left = ButtonEyeRight.Width / 2 + ButtonEyeRight.Left - RightEyeCenter.Width / 2;
            RightEyeCenter.Top = ButtonEyeRight.Height / 2  + ButtonEyeRight.Top - RightEyeCenter.Height / 2;
        }

        private void unembedEyeCenter()
        {
            LeftEyeCenter.Left = 10;// ButtonEyeLeft.Left + LeftEyeCenter.Left;//+ ButtonEyeLeft.Left - LeftEyeCenter.Width / 2;
            LeftEyeCenter.Top = 10;// ButtonEyeLeft.Top + LeftEyeCenter.Top;//+ ButtonEyeLeft.Top - LeftEyeCenter.Height / 2;
            RightEyeCenter.Left = 10;// ButtonEyeRight.Left + RightEyeCenter.Left; //ButtonEyeRight.Left - RightEyeCenter.Width / 2;
            RightEyeCenter.Top = 10;// ButtonEyeRight.Top + RightEyeCenter.Top;// +ButtonEyeRight.Top - RightEyeCenter.Height / 2;
            //ButtonEyeLeft.Controls.Remove(LeftEyeCenter);
            //ButtonEyeRight.Controls.Remove(RightEyeCenter);
            //ButtonEyeRight.BringToFront();
            //ButtonEyeLeft.BringToFront();
            LeftEyeCenter.Parent = this;
            RightEyeCenter.Parent = this;
            LeftEyeCenter.Visible = true;
            this.Invalidate();
            //this.Controls.Add(LeftEyeCenter);
            //this.Controls.Add(RightEyeCenter);
        }

        private void initProcessor(Form parent)
        {
            _voiceOutput = new VoiceMediaOutput();
            _voiceOutput.Init(this, _conf);
            FaceMediaOutput face = new FaceMediaOutput();
            face.Init(this, _conf);
            face.FaceEvent += new FaceEventHandler(OnFaceEvent);
            List<MediaOutput> outs = new List<MediaOutput>();
            outs.Add(_voiceOutput);
            outs.Add(face);
            _processor = new MediaProcessor(_profile, outs, _conf);
            _processor.Processed += new Action(_processor_Processed);
        }
        #endregion

        override public void Play()
        {
            if (string.IsNullOrEmpty(_processor.Text))
            {
                _processor.Text = (string.IsNullOrEmpty(TextBox.SelectedText)) ? TextBox.Text.ToLower() : TextBox.SelectedText.ToLower();
                if (string.IsNullOrEmpty(_processor.Text))
                {
                    return;
                }
            }
            _processor.startProcess();
            base.Play();
        }

        public override void Pause()
        {
            _processor.stopProcess();
            base.Pause();
        }

        override public void Stop()
        {
            if (_processor.Processing)
            {
                _processor.stopProcess();
                //PlayPauseButton.Image = Resources.media_playback_start;
            }
            _processor.Text = "";
            base.Stop();
        }


        override public void BeforeProfileFormLoad()
        {
            base.BeforeProfileFormLoad();
            _faceControl.StopAnimate();
        }

        override public void AfterProfileFormLoad()
        {
            base.AfterProfileFormLoad();
            _faceControl.StartAnimate();
        }

        override public Panel[] GetEffectsPanels()
        {
            return new Panel[] { SpeakerEffectsPanel };
        }

        //override public string[] GetSpecificSoundTypes()
        //{
        //    return new string[] { "эмоции" };
        //}


        override public void ShowHelp()
        {
            MessageBox.Show( "1. Напишите текст в белом поле \r\n" +
                             "2. Нажмите кнопку Play, чтобы Говорун начал читать его\r\n" +
                             "3. Изменяйте параметры звука на соответствующих панелях конфигурации\r\n" + 
                             "4. Изменяйте внешний вид Говоруна, активировав конструктор\r\n" + 
                             "    на панели конфигурации 'Говорун'\r\n",
                             "Помощь - Говорун");
        }

        public Button GetFaceElemByName(string name)
        {
            for(int i = 0; i < _faceElems.Length; i++)
            {
                if (_faceElems[i].Name == name)
                {
                    return _faceElems[i];
                }
            }
            return null;
        }

        private void ButtonEyeLeft_Click(object sender, EventArgs e)
        {
            _processor.stopProcess();
        }

        private void PlayNoseButton_Click(object sender, EventArgs e)
        {
            _processor.Text = (string.IsNullOrEmpty(TextBox.SelectedText)) ? TextBox.Text.ToLower() : TextBox.SelectedText.ToLower();
            _processor.startProcess();
            //аоеяюиэёаоеяюиэёаоеяюиэёаоеяюиэё
        }

        override public string ToString()
        {
            return "Говорун";
        }


        private void EyeSizing(Button eye)
        {
            int height = eye.Height;
            int y = eye.Location.Y;
            Button subEye = (Button)eye.Tag;
            eye.Height = subEye.Height + 4;
            eye.Location = new Point(eye.Location.X, y + height / 2 - (subEye.Height + 4 )/ 2);
            _parent.Refresh();
            Thread.Sleep(400);
            eye.Height = height;
            eye.Location = new Point(eye.Location.X, y);
            _parent.Refresh();
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            EyeSizing((Button)sender);
        }

        public delegate void AnimateFace(FaceEventArgs e);
        public void OnFaceEvent(object sender, FaceEventArgs e)
        {
            _parent.Invoke(new AnimateFace(animateFace), new object[]{e});
        }

        private void animateFace(FaceEventArgs e)
        {
            //lock (_lock)
            //{
                for (int i = 0; i < e.FaceArgs.Length; i++)
                {
                    for (int j = 0; j < _faceElems.Length; j++)
                    {
                        if (e.FaceArgs[i].name == _faceElems[j].Name)
                        {
                            _faceElems[j].Width = e.FaceArgs[i].width;
                            Control sub = _faceElems[j].Tag == null ? null : (Control)_faceElems[j].Tag;
                            _faceElems[j].Location = new Point(e.FaceArgs[i].x, e.FaceArgs[i].y);
                            if (sub != null && e.FaceArgs[i].height <= sub.Height + 4)
                            {
                                _faceElems[j].Height = sub.Height + 4;
                                _faceElems[j].Top = sub.Top - 2;
                            }
                            else
                            {
                                _faceElems[j].Height = e.FaceArgs[i].height;      
                            }
                            if (e.FaceArgs[i].name == "MouseButton")
                            {
                                manageTeeth();
                            }
                            break;
                        }
                    }
                }
                //this.Refresh();
           // }
        }

        private void manageTeeth()
        {
            showTeeth();
            moveTeeth();
        }

        private void showTeeth()
        {
            showTooth(tooth1);
            showTooth(tooth2);
            showTooth(tooth3);
            showTooth(tooth4);
        }

        private void showTooth(Button tooth)
        {
            tooth.Visible = (   tooth.Left >= MouseButton.Left && 
                                tooth.Left + tooth.Width <= MouseButton.Left + MouseButton.Width);
        }

        private void moveTeeth()
        {
            moveTooth(tooth1);
            moveTooth(tooth2);
            moveTooth(tooth3);
            moveTooth(tooth4);
        }

        private void moveTooth(Button tooth)
        {
            if ((int)tooth.Tag == 0)
            {
                tooth.Top = MouseButton.Top;
            }
            else
            {
                tooth.Top = MouseButton.Top + MouseButton.Height - tooth.Height;
            }
        }

        private void NervesTrackBar_ValueChanged(object sender, decimal value)
        {
            _faceControl.Nerves = NervesTrack.Value;
        }

        override public void OnEffectsEvent(object sender, EffectsEventArgs e)
        {
            lock (_lock)
            {
                _voiceOutput.UpdateSoundConfig(e.effects.SoundEffects.Count > 0, _conf.Update(e.effects));
            }
        }

        private void EditFaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EditFaceCheckBox.Checked)
            {
                Stop();
                _faceControl.StopAnimate();
                ButtonEyeLeft.MouseHover -= new EventHandler(Button_MouseHover);
                ButtonEyeRight.MouseHover -= new EventHandler(Button_MouseHover);
                //unembedEyeCenter();
                foreach (EditableButton eb in _editableButtons)
                {
                    eb.SetEditMode();
                }
                MessageBox.Show("Меняйте волосы, глаза, рот Говоруна\r\n" +
                                "Используйте мышь на конкретном объекте лица\r\n\r\n" + 
                                "Изменить положение: движение мыши с зажатой левой нопкой\r\n" + 
                                "Изменить размер: движение мыши с зажатой правой кнопкой,\r\n" + 
                                "Изменить цвет: движение колесика", "");
            }
            else
            {
                foreach (EditableButton eb in _editableButtons)
                {
                    eb.UnsetEditMode();
                }
                ButtonEyeLeft.MouseHover += new EventHandler(Button_MouseHover);
                ButtonEyeRight.MouseHover += new EventHandler(Button_MouseHover);
                initSpeaker();
                moveTeeth();
                embedEyeCenter();
            }
        }

        private void Face_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            Color c = ((Button)sender).BackColor;
            c = Color.FromArgb((c.R + 7) % 256, (c.G + 7) % 256, (c.B + 7) % 256);
            HatchBrush brush = new HatchBrush(HatchStyle.Percent80, ((Button)sender).BackColor, Color.LightGray);

            Graphics g = e.Graphics;
            g.FillRectangle(brush, 0, 0, ((Button)sender).Width, ((Button)sender).Height);
            g.DrawRectangle(pen, 0, 0, ((Button)sender).Width - 1, ((Button)sender).Height - 1);
        }

        private void Hair_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            HatchBrush brush = new HatchBrush(HatchStyle.Shingle, Color.Brown, ((Button)sender).BackColor);

            Graphics g = e.Graphics;
            g.FillRectangle(brush, 0, 0, ((Button)sender).Width, ((Button)sender).Height);
            g.DrawRectangle(pen, 0, 0, ((Button)sender).Width - 1, ((Button)sender).Height - 1);
        }

        private void NervesTrack_ValueChanged(object sender, decimal value)
        {
            _faceControl.Nerves = NervesTrack.Value; 
        }

    }
}
