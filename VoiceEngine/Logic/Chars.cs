using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoiceEngine.Logic
{
    public class Chars
    {
        public delegate string[] SoundTypeGenerator (string type);
        public struct SoundType
        {
            public string sound;
            public SoundTypeGenerator genereator;

        }

        private static char []_consonents = {'б', 'в', 'г', 'д', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'й'};
        private static char []_vowels = {'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я'};
        private static Dictionary<string, int> _silenceMap;
        private static Dictionary<string, SoundTypeGenerator> _soundTypes;

        public static void init()
        {
             _silenceMap = new Dictionary<string,int>();
             _silenceMap[" "] = 200;
             _silenceMap["."] = 400;
             _silenceMap[","] = 200;
             _silenceMap[":"] = 200;
             _silenceMap[";"] = 300;
             _silenceMap["-"] = 200;
            _soundTypes = new Dictionary<string, SoundTypeGenerator>();
            foreach(char c in _vowels)
            {
                _soundTypes[c.ToString()] = GenerateVowelsSound;
            }
            _soundTypes["твердые"] = GenerateHard;
            _soundTypes["мягкие"] = GenerateSoft;
        }

        private static string[] GenerateVowelsSound(string v)
        {
            List<string> res = new List<string>();
            res.Add(v);
            foreach (char c in _consonents)
            {
                if(c != 'й')
                {
                    res.Add(c.ToString() + v);
                }
            }
            return res.ToArray();
        }

        private static string[] GenerateSoft(string v)
        {
            List<string> res = new List<string>();
            foreach (char c in _consonents)
            {
                if (c == 'ч')
                {
                    break;
                }
                res.Add(c.ToString() + "ь");
            }
            return res.ToArray();
        }

        private static string[] GenerateHard(string v)
        {
            List<string> res = new List<string>();
            foreach (char c in _consonents)
            {
                res.Add(c.ToString());
            }
            return res.ToArray();
        }

        public static bool isVowel(char c)
        {
            for (int i = 0; i < _vowels.Length; i++)
            {
                if (_vowels[i] == c)
                    return true;
            }
            return false;
        }

        public static string[] SoundTypes()
        {
            return _soundTypes.Keys.ToArray();
        }

        public static string[] GetSoundsByTypes(string type)
        {
            return _soundTypes[type](type);
        }

        public static bool IsSoundType(string type)
        {
            return _soundTypes.Keys.Contains(type);
        }

        public static char[] Consonents
        {
            get
            {
                return _consonents;
            }
        }
        public static char[] Vowels
        {
            get
            {
                return _vowels;
            }
        }
        // last relative consonents index
        public static int LastRelativeIndex
        {
            get
            {
                return 19; // щ
            }
        }
        // last soft consenent index
        public static int LastSoftIndex
        {
            get
            {
                return 16; // ц
            }
        }

        public static int SilenceLen(string str)
        {
            try
            {
                return _silenceMap[str];
            }
            catch
            {
                return 10;
            }
        }

    }
}
