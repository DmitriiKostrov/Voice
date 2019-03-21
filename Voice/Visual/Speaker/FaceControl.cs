using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Voice.Visual
{

    public struct FaceControlArg
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public string name;

        public FaceControlArg(int x_, int y_, int width_, int height_, string name_)
        {
            x = x_;
            y = y_;
            width = width_;
            height = height_;
            name = name_;
        }

        public FaceControlArg(Button b)
        {
            x = b.Location.X;
            y = b.Location.Y;
            width = b.Width;
            height = b.Height;
            name = b.Name;
        }

        public void SetNew(FaceControlArg a, FaceControlArg b)
        {
            x = a.x + b.x;
            y = a.y + b.y;
            height = a.height + b.height;
            width = a.width + b.width;
        }
    }

    public class FaceEventArgs : EventArgs
    {
        // 3 for left\right eyes and nose.
        public FaceControlArg[] FaceArgs;

        public FaceEventArgs() { }
        public FaceEventArgs(FaceControlArg[] args)
        {
            FaceArgs = args;
        }
    }

    public delegate void FaceEventHandler(object sender, FaceEventArgs e);

    class FaceControl
    {
        public event FaceEventHandler FaceEvent;
        public bool Animating = false;

        private FaceControlArg[] _faceArgs;
        private FaceControlArg[] _baseArgs;
        private bool _firstState = true;
        private Random _rnd;
        private Thread _runningThread = null;
        private int _nerves;
        private Object _lock = new Object();


        public int Nerves
        {
            set { lock (_lock) { _nerves = value; } }
        }
        public FaceControl(Button leye, Button reye, Button nose)
        {
            _rnd = new Random();
            _faceArgs = new FaceControlArg[3];
            _faceArgs[0] = new FaceControlArg(leye);
            _faceArgs[1] = new FaceControlArg(reye);
            _faceArgs[2] = new FaceControlArg(nose);
            _baseArgs = new FaceControlArg[3];
            _baseArgs[0] = new FaceControlArg(leye);
            _baseArgs[1] = new FaceControlArg(reye);
            _baseArgs[2] = new FaceControlArg(nose);
        }

        public void StartAnimate()
        {
            _runningThread = new Thread(new ThreadStart(animate));
            _runningThread.IsBackground = true;
            Animating = true;
            _runningThread.Start();
        }

        public void StopAnimate()
        {
            lock (_lock)
            {
                Animating = false;
                if (FaceEvent != null)
                {
                    FaceEventArgs args = new FaceEventArgs();
                    args.FaceArgs = _baseArgs;
                    FaceEvent(this, args);
                }
            }
        }

        private void animate()
        {
            Random random = new Random();
            while (Animating)
            {
                if (_nerves == 0)
                {
                    Thread.Sleep(500);
                    continue;
                }
                if (!_firstState)
                {
                    for (int i = 0; i < _faceArgs.Length; i++)
                    {
                        // set default position
                        _faceArgs[i].x = _baseArgs[i].x;
                        _faceArgs[i].y = _baseArgs[i].y;
                        _faceArgs[i].width = _baseArgs[i].width;
                        _faceArgs[i].height = _baseArgs[i].height;
                    }
                }
                else
                {
                    int change = _rnd.Next(0, _faceArgs.Length);
                    if (change == 0)
                    {
                        animateEye(0);
                    }
                    else if (change == 1)
                    {
                        animateEye(1);
                    }
                    else if (change == 2)
                    {
                        animateNose();
                    }
                    else
                    {
                        animateEye(0);
                        animateEye(1);
                    }
                }
                if (FaceEvent != null)
                {
                    FaceEventArgs args = new FaceEventArgs();
                    args.FaceArgs = _faceArgs;
                    FaceEvent(this, args);
                }
                _firstState = !_firstState;
                // sleep just 0.5 sek to imidately return 1st state of the Face.
                // otherwise sleep random time for next animation.
                Thread.Sleep((_firstState) ? _rnd.Next(1000 / _nerves, 10000 / _nerves) : _rnd.Next(1600 / _nerves, 3000 / _nerves));
            }
        }

        private void animateNose()
        {
            int animType = _rnd.Next(0, 3);
            if (animType == 0)
            {
                // move down
                _faceArgs[2].x -= 5;
                _faceArgs[2].width -= 10;
                _faceArgs[2].height += 10;

            }
            if (animType == 1)
            {
                // move up
                _faceArgs[2].y -= 5;
                _faceArgs[2].x -= 5;
                _faceArgs[2].width += 10;
                _faceArgs[2].height -= 10;
            }
            else if (animType == 1)
            {
                // turn left
                _faceArgs[2].x -= 15;
            }
            else
            {
                // turn right
                _faceArgs[2].x += 15;
            }
        }

        private void animateEye(int id)
        {
            int animType = _rnd.Next(0, 0);
            if (animType == 0)
            {
                // eye size changing. --> <--, <-- -->
                int newHeight = _rnd.Next(30, _faceArgs[id].height + 30);
                int middleY = _faceArgs[id].y + (_faceArgs[id].height / 2);
                _faceArgs[id].y = middleY - (newHeight / 2);
                _faceArgs[id].height = newHeight;

            }
            //System.Windows.Forms.Control.MousePosition	{X = 230 Y = 877}	

        }
    }
}
