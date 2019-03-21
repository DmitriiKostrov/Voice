using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;
using Buffer = Microsoft.DirectX.DirectSound.Buffer;
using System.Threading;
using VoiceEngine.Core;
using Zвук.Properties;

namespace Voice.Visual
{
    public partial class MainForm : Form
    {
        struct VisualControlInfo
        {
            public int height;
            public int width;
            public VisualControl control;
        }

        volatile Profile _profile;
        private List<VisualControlInfo> _visualControls;
        VisualControl _activeVisualControl;
        private int _widthWithoutEffectsPanel;
        EffectsForm _effectsForm;
        bool _effectHiding = false;
       
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _profile = new Profile();
            Chars.init();
            //_processor = new MediaProcessor(this, _profile);
            //_processor.Processed += new Action(SetPlayIcon);
            _effectsForm = new EffectsForm();
            _effectsForm.Show();
            initVisualControls();
            initMenu();
            updateEffectsPanels();
            _effectsForm.Visible = true;
            _effectHiding = !_effectsForm.Visible;
            _effectsForm.Init();
            Configer.StartFolder = Directory.GetCurrentDirectory();
        }

        private void initVisualControls()
        {

            Speaker sp = new Speaker();
            //BoomBox bb = new BoomBox();
            VinilControl vv = new VinilControl();
            _profile.AddSpecificTypes(vv.GetSpecificSoundTypes());
            Configer.LoadProfile(_profile, "Dima");
            List<VisualControl> cls = new List<VisualControl>();
            cls.Add(sp);
            //cls.Add(bb);
            cls.Add(vv);
            _visualControls = new List<VisualControlInfo>();
            for (int i = 0; i < cls.Count; i++)
            {
                VisualControlInfo vc = new VisualControlInfo();
                vc.control = cls[i];
                _effectsForm.EffectsEvent += new EffectsEventHandler(vc.control.OnEffectsEvent);
                vc.control.Init(_profile, this);
                vc.control.Enabled = false;
                vc.height = cls[i].Height;
                vc.width = cls[i].Width;
                _visualControls.Add(vc);
                vc.control.ProcessStopped += new Action(control_ProcessStopped);
            }
            setNewVisualControl(_visualControls[0]);
        }

        void control_ProcessStopped()
        {
            PlayPauseButton.Image = Resources.media_playback_start;
            _activeVisualControl.State = VisualControlState.Stoppped;
        }

        private void initMenu()
        {
            for (int i = 0; i < _visualControls.Count; i++)
            {
                ToolStripMenuItem subm = new ToolStripMenuItem(_visualControls[i].control.ToString());
                //m1.DropDownItems.Add(subm1);
                режимToolStripMenuItem.DropDownItems.Add(subm);
                subm.Click += new EventHandler(mode_Click);
            }
        }

        protected void mode_Click(object who, EventArgs e)
        {
            ToolStripMenuItem subm = (ToolStripMenuItem)who;
            for (int i = 0; i < _visualControls.Count; i++)
            {
                if (subm.Text == _visualControls[i].control.ToString())
                {
                    setNewVisualControl(_visualControls[i]);
                    break;
                }
            }
        }

        private void setNewVisualControl(VisualControlInfo vc)
        {
            if (_activeVisualControl != null)
            {
                _activeVisualControl.Stop();
                _activeVisualControl.Visible = false;
                _activeVisualControl.Parent = null;
                _activeVisualControl.Enabled = false;
            }
            _activeVisualControl = vc.control;
            _activeVisualControl.Parent = MainPanel;
            _activeVisualControl.Dock = DockStyle.Fill;
            _activeVisualControl.Visible = true;
            _activeVisualControl.Enabled = true;
            this.Text = vc.control.ToString() + " - " + _profile.Name;
                       //this.MaximumSize = new System.Drawing.Size(this.Width, this.Height);
            _widthWithoutEffectsPanel = this.Width;
            //EffectsPanel.Left = this.Width - 14;
            //EffectsPanel.Top = ControlButtonsGroupBox.Top + 7;
            //EffectsPanel.Height = vc.height + MainPanel.Top - EffectsPanel.Top;
            //EffectsPanel.Dele
            MainPanel.Width = vc.width;
            MainPanel.Height = vc.height;
            this.Height = MainPanel.Top + MainPanel.Height  + 28;//vc.height + 121;
            this.Width = MainPanel.Left + MainPanel.Width + 9;//vc.width + 10;
            ControlButtonsGroupBox.Left = (MainPanel.Width - ControlButtonsGroupBox.Width) / 2;
            SetEffectsDefaultLocation();
            updateEffectsPanels();
            this.Refresh();
        }

        private void manageProfiles()
        {
            SamplesForm samples = new SamplesForm(_profile);
            samples.ShowDialog(this);
            this.Text = _activeVisualControl.ToString() + " - " + _profile.Name;
            //_processor.Profile = _profile;
        }

