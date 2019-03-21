using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoiceEngine.Utils
{
    public class DebugOutput
    {
        public static string ShowBytes(byte []bytes, int len)
        {
            int l = (len > 0 && len <= bytes.Length) ? len : bytes.Length;
            StringBuilder bldr = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                bldr.AppendFormat(bytes[i].ToString("X"));
            }
            return bldr.ToString();
        }
    }
}
