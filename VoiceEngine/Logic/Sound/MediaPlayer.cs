using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Media;
using Microsoft.DirectX.DirectSound;
using System.Windows.Forms;
using System.Threading;

namespace VoiceEngine.Logic.Sound
{
    public class MediaPlayer
    {
        Control _parent;
        Device _dev;
        MemoryStream _memoryStream;
        SecondaryBuffer _sound;
        Configer _conf;
        BufferDescription _bufferDesc;
        private static int _maxFreq = (int)((double)44100 * 4);

        public int Tag;

        public int Freq
        {
            set { if (_sound != null && _sound.Frequency != value) _sound.Frequency = (value > _maxFreq) ? _maxFreq : value; }
        }

        public int Pos
        {
            get { return (_sound != null) ? _sound.PlayPosition : -1; }
        }

        public bool HasSound
        {
            get { return _sound != null; }
        }

        public MediaPlayer(Control parent)
        {
            _parent = parent;
            _dev = new Device();
            _dev.SetCooperativeLevel(_parent, CooperativeLevel.Normal);
            _memoryStream = null;
            _sound = null;
            _conf = new Configer();
            setBufferDesc();
        }

        public MediaPlayer(Form parent, Configer conf)
        {
            _parent = parent;
            _memoryStream = null;
            _sound = null;
            _conf = conf;
            _dev = new Device();
            _dev.SetCooperativeLevel(_parent, CooperativeLevel.Normal);
            setBufferDesc();

        }

        private void setBufferDesc()
        {
            _bufferDesc = new BufferDescription();
            _bufferDesc.ControlEffects = true; //this has to be true to use effects.
            _bufferDesc.GlobalFocus = true; //play sound even if application loses focus.
            _bufferDesc.ControlFrequency = true;
            _bufferDesc.ControlVolume = true;
            _bufferDesc.Control3D = true;
            _bufferDesc.ControlPositionNotify = true;
        }

        public void SetBuffer(byte[] buffer)
        {
            if (_parent == null)
                return;
            if (_memoryStream != null)
            {
                _memoryStream.Dispose();
            }
            if (_sound != null && !_sound.Status.Terminated)
            {
                _sound.Stop();
            }
            if (buffer != null)
            {
                _memoryStream = new MemoryStream(buffer);
                _sound = new Microsoft.DirectX.DirectSound.SecondaryBuffer(_memoryStream, _bufferDesc, _dev);
                //EffectDescription effs = new EffectDescription();
                //effs.GuidEffectClass = DSoundHelper.StandardInteractive3DLevel2ReverbGuid;
                //_sound.SetEffects(new EffectDescription[]{effs});
                _sound.Volume = _conf.Volumee.Value;
                _sound.Frequency = _conf.Freqq.Value;
                updateSoundEffects(true);
                //setEffects();
            }
            else
            {
                _sound = null;
            }
        }

        public int PlayPosition
        {
            set { _sound.SetCurrentPosition(value); }
            get { return (_sound == null) ? 0 : _sound.PlayPosition; }
        }

        public bool IsPlaying
        {
            get { return (_sound == null) ? false : _sound.Status.Playing || _sound.Status.Looping; }
        }

        public void Stop()
        {
            if (_sound != null)
            {
                _sound.Stop();
            }
        }

        public void Play(byte[] buffer, int pos)
        {
            SetBuffer(buffer);
            _sound.SetCurrentPosition(pos);
            _sound.Play(0, BufferPlayFlags.Default);
        }

        public void Play(byte[] buffer)
        {
            Play(buffer, 0);
        }

        public void Play()
        {
            Play(true, 0);
        }

        public void Play(bool looping, int pos)
        {
            if (_sound != null)
            {
                if (pos != -1)
                {
                    _sound.SetCurrentPosition(pos);
                }
                _sound.Play(0, (looping) ? BufferPlayFlags.Looping : BufferPlayFlags.Default);
            }
        }

        public void UpdateSoundConfig(bool effects, bool newEffects)
        {
            if (_sound != null)
            {
                _sound.Volume = _conf.Volumee.Value;
                _sound.Frequency = _conf.Freqq.Value;
                if (effects)
                {
                    updateSoundEffects(newEffects);
                }
            }
        }

