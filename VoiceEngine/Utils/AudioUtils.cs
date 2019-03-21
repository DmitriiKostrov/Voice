using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VoiceEngine.Utils
{
    public class AudioUtils
    {
        private const int _wavHeadSz    = 0x2C;
        private const int _chunkSzPos   = 0x04;
        private const int _chunk2SzPos  = 0x28;
        private const int _channelsPos  = 22;
        // some wav header for filling values in (size as usual).
        private static byte[] _wav16_44100_1ch_Header = new byte[]
                      { 0x52, 0x49, 0x46, 0x46, 0x24, 0x88, 0x00, 0x00, 0x57, 
                        0x41, 0x56, 0x45, 0x66, 0x6d, 0x74, 0x20, 0x10, 0x00, 
                        0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x44, 0xac, 0x00, 
                        0x00, 0x88, 0x58, 0x01, 0x00, 0x02, 0x00, 0x10, 0x00, 
                        0x64, 0x61, 0x74, 0x61, 0x00, 0x88, 0x00, 0x00}; 

        public static int WavHeadSize { get { return _wavHeadSz; } }

        // without header
        public static byte[] GetAudioBytes(byte[] bytes)
        {
            byte []res = new byte[bytes.Length - _wavHeadSz ];
            Array.Copy(bytes, _wavHeadSz, res, 0, res.Length);
            setChunkSizes(ref res);
            return res;
        }

        public static byte[] AddAudioHeader(byte[] bytes)
        {
            byte[] res = new byte[bytes.Length + _wavHeadSz];
            Array.Copy(_wav16_44100_1ch_Header, 0, res, 0, _wavHeadSz);
            Array.Copy(bytes, 0, res, _wavHeadSz, bytes.Length);
            // set wav size.
            setChunkSizes(ref res);
            return res;
        }

        public static byte[] ReverseWave(ref byte[] bytes)
        {
            byte[] res = new byte[bytes.Length];
            Array.Copy(bytes, 0, res, 0, _wavHeadSz);
            for (int i = bytes.Length - 1; i >= _wavHeadSz; i -= 2)
            {
                res[bytes.Length - i + _wavHeadSz] = bytes[i];
                res[bytes.Length - i + _wavHeadSz - 1] = bytes[i - 1];
            }
            return res;
        }

        public static byte[] ReverseWave(byte[] bytes, int start, int end)
        {
            byte[] res = new byte[bytes.Length];
            Array.Copy(bytes, 0, res, 0, start);
            for (int i = end - 1; i >= start; i -= 2)
            {
                res[end - i + start] = bytes[i];
                res[end - i + start - 1] = bytes[i - 1];
            }
            Array.Copy(bytes, end, res, end, bytes.Length - end);
            return res;
        }

        // join left and right channels to one.
        public static byte[] JoinChannels(ref byte[] bytes)
        {
            if (bytes[_channelsPos] != 2)
            {
                return bytes;
            }

            int resPos = _wavHeadSz;
            byte []res = new byte[(bytes.Length - _wavHeadSz) / 2 + _wavHeadSz];
            Array.Copy(_wav16_44100_1ch_Header, res, _wavHeadSz);
            for (int i = _wavHeadSz; i < bytes.Length; i += 4, resPos += 2)
            {
                int chan = ((int)BitConverter.ToInt16(bytes, i) + (int)BitConverter.ToInt16(bytes, i + 2)) / 2;
                res[resPos] = (byte)(chan & 0xFF);
                res[resPos + 1] = (byte)((chan >> 8) & 0xFF);
            }
            setChunkSizes(ref res);
            return res;
        }

        public static byte[] GetWavePart(byte[] bytes, int start, int end)
        {
            return GetWavePart(bytes, start, end, false);
        }

        public static byte[] GetWavePart(byte[] bytes, int start, int end, bool addHeader)
        {
            // must have odd bytes number
            if ((end - start) % 2 != 0)
            {
                end--;
            }
            byte[] res = new byte[end - start + (addHeader ? _wavHeadSz : 0)];
            if (addHeader)
            {
                Array.Copy(_wav16_44100_1ch_Header, 0, res, 0, _wavHeadSz);
                Array.Copy(bytes, start, res, _wavHeadSz, end - start);
                setChunkSizes(ref res);
            }
            Array.Copy(bytes, start, res, (addHeader ? _wavHeadSz : 0), end - start);
            return res;
        }


        public static byte[] AddWavePart(byte[] bytes, int from, byte []newBytes)
        {
            if (bytes == null)
            {
                bytes = _wav16_44100_1ch_Header;
                from = AudioUtils._wavHeadSz;
            }
            byte[] res = new byte[bytes.Length + newBytes.Length];
            Array.Copy(bytes, 0, res, 0, from);
            Array.Copy(newBytes, 0, res, from, newBytes.Length);
            Array.Copy(bytes, from, res, from + newBytes.Length, bytes.Length - from);
            setChunkSizes(ref res);
            return res;
        }

        public static byte[] DeleteWavePart(byte[] bytes, int from, int to)
        {
            if ((from - to) % 2 != 0)
            {
                to--;
            }
            byte[] res = new byte[bytes.Length - (to - from)];
            Array.Copy(bytes, 0, res, 0, from);
            if (to < bytes.Length)
            {
                Array.Copy(bytes, to, res, from, bytes.Length - to);
            }
            setChunkSizes(ref res);
            return res;
        }

        public static byte[] RemoveAllSilence(byte []bytes, int bnum)
        {
            List<byte> res = new List<byte>();
            if (bytes.Length < _wavHeadSz)
            {
                // invalid wav data
                return null;
            }
            for(int i  = 0; i < _wavHeadSz; i++)
            {
                res.Add(bytes[i]);
            }
            int size1 = res[_chunkSzPos] + (res[_chunkSzPos + 1] << 8) + (res[_chunkSzPos + 2] << 16) + (res[_chunkSzPos + 3] << 24);
            int size2 = res[_chunk2SzPos] + (res[_chunk2SzPos + 1] << 8) + (res[_chunk2SzPos + 2] << 16) + (res[_chunk2SzPos + 3] << 24);
            int pos = _wavHeadSz;
            int deleted = 0;
            // remove silence block of 32 bytes
            // silence byte: 0x00 or 0xFF bytes
            for (int i = pos; i < bytes.Length; i += bnum)
            {
                int cnt = 0;
                int j;
                for (j = 0; j < bnum && j + i < bytes.Length; j++)
                {
                    //if (bytes[j + i] >= 0x7E && bytes[j + i] <= 0x81)
                    if (bytes[j + i] == 0 || bytes[j + i] == 0xFF)
                    {
                        cnt++;
                    }
                }
                j--;
                // add bytes block only if silence bytes count <= 14
                if (j < bnum - 1 || cnt < bnum / 2)
                {
                    for (int k = i; k <= i + j; k++)
                    {
                        res.Add(bytes[k]);
                    }
                }
                else
                {
                    size1 -= bnum;
                    size2 -= bnum;
                    deleted++;
                }
            }
            res[_chunkSzPos] = (byte)(size1 & 0xFF);
            res[_chunkSzPos + 1] = (byte)((size1 >> 8) & 0xFF);
            res[_chunkSzPos + 2] = (byte)((size1 >> 16) & 0xFF);
            res[_chunkSzPos + 3] = (byte)((size1 >> 24) & 0xFF);
            res[_chunk2SzPos] = (byte)(size2 & 0xFF);
            res[_chunk2SzPos + 1] = (byte)((size2 >> 8) & 0xFF);
            res[_chunk2SzPos + 2] = (byte)((size2 >> 16) & 0xFF);
            res[_chunk2SzPos + 3] = (byte)((size2 >> 24) & 0xFF);
            return res.ToArray();
        }

        private static void setChunkSizes(ref byte[] res)
        {
            int size2 = res.Length - _wavHeadSz;
            int size1 = size2 + _chunk2SzPos - _chunkSzPos;
            setIntSize(ref res, size1, _chunkSzPos);
            setIntSize(ref res, size2, _chunk2SzPos);

        }

        private static void setIntSize(ref byte[] res, int size, int start)
        {
            res[start] = (byte)(size & 0xFF);
            res[start + 1] = (byte)((size >> 8) & 0xFF);
            res[start + 2] = (byte)((size >> 16) & 0xFF);
            res[start + 3] = (byte)((size >> 24) & 0xFF);
        }

        public static byte[] TrimSilence(byte[] bytes, int bnum)
        {
            List<byte> res = new List<byte>();
            if (bytes.Length < _wavHeadSz)
            {
                // invalid wav data
                return null;
            }
            for (int i = 0; i < _wavHeadSz; i++)
            {
                res.Add(bytes[i]);
            }
            int size1 = res[_chunkSzPos] + (res[_chunkSzPos + 1] << 8) + (res[_chunkSzPos + 2] << 16) + (res[_chunkSzPos + 3] << 24);
            int size2 = res[_chunk2SzPos] + (res[_chunk2SzPos + 1] << 8) + (res[_chunk2SzPos + 2] << 16) + (res[_chunk2SzPos + 3] << 24);
            int pos = _wavHeadSz;
            int deleted = 0;
           
            bool first = true;
            List<byte> buff = new List<byte>();
            // remove silence block of 32 bytes
            // silence byte: 0x00 or 0xFF bytes
            for (int i = pos; i < bytes.Length; i += bnum)
            {
                int silence = 0;
                int j;
                for (j = 0; j < bnum && j + i < bytes.Length; j++)
                {
                    //if (bytes[j + i] >= 0x7E && bytes[j + i] <= 0x81)
                    if (bytes[j + i] == 0)// || bytes[j + i] == 0xFF)
                    {
                        silence++;
                    }
                }
                j--;
                // add bytes block only if silence bytes count <= 14
                if (j < bnum - 1 || silence < bnum / 4)
                {
                    for (int k = 0; k < buff.Count; k++)
                    {
                        res.Add(buff[k]);
                    }
                    for (int k = i; k <= i + j; k++)
                    {
                        res.Add(bytes[k]);
                    }
                    buff.Clear();
                    first = false;
                }
                else if(first)
                {
                    size1 -= bnum;
                    size2 -= bnum;
                    deleted++;
                }
                else
                {
                    for (int k = i; k <= i + j; k++)
                    {
                        buff.Add(bytes[k]);
                    }
                }
            }
            size1 -= buff.Count;
            size2 -= buff.Count;
            res[_chunkSzPos] = (byte)(size1 & 0xFF);
            res[_chunkSzPos + 1] = (byte)((size1 >> 8) & 0xFF);
            res[_chunkSzPos + 2] = (byte)((size1 >> 16) & 0xFF);
            res[_chunkSzPos + 3] = (byte)((size1 >> 24) & 0xFF);
            res[_chunk2SzPos] = (byte)(size2 & 0xFF);
            res[_chunk2SzPos + 1] = (byte)((size2 >> 8) & 0xFF);
            res[_chunk2SzPos + 2] = (byte)((size2 >> 16) & 0xFF);
            res[_chunk2SzPos + 3] = (byte)((size2 >> 24) & 0xFF);
            return res.ToArray();
        }

        public static bool RemoveSilence(string fname)
        {
            //try
            //{
                byte[] bytes = TrimSilence(File.ReadAllBytes(fname), 128);
                File.Delete(fname);
                File.WriteAllBytes(fname, bytes);
                return true;
            //}
            //catch
            //{
            //    return false;
           // }
        }

        public static int getMediaSize(byte[] bytes)
        {
            return (bytes[_chunk2SzPos] + (bytes[_chunk2SzPos + 1] << 8) + (bytes[_chunk2SzPos + 2] << 16) + (bytes[_chunk2SzPos + 3] << 24)) / 2;
        }
    }
}
