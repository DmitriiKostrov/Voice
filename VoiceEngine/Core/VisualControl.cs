using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;

namespace VoiceEngine.Core
{
    public enum VisualControlState
    {
        Stoppped,
        Played,
        Paused
    }

    public class VisualControl : UserControl
    {
        protected Profile _profile;
        protected Form _parent;
        protected Object _lock = new Object();
        public VisualControlState State = VisualControlState.Stoppped;
        public event Action ProcessStopped = null;



        public Form VisualParentForm{get{return _parent;}}

        public VisualControl() { }

        protected void onProcessed()
        {
            if (ProcessStopped != null)
            {
                ProcessStopped();
            }
        }

        virtual public void Init(Profile profile, Form parent)
        {
            _profile = profile;
            _parent = parent;
        }

        virtual public void Play()
        {
            State = VisualControlState.Played;
        }

        virtual public void Stop()
        {
            State = VisualControlState.Stoppped;
        }

        virtual public void Pause()
        {
            State = VisualControlState.Paused;
        }


        virtual public Panel[] GetEffectsPanels()
        {
            return new Panel[] { };
        }

        virtual public void BeforeProfileFormLoad()
        {
            this.Stop();
            this.Enabled = false;
        }

        virtual public void AfterProfileFormLoad()
        {
            this.Enabled = true;
        }

        virtual public void OnEffectsEvent(object sender, EffectsEventArgs e)
        {
        }

        virtual public string[] GetSpecificSoundTypes()
        {
            return new string []{ };
        }

        virtual public void OpenFile()
        {
        }

        virtual public void OnClose()
        {
            
        }

        virtual public void ShowHelp()
        {
            
        }
    }
}
