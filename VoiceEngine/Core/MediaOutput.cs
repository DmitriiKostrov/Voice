using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;

namespace VoiceEngine.Core
{
    public class MediaOutput
    {
        protected VisualControl _parent;
        protected int _len;
        protected string _sound;
        protected Configer _config;

        public Configer Config
        {
            set { _config = value; }
            get { return _config; }
        }

        public MediaOutput() { }

        virtual public void Init(VisualControl parent, Configer conf)
        {
            _parent = parent;
            _config = conf;
        }

        virtual public void StartOutput(string sound, byte[] bytes, int len)
        {
            _sound = sound;
            _len = len;
        }

        virtual public void StopOutput()
        {

        }
    }
}
