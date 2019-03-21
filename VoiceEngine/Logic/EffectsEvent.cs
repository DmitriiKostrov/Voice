using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoiceEngine.Logic
{

    public class EffectsEventArgs : EventArgs
    {
        public Configer effects;

        public EffectsEventArgs() { }
        public EffectsEventArgs(Configer effs)
        {
            effects = effs;
        }
    }

    public delegate void EffectsEventHandler(object sender, EffectsEventArgs e);
}
