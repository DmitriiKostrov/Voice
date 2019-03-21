using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;
using VoiceEngine.Core;
using VoiceEngine.Logic.Sound;

namespace Voice.Visual
{
    class VoiceMediaOutput : MediaOutput
    {
        MediaPlayer _player;

        public VoiceMediaOutput() { }

        override public void Init(VisualControl parent, Configer conf)
        {
            base.Init(parent, conf);
            _player = new MediaPlayer(parent.VisualParentForm, conf);
        }

        override public void StartOutput(string sound, byte[] bytes, int len)
        {
            if (bytes != null)
            {
                _player.Play(bytes);
            }
        }

        override public void StopOutput()
        {
            _player.Stop();
        }

        public void UpdateSoundConfig(bool updateEffects, bool newEffects )
        {
            _player.UpdateSoundConfig(updateEffects, newEffects);
        }
    }
}
