using System;
using System.Drawing;
using System.Windows.Forms;
using VoiceEngine.Utils;

namespace VoiceEngine.Logic.Sound
{
    public class AudioFrame
    {
        private Bitmap _canvasTimeDomain;
        private Bitmap _canvasFrequencyDomain;
        private double[] _wave = null;
        private double[] _fft;
        private SignalGenerator _signalGenerator;
        private bool _isTest = false;

        public int Resolution = 100;
        public Color Color = Color.LimeGreen;

        public int PictureSize
        {
            get { return (_wave == null ? 0 : (int)Math.Round((double)_wave.Length / ((double)44100 / (double)Resolution))); }
        }

        public AudioFrame(bool isTest)
        {
            _isTest = isTest;
        }

        public void Process(ref byte[] wave)
        {
            Process(ref wave, true);
        }

        /// <summary>
        /// Process 16 bit sample
        /// </summary>
        /// <param name="wave"></param>
        /// <param name="hasHEader">true when wav has headers also</param>
        public void Process(ref byte[] wave, bool hasHeader)
        {
            if (wave == null)
            {
                _wave = null;
                return;
            }
            int len = (hasHeader ? wave.Length - AudioUtils.WavHeadSize : wave.Length);
            _wave = new double[len / 2];

            if (!_isTest)
            {
                // Split out channels from sample
                int h = 0;
                for (int i = 0; i < len; i += 2)
                {
                    _wave[h] = (double)BitConverter.ToInt16(wave, i);
                    h++;
                }
            }
            else
            {
                // Generate artificial sample for testing
                _signalGenerator = new SignalGenerator();
                _signalGenerator.SetWaveform("Sine");
                _signalGenerator.SetSamplingRate(44100);
                _signalGenerator.SetSamples(16384);
                _signalGenerator.SetFrequency(5000);
                _signalGenerator.SetAmplitude(32768);
                _wave = _signalGenerator.GenerateSignal();
            }
        }

        /// <summary>
        /// Render time domain to PictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        public void RenderTimeDomain(ref PictureBox pictureBox)
        {
            if (_wave == null)
            {
                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                }
                return;
            }
            pictureBox.Width = this.PictureSize;
            // Set up for drawing
            _canvasTimeDomain = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics offScreenDC = Graphics.FromImage(_canvasTimeDomain);
            SolidBrush brush = new System.Drawing.SolidBrush(Color.FromArgb(0, 0, 0));
            Pen pen = new System.Drawing.Pen(Color.White);

            // Determine channnel boundries
            int width = _canvasTimeDomain.Width;
            int center = _canvasTimeDomain.Height;
            int height = _canvasTimeDomain.Height;

            offScreenDC.DrawLine(pen, 0, center, width, center);

            int left = 0;
            int top = 0;
            int right = width;
            int bottom = center - 1;

            // Draw left channel
            double yCenter = (bottom - top) / 2;
            double yScale = 0.5 * (bottom - top) / 32768;  // a 16 bit sample has values from -32768 to 32767
            int xPrev = 0, yPrev = 0;
            for (int xAxis = left; xAxis < right; xAxis++)
            {
                int yAxis = (int)(yCenter + (_wave[_wave.Length / (right - left) * xAxis] * yScale));
                if (xAxis == 0)
                {
                    xPrev = 0;
                    yPrev = yAxis;
                }
                else
                {
                    pen.Color = Color;
                    offScreenDC.DrawLine(pen, xPrev, yPrev, xAxis, yAxis);
                    xPrev = xAxis;
                    yPrev = yAxis;
                }
            }

            // Clean up
            pictureBox.Image = _canvasTimeDomain;
            offScreenDC.Dispose();
        }

        /// <summary>
        /// Render frequency domain to PictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        public void RenderFrequencyDomain(ref PictureBox pictureBox)
        {
            // Generate frequency domain data in decibels
            _fft = FourierTransform.FFTDb(ref _wave);
            // Set up for drawing
            _canvasFrequencyDomain = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics offScreenDC = Graphics.FromImage(_canvasFrequencyDomain);
            SolidBrush brush = new System.Drawing.SolidBrush(Color.FromArgb(0, 0, 0));
            Pen pen = new System.Drawing.Pen(Color.Aqua);

            // Determine channnel boundries
            int width = _canvasFrequencyDomain.Width;
            int center = _canvasFrequencyDomain.Height;// / 2;
            int height = _canvasFrequencyDomain.Height;

            offScreenDC.DrawLine(pen, 0, center, width, center);

            int left = 0;
            int top = 0;
            int right = width;
            int bottom = center - 1;

            // Draw left channel
            for (int xAxis = left; xAxis < right; xAxis++)
            {
                double amplitude = (int)_fft[(int)(((double)(_fft.Length) / (double)(width)) * xAxis)];
                if (amplitude < 0) // Drop negative values
                    amplitude = 0;
                int yAxis = (int)(top + ((bottom - top) * amplitude) / 100);  // Arbitrary factor
                pen.Color = Color.FromArgb(0, 0, 255);//(int)amplitude % 255);
                offScreenDC.DrawLine(pen, xAxis, top, xAxis, yAxis);
            }

            // Clean up
            pictureBox.Image = _canvasFrequencyDomain;
            offScreenDC.Dispose();
        }
    }
}
