using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using VoiceEngine.Logic;
using VoiceEngine.Utils;

namespace VoiceEngine.Core
{
    public class MediaProcessor
    {
        //processed event
        public event Action         Processed = null;
        public volatile bool        Processing = false;
        public volatile string      Text = "";
        public  Profile             Profile;
        private Thread              _runningThread = null;
        private Object              _lock = new Object();
        private string              _loopText = "";
        private List<MediaOutput>   _outputs;
        private Configer            _config;
        private string              [] _specialTypes = null;

        public MediaProcessor(Profile profile, List<MediaOutput> outputs, Configer conf)
        {
            Profile = profile;
            _outputs = outputs;
            _config = conf;
        }

        public MediaProcessor(Profile profile, string[] specialTypes, List<MediaOutput> outputs, Configer conf)
        {
            Profile = profile;
            _outputs = outputs;
            _config = conf;
            _specialTypes = specialTypes;
        }

        public void startProcess()
        {
            startProcess(false);
        }

        public void startProcess(bool loop)
        {
            _loopText = (loop) ? Text : "";
            if (Processing)
            {
                return;
            }
            _runningThread = new Thread(new ThreadStart(process));
            _runningThread.IsBackground = true;
            Processing = true;
            _runningThread.Start();
        }

        public void stopLoop()
        {
            lock (_lock)
            {
                _loopText = "";
            }
        }

        public void stopProcess()
        {
            lock (_lock)
            {
                Processing = false;
            }
        }

        public void stopProcessHard()
        {
            lock (_lock)
            {
                Processing = false;
                for (int j = 0; j < _outputs.Count; j++)
                {
                    _outputs[j].StopOutput();
                }
            }
        }

        private void process()
        {
            int len;
            int lexem = 0;
            string lex = "";

            while(Text.Length > 0)
            //for (int i = 0; i < Text.Length; i++)
            {
                if (!Processing)
                {
                    break;
                }
                // get 2 sound media
                byte[] bytes = null;
                Match m;
                if (_specialTypes != null && (m = Regex.Match(Text, @"\s*(\w+)\s*")).Success)
                {
                    foreach (string s in _specialTypes)
                    {
                        if ((bytes = Profile.GetSpecificSoundMedia(s, m.Groups[1].Value)) != null)
                        {
                            lex = Text;
                            Text = "";
                            break;
                        }
                    }
                }
                if (bytes == null)
                {
                    if (Text.Length > 1 && (bytes = Profile.GetSoundMedia(lex = Text.Substring(0, 2))) != null)
                    {
                        Text = Text.Substring(2);
                    }
                    else
                    {
                        //Configer.Volume -= 100;
                        lex = Text.Substring(0, 1);
                        Text = Text.Substring(1);
                        //get 1 sound media
                        bytes = Profile.GetSoundMedia(lex);
                        //get silence length
                        if (bytes == null)
                        {
                            int s = Chars.SilenceLen(lex);
                            Thread.Sleep(s);
                            continue;
                        }
                        /*if (!Chars.isVowel(lex[0]))
                        {
                            Configer.Volume -= -100;
                        }*/
                    }
                }
                len = (int)(((double)AudioUtils.getMediaSize(bytes) / (double)_config.Freqq) * 1000);
                len -= (int)(0.01 * (double)_config.Diffusionn * (double)len);
                if (_config.Reverse.HasValue && _config.Reverse.Value)
                {
                    bytes = AudioUtils.ReverseWave(ref bytes);
                }
                for(int k = 0; k < _outputs.Count; k++)
                {
                    _outputs[k].StartOutput(lex, bytes, len);
                }
                int r = len / 10;
                int q = len % 10;
                for (int k = 0; k < r; k++)
                {
                    if (!Processing)
                    {
                        for (int j = 0; j < _outputs.Count; j++)
                        {
                            _outputs[j].StopOutput();
                        }
                        break;
                    }
                    Thread.Sleep(10);
                }
                Thread.Sleep(q);
                lexem++;
                if (_loopText != "" && Text.Length == 0)
                {
                    Text = _loopText;
                }
            }
            for (int k = 0; k < _outputs.Count; k++)
            {
                _outputs[k].StartOutput("", null, 0);
            }
            Processing = false;
            if (Processed != null)
            {
                Processed();
            }
        }
    }
}


