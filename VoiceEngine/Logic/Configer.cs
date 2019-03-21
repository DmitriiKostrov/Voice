using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VoiceEngine.Logic
{
    public enum AudioEffects
    {   
        Chorus,
        Compressor,
        Distortion,
        Echo,
        Flanger,
        Gargle,
        I3DLevel2Reverb,
        ParamEq,
        WavesReverb
    }

    public struct SoundEffect
    {
        public AudioEffects effect;
        public int          power;
    }

    public class Configer
    {
        public static string Tmp;
        public static int Diffusion = 40;//55;
        public static int Freq = 44100;
        public static int Volume = 0;
        public static string StartFolder = "";
        public static List<AudioEffects> Effects = new List<AudioEffects>();
        public Nullable<int> Freqq;
        public Nullable<int> Volumee;
        public Nullable<int> Diffusionn;
        public Dictionary<AudioEffects, int> SoundEffects = new Dictionary<AudioEffects, int>();
        public Nullable<bool> Reverse = null;

        public Configer()
        {
            Freqq = Freq;
            Volumee = Volume;
            Diffusionn = Diffusion;
            //Reverse = false;
        }

        public Configer(Nullable<int> diff, Nullable<int> fre, Nullable<int> vol)
        {
            Freqq = fre;
            Volumee = vol;
            Diffusionn = diff;
            //Reverse = false;
        }

        public bool Update(Configer conf)
        {
            if (conf.Freqq != null)
            {
                Freqq = conf.Freqq;
            }
            if (conf.Diffusionn != null)
            {
                Diffusionn = conf.Diffusionn;
            }
            if (conf.Volumee != null)
            {
                Volumee = conf.Volumee;
            }
            if (conf.Reverse.HasValue)
            {
                this.Reverse = conf.Reverse.Value;
            }
            bool newEffects = false;
            foreach (AudioEffects se in conf.SoundEffects.Keys)
            {
                if (conf.SoundEffects[se] > 0)
                {
                    if (!this.SoundEffects.Keys.Contains(se))
                    {
                        newEffects = true;
                    }
                    this.SoundEffects[se] = conf.SoundEffects[se];
                }
                else if(this.SoundEffects.Keys.Contains(se))
                {
                    newEffects = true;
                    this.SoundEffects.Remove(se);
                }
            }
            return newEffects;
        }

        public static bool LoadProfile(Profile profile, string name)
        {
            profile.RemoveAllSound();
            if (!Directory.Exists(name))
            {
                return false;
            }
            profile.Name = name;
            string []sounds = Directory.GetFiles(name);
            for (int i = 0; i < sounds.Length; i++)
            {
                List<byte> bytes = new List<byte>(File.ReadAllBytes(sounds[i]));
                profile.AddSound(Path.GetFileNameWithoutExtension(sounds[i]), bytes.ToArray());
            }
            foreach (string type in profile.SpecififcSoundTypes)
            {
                try
                {
                    sounds = Directory.GetFiles(string.Format("{0}/{1}", name, type));
                }
                catch 
                {
                    Directory.CreateDirectory(string.Format("{0}/{1}", name, type));
                    continue;
                }
                for (int i = 0; i < sounds.Length; i++)
                {
                    List<byte> bytes = new List<byte>(File.ReadAllBytes(sounds[i]));
                    profile.AddSound(type, Path.GetFileNameWithoutExtension(sounds[i]), bytes.ToArray());
                }
            }
            return true;
        }

        public static bool SaveProfile(Profile profile, string sound, byte[] media)
        {
            profile.AddSound(sound, media);
            return true;
        }

        public static string[] GetProfiles()
        {
            string []dirs = Directory.GetDirectories(Directory.GetCurrentDirectory());
            List<string> res = new List<string>();
            for(int i = 0; i < dirs.Length; i++)
            {
                res.Add(Path.GetFileName(dirs[i]));
            }
            return res.ToArray();
        }
    }
}
