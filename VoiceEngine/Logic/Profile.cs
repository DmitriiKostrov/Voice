using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoiceEngine.Utils;

namespace VoiceEngine.Logic
{
    public class Profile
    {
        public string Name;
        private Dictionary<string, byte[]> _soundMap;
        private Dictionary<string, Dictionary<string, byte[]>> _specificSound;
        public static string[] DefaultSpecfifcTypes = new string[] {};

        public string []SpecififcSoundTypes
        {
            get{return _specificSound.Keys.ToArray();}
        }

        public int LoadedSounds
        {
            get
            {
                int cnt = 0;
                foreach (Dictionary<string, byte[]> d in _specificSound.Values)
                {
                    cnt += d.Count;
                }
                return _soundMap.Count + cnt;
            }
        }

        public Profile()
        {
            _soundMap = new Dictionary<string, byte[]>();
            _specificSound = new Dictionary<string, Dictionary<string, byte[]>>();
            foreach (string s in DefaultSpecfifcTypes)
            {
                _specificSound[s] = new Dictionary<string, byte[]>();
            }
        }

        public Profile(string name)
        {
            _soundMap = new Dictionary<string, byte[]>();
            _specificSound = new Dictionary<string, Dictionary<string, byte[]>>();
            foreach (string s in DefaultSpecfifcTypes)
            {
                _specificSound[s] = new Dictionary<string, byte[]>();
            }
            Name = name;
        }

        public void AddSpecificTypes(string[] types)
        {
            foreach(string s in types)
            {
                _specificSound[s] = new Dictionary<string, byte[]>();
            }
        }

        public void AddSound(string sound, byte[] mediaBytes)
        {
            _soundMap[sound] = mediaBytes;
        }

        public void AddSound(string type, string sound, byte[] mediaBytes)
        {
            _specificSound[type][sound] = mediaBytes;
        }

        public bool RemoveSound(string sound)
        {
            return _soundMap.Remove(sound);
        }

        public bool RemoveSound(string type, string sound)
        {
            return _specificSound[type].Remove(sound);
        }

        public void RemoveAllSound()
        {
            _soundMap.Clear();
            foreach(Dictionary<string, byte[]> d in _specificSound.Values)
            {
                d.Clear();
            }
        }

        public string[] GetSpecificSoundsByType(string type)
        {
            return _specificSound[type].Keys.ToArray();
        }

        public byte[] GetSoundMedia(string sound)
        {
            try
            {
                return _soundMap[sound];
            }
            catch
            {
                return null;
            }
        }

        public byte[] GetSpecificSoundMedia(string type, string sound)
        {
            try
            {
                return _specificSound[type][sound];
            }
            catch
            {
                return null;
            }
        }

        public bool IsSoundExists(string sound)
        {
            return _soundMap.ContainsKey(sound);
        }
 
   }
}