        public VisualControl GetVisualControlByName(string name)
        {
            for (int i = 0; i < _visualControls.Count; i++)
            {
                if (_visualControls[i].control.ToString() == name)
                {
                    return _visualControls[i].control;
                }
            }
            return null;
        }

        private void звукиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeVisualControl.BeforeProfileFormLoad();
            manageProfiles();
            _activeVisualControl.AfterProfileFormLoad();
        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeVisualControl.OpenFile();
        }


        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            PlayPauseButton.Image = (_activeVisualControl.State != VisualControlState.Paused) ? Resources.media_playback_pause : Resources.media_playback_start;
            if (_activeVisualControl.State == VisualControlState.Played)
            {
                _activeVisualControl.Pause();
                PlayPauseButton.Image = Resources.media_playback_start;
            }
            else
            {
                _activeVisualControl.Play();
                PlayPauseButton.Image = Resources.media_playback_pause;
            }
            /*if (!_processor.Processing)
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
                PlayPauseButton.Image = Resources.media_playback_pause;
            }
            else
            {
                _processor.stopProcess();
                PlayPauseButton.Image = Resources.media_playback_start;  
            }*/
        }

        public void SetPlayIcon()
        {
            PlayPauseButton.Image = Resources.media_playback_start;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _activeVisualControl.Stop();
            PlayPauseButton.Image = Resources.media_playback_start;
            /*if (_processor.Processing)
            {
                _processor.stopProcess();
                _processor.Text = "";
                PlayPauseButton.Image = Resources.media_playback_start;
            }*/
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //int width = (this.Width == _widthWithoutEffectsPanel) ? _widthWithoutEffectsPanel + EffectsPanel.Width + 4: _widthWithoutEffectsPanel;
            //this.MaximumSize = new System.Drawing.Size(width, this.Height);
            //this.Width = width;
            SetEffectsDefaultLocation();
            _effectsForm.Visible = !_effectsForm.Visible;
            _effectHiding = !_effectsForm.Visible;
        }

        private void SetEffectsDefaultLocation()
        {
            if (_effectsForm != null)
            {
                _effectsForm.Top = this.Top + 115;
                _effectsForm.Left = this.Left + this.Width + 0;
                //_effectsForm.Height = this.Height - 125;
                _effectsForm.Refresh();
                _effectsForm.BringToFront();
            }
        }

        private void updateEffectsPanels()
        {
            _effectsForm.DeleteSpecificPanels();
            Panel[] panels = _activeVisualControl.GetEffectsPanels();
            for (int i = 0; i < panels.Length; i++)
            {
                _effectsForm.AddSpecificPanel(panels[i], (string)panels[i].Tag);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void EffectsCheckBoxChorus_CheckedChanged(object sender, EventArgs e)
        {
            manageEffects(AudioEffects.Chorus);
        }

        private void checkBoxCompressor_CheckedChanged(object sender, EventArgs e)
        {
            manageEffects(AudioEffects.Compressor);
        }

        private void checkBoxDistortion_CheckedChanged(object sender, EventArgs e)
        {
            manageEffects(AudioEffects.Distortion);
        }

        private void checkBoxEcho_CheckedChanged(object sender, EventArgs e)
        {
            manageEffects(AudioEffects.Echo);
        }

        private void checkBoxFlanger_CheckedChanged(object sender, EventArgs e)
        {
            manageEffects(AudioEffects.Flanger);
        }

        private void I3DLevel2Reverb_CheckedChanged(object sender, EventArgs e)
        {
            manageEffects(AudioEffects.I3DLevel2Reverb);
        }

        private void WavesReverb_CheckedChanged(object sender, EventArgs e)
        {
            manageEffects(AudioEffects.WavesReverb);
        }

        private void checkBoxParamEq_CheckedChanged(object sender, EventArgs e)
        {
            manageEffects(AudioEffects.ParamEq);
        }

        private void manageEffects(AudioEffects eff)
        {
            bool found = false;
            for (int i = 0; i < Configer.Effects.Count; i++)
            {
                if (Configer.Effects[i] == eff)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                Configer.Effects.Remove(eff);
            }
            else
            {
                Configer.Effects.Add(eff);
            }
        }

        private void профильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeVisualControl.BeforeProfileFormLoad();
            manageProfiles();
            _activeVisualControl.AfterProfileFormLoad();
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            SetEffectsDefaultLocation();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            /*if (!_effectHiding)
            {
                _effectsForm.Activate();
            }
            else
            {
                _effectHiding = false;
            }*/

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (VisualControlInfo vc in _visualControls)
            {
                vc.control.OnClose();
            }
        }

        private void EchoTrack_ValueChanged(object sender, decimal value)
        {

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            _activeVisualControl.ShowHelp();
        }

        private void помощьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _activeVisualControl.ShowHelp();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm a = new AboutForm();
            a.Show();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            SetEffectsDefaultLocation();
        }


        private void MainForm_Validated(object sender, EventArgs e)
        {
            SetEffectsDefaultLocation();
        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
            SetEffectsDefaultLocation();
        }

    }
}
