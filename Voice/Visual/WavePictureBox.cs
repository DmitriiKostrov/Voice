using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic.Sound;
using System.Threading;
using System.Drawing;

namespace Voice.Visual
{
    class WavePictureBox : PictureBox
    {
        public byte []Bytes;
        public MediaPlayer Player;
        public int Resolution;
        Form parentForm;
        private Thread _runningThread = null;
        private Object _lock = new Object();
        public volatile bool Playing = false;
        private Image _img;
        
        public WavePictureBox(Form parent)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BorderStyle = BorderStyle.FixedSingle;
            Player = new MediaPlayer(parent);
            parentForm = parent;
        }

        public void SetImage(Image img)
        {
        }

        void SetWave(byte []bytes)
        {
            Bytes = bytes;
        }

        void PlayStart()
        {
            if (Playing)
            {
                PlayStop();
            }
            _runningThread = new Thread(new ThreadStart(Play));
            _runningThread.IsBackground = true;
            Playing = true;
            _runningThread.Start();
        }

        void Play()
        {
            while (Playing)
            {
                
            }
        }

        void PlayStop()
        {
            
        }
    }
}