        private void updateSoundEffects(bool newEffects)
        {
            if (_conf.SoundEffects.Count == 0)
            {
                _conf.SoundEffects[AudioEffects.ParamEq] = 1;
            }

            int i = 0;
            bool wasPlayed = _sound.Status.Looping || _sound.Status.Playing;
            bool looped = _sound.Status.Looping;
            if (newEffects)
            {
                EffectDescription[] effs = new EffectDescription[_conf.SoundEffects.Count];
                foreach (AudioEffects eff in _conf.SoundEffects.Keys)
                {
                    switch (eff)
                    {
                        case AudioEffects.Chorus: effs[i].GuidEffectClass = DSoundHelper.StandardChorusGuid; break;
                        case AudioEffects.Compressor: effs[i].GuidEffectClass = DSoundHelper.StandardCompressorGuid; break;
                        case AudioEffects.Distortion: effs[i].GuidEffectClass = DSoundHelper.StandardDistortionGuid; break;
                        case AudioEffects.Echo: effs[i].GuidEffectClass = DSoundHelper.StandardEchoGuid; break;
                        case AudioEffects.Flanger: effs[i].GuidEffectClass = DSoundHelper.StandardFlangerGuid; break;
                        case AudioEffects.Gargle: effs[i].GuidEffectClass = DSoundHelper.StandardGargleGuid; break;
                        case AudioEffects.I3DLevel2Reverb: effs[i].GuidEffectClass = DSoundHelper.StandardInteractive3DLevel2ReverbGuid; break;
                        case AudioEffects.ParamEq: effs[i].GuidEffectClass = DSoundHelper.StandardParamEqGuid; break;
                        case AudioEffects.WavesReverb: effs[i].GuidEffectClass = DSoundHelper.StandardWavesReverbGuid; break;
                        default: break;
                    }
                    i += 1;
                }
                _sound.Stop();
                _sound.SetEffects(effs);
            }
            i = 0;
            foreach (AudioEffects eff in _conf.SoundEffects.Keys)
            {
                float val = (float)_conf.SoundEffects[eff];
                switch (eff)
                {
                    case AudioEffects.Chorus:
                        val += 40;
                        ChorusEffect chorus = (ChorusEffect)_sound.GetEffects(i);
                        EffectsChorus chorus_params = chorus.AllParameters;
                        chorus_params.Delay = 10 + val / (float)10 ;// 15.0f;
                        chorus_params.Depth = ChorusEffect.DepthMax - 80 + val;
                        chorus_params.Phase = ChorusEffect.PhaseNegative180;
                        chorus_params.Waveform = ChorusEffect.WaveTriangle;
                        chorus_params.WetDryMix = val + val / 5 - 20;// 50.0f;
                        chorus.AllParameters = chorus_params;
                        break;
                    case AudioEffects.Compressor: 
                        //CompressorEffect com = (CompressorEffect)_sound.GetEffects(i);
                        //EffectsCompressor ecom = com.AllParameters;
                       // ecom.Threshold = ((CompressorEffect.ThresholdMax - CompressorEffect.ThresholdMin) / 100) * val;

                          //  com.AllParameters = ecom;
                        break;
                    case AudioEffects.Distortion:
                        val += 10;
                        DistortionEffect dis = (DistortionEffect)_sound.GetEffects(i);
                        EffectsDistortion dis_params = dis.AllParameters;
                        dis_params.Gain = -35 + val;
                        dis_params.Edge = val - 5;
                        dis_params.PostEqBandwidth = (float)(val % 99) * 20 + 2000;
                       dis_params.PostEqCenterFrequency = (float)(val % 99) * 20 + 2000;
                       // dis_params.PreLowpassCutoff = (float)(_conf.SoundEffects[eff] + 1) ;
                        dis.AllParameters = dis_params;
                        break;
                    case AudioEffects.Gargle:
                        GargleEffect gar = (GargleEffect)_sound.GetEffects(i);
                        EffectsGargle egar = (EffectsGargle)gar.AllParameters;
                        egar.RateHz = (int)val * 25;
                        gar.AllParameters = egar;

                        break;
                    case AudioEffects.Echo:
                        /*Interactive3DLevel2ReverbEffect env1 = (Interactive3DLevel2ReverbEffect)_sound.GetEffects(i);
                        EffectsInteractive3DLevel2Reverb enviroEffects1 = env1.AllParameters;
                        enviroEffects1.Reflections = 10 * _conf.SoundEffects[eff];
                        enviroEffects1.Reverb = 2 * _conf.SoundEffects[eff];
                        enviroEffects1.Diffusion = 0.1f * _conf.SoundEffects[eff];
                        env1.AllParameters = enviroEffects1;
                        break;*/
                        EchoEffect echo = (EchoEffect)_sound.GetEffects(i);
                        EffectsEcho echo_params = echo.AllParameters;
                        echo_params.LeftDelay = (_conf.SoundEffects[eff] + 1) *5;// 250.0f;
                        echo_params.RightDelay = (_conf.SoundEffects[eff] + 1) *5;// 250.0f;
//echo_params.RightDelay = 1.0f * _conf.SoundEffects[eff];
                        echo_params.Feedback = val;//20;//1  + _conf.SoundEffects[eff] ;// 85.0f;
                        echo_params.PanDelay = 1;
                        echo_params.WetDryMix = (_conf.SoundEffects[eff] )+ 1;
                        echo.AllParameters = echo_params;
                        break;
                    case AudioEffects.Flanger:
                        FlangerEffect flan = (FlangerEffect)_sound.GetEffects(i);
                        EffectsFlanger eflan = flan.AllParameters;
                        val += 40;
                        //eflan.Delay = FlangerEffect.DelayMax + 80 - val;
                        eflan.Depth = FlangerEffect.DepthMax - 80 + val;
                        eflan.Phase = FlangerEffect.Phase90;
                        eflan.Waveform = FlangerEffect.WaveTriangle;
                        eflan.WetDryMix = FlangerEffect.WetDryMixMax - val / 5;// +val / 5 - 20;// 50.0f;
                        flan.AllParameters = eflan;
                        break;
                    case AudioEffects.I3DLevel2Reverb:
                        Interactive3DLevel2ReverbEffect env = (Interactive3DLevel2ReverbEffect)_sound.GetEffects(i);
                        EffectsInteractive3DLevel2Reverb enviroEffects = env.AllParameters;
                        enviroEffects.DecayHfRatio = 2.0f;
                        enviroEffects.DecayTime = 20.0f;
                        enviroEffects.Density = 1.0f;
                        enviroEffects.Diffusion = 2.0f;
                        enviroEffects.Reflections = (int)(val / 10);
                        enviroEffects.Reverb = 2;
                        env.AllParameters = enviroEffects;
                        break;
                    case AudioEffects.ParamEq: break;
                    case AudioEffects.WavesReverb:
                        val += 85;
                        WavesReverbEffect wrev = (WavesReverbEffect)_sound.GetEffects(i);
                        EffectsWavesReverb ewrev = wrev.AllParameters;
                        //ewrev.ReverbMix = (float)_conf.SoundEffects[eff] / (float)100;
                        ewrev.ReverbTime = val * 20;
                        //ewrev.HighFrequencyRtRatio = (float)val / (float)100;
                        ewrev.ReverbMix = -95.5f + (float)val;// (val >= 96) ? 0 : val - 96;
                        //MessageBox.Show(String.Format("{0} / {1}, {2} / {3}", WavesReverbEffect.ReverbMixMin, WavesReverbEffect.ReverbTimeMax, WavesReverbEffect.ReverbTimeMin, WavesReverbEffect.ReverbTimeMax));
                        
                        //MessageBox.Show(string.Format("{0} - {1} - {2}", WavesReverbEffect.ReverbTimeMin,WavesReverbEffect.ReverbMixMin, WavesReverbEffect.HighFrequencyRtRatioMin), "");
                        wrev.AllParameters = ewrev;
                        break;
                    default: break;
                }
                i += 1;
            }
            if (newEffects && wasPlayed)
            {
                _sound.Play(0, looped ? BufferPlayFlags.Looping : BufferPlayFlags.Default );
            }
        }

