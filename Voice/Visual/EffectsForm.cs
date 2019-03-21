using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;

namespace Voice.Visual
{

    public partial class EffectsForm : Form
    {
        public static int DefaultTabNum = 2;
        public event EffectsEventHandler EffectsEvent;

        public EffectsForm()
        {
            InitializeComponent();
            
        }

        public void Init()
        {
            NervesTrack.Value = 10;
            SpeedTrack.Value = 20;
            VolumeTrack.Value = 60;
            DiffusionTrack.Value = 30;
        }

        public void DeleteSpecificPanels()
        {
            for (int i = DefaultTabNum; i < SoundControl.TabPages.Count; i++)
            {
                SoundControl.TabPages.Remove(SoundControl.TabPages[i]);
            }
        }

        public void AddSpecificPanel(Panel pan, string name)
        {
            SoundControl.TabPages.Add(name);
            pan.Parent = SoundControl.TabPages[SoundControl.TabPages.Count - 1];
            pan.Dock = DockStyle.Fill;
        }

        private void VolumeTrack_ValueChanged(object sender, decimal value)
        {
            Configer conf = new Configer(null, null, (VolumeTrack.Value - 100) * 20);
            if (EffectsEvent != null)
            {
                EffectsEventArgs args = new EffectsEventArgs(conf);
                EffectsEvent(this, args);
            }
        }

        private void SpeedTrack_ValueChanged(object sender, decimal value)
        {
            Configer conf = new Configer(null, 44100 + SpeedTrack.Value * 400, null);
            if (EffectsEvent != null)
            {
                EffectsEventArgs args = new EffectsEventArgs(conf);
                EffectsEvent(this, args);
            }
        }

        private void DiffusionTrack_ValueChanged(object sender, decimal value)
        {
            Configer conf = new Configer(DiffusionTrack.Value, null, null);
            if (EffectsEvent != null)
            {
                EffectsEventArgs args = new EffectsEventArgs(conf);
                EffectsEvent(this, args);
            }
        }

        private void EchoTrack_ValueChanged(object sender, decimal value)
        {
            Configer conf = new Configer(null, null, null);
            if (EffectsEvent != null)
            {
                conf.SoundEffects[AudioEffects.Echo] = EchoTrack.Value;
                EffectsEventArgs args = new EffectsEventArgs(conf);
                EffectsEvent(this, args);
            }
        }

        private void DistorsnTrack_ValueChanged(object sender, decimal value)
        {
            Configer conf = new Configer(null, null, null);
            if (EffectsEvent != null)
            {
                conf.SoundEffects[AudioEffects.Distortion] = DistorsnTrack.Value;
                EffectsEventArgs args = new EffectsEventArgs(conf);
                EffectsEvent(this, args);
            }
        }

        private void ReverbTrack_ValueChanged(object sender, decimal value)
        {
            Configer conf = new Configer(null, null, null);
            if (EffectsEvent != null)
            {
                conf.SoundEffects[AudioEffects.WavesReverb] = ReverbTrack.Value;
                EffectsEventArgs args = new EffectsEventArgs(conf);
                EffectsEvent(this, args);
            }
        }

        private void ChorusTrack_ValueChanged(object sender, decimal value)
        {
            Configer conf = new Configer(null, null, null);
            if (EffectsEvent != null)
            {
                conf.SoundEffects[AudioEffects.Chorus] = ChorusTrack.Value;
                EffectsEventArgs args = new EffectsEventArgs(conf);
                EffectsEvent(this, args);
            }
        }

        private void FlangerTrack_ValueChanged(object sender, decimal value)
        {
            Configer conf = new Configer(null, null, null);
            if (EffectsEvent != null)
            {
                conf.SoundEffects[AudioEffects.Gargle] = FlangerTrack.Value;
                EffectsEventArgs args = new EffectsEventArgs(conf);
                EffectsEvent(this, args);
            }
        }

        private void ReverseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Configer conf = new Configer(null, null, null);
            if (EffectsEvent != null)
            {
                conf.Reverse = ReverseCheckBox.Checked;
                EffectsEventArgs args = new EffectsEventArgs(conf);
                EffectsEvent(this, args);
            }
        }
    }
}
