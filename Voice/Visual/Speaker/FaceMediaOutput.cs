using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;
using System.Threading;
using VoiceEngine.Core;

namespace Voice.Visual
{
    class FaceMediaOutput : MediaOutput
    {
        public event FaceEventHandler FaceEvent;
        FaceControlArg _mouseArg;
        FaceControlArg _baseMouseArg;
        Dictionary<char, FaceControlArg> _soundMouseLocation;
        private Thread _runningThread = null;

        public FaceMediaOutput()
        { 
            
        }

        override public void Init(VisualControl parent, Configer conf)
        {
            base.Init(parent, conf);
            Button mouse = ((Speaker)parent).GetFaceElemByName("MouseButton");
            _mouseArg = new FaceControlArg(mouse);
            _baseMouseArg = new FaceControlArg(mouse);
            loadSoundMouseLocations();
        }

        public void loadSoundMouseLocations()
        {
            _soundMouseLocation = new Dictionary<char, FaceControlArg>();
            // add vowels first!
            _soundMouseLocation['и'] = new FaceControlArg(-10, -5, 20, 10, "");
            _soundMouseLocation['о'] = new FaceControlArg(26, -18, -52, 36, "");
            _soundMouseLocation['а'] = new FaceControlArg(18, -18, -32, 32, "");
            _soundMouseLocation['у'] = new FaceControlArg(26, -16, -52, 20, "");
            _soundMouseLocation['е'] = new FaceControlArg(-5, -15, 10, 30, "");
            _soundMouseLocation['ё'] = new FaceControlArg(26, -18, -52, 36, "");
            _soundMouseLocation['э'] = new FaceControlArg(-5, -22, 10, 44, "");
            _soundMouseLocation['я'] = new FaceControlArg(17, -17, -30, 30, "");
            _soundMouseLocation['ю'] = new FaceControlArg(26, -16, -52, 20, "");
            _soundMouseLocation['ы'] = new FaceControlArg(-10, -10, 20, 20, "");

            _soundMouseLocation['б'] = new FaceControlArg(-8, 2, 18, -4, "");
            _soundMouseLocation['в'] = new FaceControlArg(7, 0, -14, 0, "");
            _soundMouseLocation['г'] = new FaceControlArg(-12, -8, 24, 16, "");
            _soundMouseLocation['д'] = new FaceControlArg(-12, -8, 24, 16, "");
            _soundMouseLocation['ж'] = new FaceControlArg(-12, -8, 24, 16, "");
            _soundMouseLocation['з'] = new FaceControlArg(-13, -9, 26, 18, "");
            _soundMouseLocation['к'] = new FaceControlArg(-7, -6, 14, 12, "");
            _soundMouseLocation['л'] = new FaceControlArg(-7, -6, 14, 12, "");
            _soundMouseLocation['м'] = new FaceControlArg(-4, 4, 8, -8, "");
            _soundMouseLocation['н'] = new FaceControlArg(-11, -5, 8, 22, "");
            _soundMouseLocation['п'] = new FaceControlArg(-1, 2, 2, -4, "");
            _soundMouseLocation['р'] = new FaceControlArg(-17, -7, 34, 14, "");
            _soundMouseLocation['с'] = new FaceControlArg(-7, -4, 14, 8, "");
            _soundMouseLocation['т'] = new FaceControlArg(0, -3, 0, 6, "");
            _soundMouseLocation['ф'] = new FaceControlArg(-1, 2, 2, 4, "");
            _soundMouseLocation['х'] = new FaceControlArg(-7, -3, 14, 6, "");
            _soundMouseLocation['ц'] = new FaceControlArg(-3, -2, 6, 4, "");
            _soundMouseLocation['ч'] = new FaceControlArg(-10, -5, 20, 10, "");
            _soundMouseLocation['ш'] = new FaceControlArg(-10, -5, 20, 10, "");
            _soundMouseLocation['щ'] = new FaceControlArg(-10, -3, 20, 8, "");
        }

        override public void StartOutput(string sound, byte[] bytes, int len)
        {
            base.StartOutput(sound, bytes, len);
            _runningThread = new Thread(new ThreadStart(faceSpeak));
            _runningThread.IsBackground = true;
            _runningThread.Start();
        }

        private void faceSpeak()
        {
            FaceControlArg[] args = new FaceControlArg[1];
            try
            {
                FaceControlArg arg = _soundMouseLocation[(_sound.Length > 1) ? _sound[1] : _sound[0]];
                _mouseArg.SetNew(_baseMouseArg, arg);
                args[0] = _mouseArg;
            }
            catch
            {
                args[0] = _baseMouseArg;
            }
            FaceEvent(this, new FaceEventArgs(args));
            Thread.Sleep((int)(_len * 0.8));
            args[0] = _baseMouseArg;
            FaceEvent(this, new FaceEventArgs(args));
        }

        override public void StopOutput()
        {

        }
    }
}