        private void setEffects()
        {
            //Interactive3DLevel2ReverbEffect en = (Interactive3DLevel2ReverbEffect)_sound.GetEffects(0);
            //EffectsInteractive3DLevel2Reverb enviroEffect = en.AllParameters;
            //enviroEffect.
            //enviroEffects.DecayHfRatio = 2.0f;
            //enviroEffects.DecayTime = 20.0f;
            //enviroEffects.Density = 1.0f;
            //enviroEffects.Diffusion = 2.0f;
            //enviroEffect.Reflections = 1000;
            //en.AllParameters = enviroEffect;
            //return;
            if (Configer.Effects.Count > 0)
            {
                EffectDescription[] effs = new EffectDescription[Configer.Effects.Count];
                for (int i = 0; i < effs.Length; i++)
                {
                    switch (Configer.Effects[i])
                    {
                        case AudioEffects.Chorus: effs[i].GuidEffectClass = DSoundHelper.StandardChorusGuid; break;
                        case AudioEffects.Compressor: effs[i].GuidEffectClass = DSoundHelper.StandardCompressorGuid; break;
                        case AudioEffects.Distortion: effs[i].GuidEffectClass = DSoundHelper.StandardDistortionGuid; break;
                        case AudioEffects.Echo: effs[i].GuidEffectClass = DSoundHelper.StandardEchoGuid; break;
                        case AudioEffects.Flanger: effs[i].GuidEffectClass = DSoundHelper.StandardFlangerGuid; break;
                        case AudioEffects.Gargle: effs[i].GuidEffectClass = DSoundHelper.StandardGargleGuid; break;
                        case AudioEffects.I3DLevel2Reverb: effs[i].GuidEffectClass = DSoundHelper.StandardInteractive3DLevel2ReverbGuid; break;
                        case AudioEffects.ParamEq: effs[i].GuidEffectClass = DSoundHelper.StandardParamEqGuid; break;
                        case AudioEffects.WavesReverb: effs[i].GuidEffectClass = DSoundHelper.StandardWavesReverbGuid; break;
                        default: break;
                    }
                }
                _sound.SetEffects(effs);
                for (int i = 0; i < effs.Length; i++)
                {
                    switch (Configer.Effects[i])
                    {
                        case AudioEffects.Chorus:
                            ChorusEffect chorus = (ChorusEffect)_sound.GetEffects(i);
                            EffectsChorus chorus_params = chorus.AllParameters;
                            chorus_params.Delay = 15.0f;
                            chorus_params.Depth = ChorusEffect.DepthMax;
                            chorus_params.Phase = ChorusEffect.PhaseNegative90;
                            chorus_params.Waveform = ChorusEffect.WaveSin;
                            chorus_params.WetDryMix = 50.0f;
                            chorus.AllParameters = chorus_params;
                            break;
                        case AudioEffects.Compressor: break;
                        case AudioEffects.Distortion: break;
                        case AudioEffects.Echo: 
                            EchoEffect echo = (EchoEffect)_sound.GetEffects(i);
                            EffectsEcho echo_params = echo.AllParameters;
                            echo_params.LeftDelay = 0.9f;
                            /*echo_params.RightDelay = 77.0f;
                            echo_params.Feedback = 9.0f;
                            echo_params.PanDelay = 1;
                            echo_params.WetDryMix = 9.0f;
                            echo.AllParameters = echo_params;*/
                            break;
                        case AudioEffects.Flanger: break;
                        case AudioEffects.Gargle: break;
                        case AudioEffects.I3DLevel2Reverb:
                            Interactive3DLevel2ReverbEffect env = (Interactive3DLevel2ReverbEffect)_sound.GetEffects(i);
                            EffectsInteractive3DLevel2Reverb enviroEffects = env.AllParameters;
                            //enviroEffects.DecayHfRatio = 2.0f;
                            //enviroEffects.DecayTime = 20.0f;
                            //enviroEffects.Density = 1.0f;
                            //enviroEffects.Diffusion = 2.0f;
                            enviroEffects.Reflections = 1000;
                            //enviroEffects.Reverb = 2;
                            env.AllParameters = enviroEffects;
                            break;
                        case AudioEffects.ParamEq: break;
                        case AudioEffects.WavesReverb: break;
                        default: break;
                    }
                }
            }
        }
    }
}
