
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace VoiceEngine.Logic
{
class clsRecDevices
{ 
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct WaveInCaps
{
public short wMid;
public short wPid;
public int vDriverVersion;
[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
public char[] szPname;
public uint dwFormats;
public short wChannels;
public short wReserved1;
} 
[DllImport("winmm.dll")]
public static extern int waveInGetNumDevs();
[DllImport("winmm.dll", EntryPoint = "waveInGetDevCaps")]
public static extern int waveInGetDevCapsA(int uDeviceID, ref WaveInCaps lpCaps, int uSize);
ArrayList arrLst = new ArrayList(); //using to store all sound recording devices strings 
public int Count //to return total sound recording devices found
{ 
get {return arrLst.Count;}
}
public string this[int indexer] //return spesipic sound recording device name
{
get{return (string)arrLst[indexer];}
}
public clsRecDevices() //fill sound recording devices array
{
int waveInDevicesCount = waveInGetNumDevs(); //get total
if (waveInDevicesCount > 0)
{
for (int uDeviceID = 0; uDeviceID < waveInDevicesCount; uDeviceID++)
{
WaveInCaps waveInCaps = new WaveInCaps();
waveInGetDevCapsA(uDeviceID,ref waveInCaps,Marshal.SizeOf(typeof(WaveInCaps))); 
arrLst.Add(new string(waveInCaps.szPname).Remove(new string(waveInCaps.szPname).IndexOf('\0')).Trim()); //clean garbage
}
}
} 
}
}