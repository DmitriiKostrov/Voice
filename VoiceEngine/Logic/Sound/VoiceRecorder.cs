using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Istrib.Sound.Formats;
using Istrib.Sound;

namespace VoiceEngine.Logic.Sound
{
    public class VoiceRecorder
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        private Mp3SoundCapture mp3SoundCapture;

        public VoiceRecorder() 
        {
            mp3SoundCapture = new Mp3SoundCapture();
        }

        public bool recordStart(string wave)
        {
            mp3SoundCapture.CaptureDevice = SoundCaptureDevice.AllAvailable.ElementAt(0);
            mp3SoundCapture.NormalizeVolume = true;
            mp3SoundCapture.OutputType = Mp3SoundCapture.Outputs.Wav;
            mp3SoundCapture.WaveFormat = PcmSoundFormat.Pcm44kHz16bitMono;
            mp3SoundCapture.WaitOnStop = true;
            mp3SoundCapture.Start(wave);
            return true;

        }


        public bool recordStop()
        {
            mp3SoundCapture.Stop();
            return true;
        }

        public bool recordStart1()
        {
           // dxTest();
            //return true;
            int res = 1;
           res = mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
          //  Set Capture time format ms bitspersample "+bitspersample+
           res = mciSendString("set recsound bitspersample 16", "", 0, 0);
           //res = mciSendString("set recsound bitspersample 16 samplespersec 88200 channels 2 bytespersec 88200", "", 0, 0);
           //res = mciSendString("set capture samplespersec 44100", "", 0, 0);
           //res = mciSendString("set capture bitspersample 16", "", 0, 0);
           res = mciSendString("record recsound", "", 0, 0);
           return true;
        
        }

        public bool recordStop1(string wave)
        {
            int res = 1;
            res =  mciSendString(@"save recsound " + wave, "", 0, 0);//D:\progs\vs\Projects\Voice\Voice\bin\record.wav", "", 0, 0);
            res =  mciSendString("close recsound", "", 0, 0);
            //omputer c = new Computer();
           // c.Audio.Stop();
            return true;
        }

     }
}
