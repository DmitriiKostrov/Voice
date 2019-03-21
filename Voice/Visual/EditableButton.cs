using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Voice.Visual
{
    public class EditableButton : Button
    {
        public Color[] Colors   = { Color.Gold, Color.Silver, Color.White, Color.Fuchsia, Color.Khaki };
        public int Interval     = 10;
        public bool BorderColor = false;

        Timer _movingTimer      = new Timer();
        Timer _resizeTimer      = new Timer();
        int   _colorID          = 0;
        Point _startPoint       = new Point(-1, -1);


       
        public void SetEditMode()
        {
            // Add events handling for mouse editing.
            //this.FlatStyle = FlatStyle.Flat;
            _movingTimer.Tick   += new EventHandler(movingTimer_Tick);
            _resizeTimer.Tick   += new EventHandler(resizeTimer_Tick);
            this.MouseWheel     += new MouseEventHandler(EditableButton_MouseWheel);
            this.MouseDown      += new MouseEventHandler(EditableButton_MouseDown);
            this.MouseUp        += new MouseEventHandler(EditableButton_MouseUp);
            this.MouseEnter     += new EventHandler(EditableButton_MouseEnter);
        }

        public void UnsetEditMode()
        {
            // Remove events handling for mouse editing.
            _movingTimer.Tick   -= new EventHandler(movingTimer_Tick);
            _resizeTimer.Tick   -= new EventHandler(resizeTimer_Tick);
            this.MouseWheel     -= new MouseEventHandler(EditableButton_MouseWheel);
            this.MouseDown      -= new MouseEventHandler(EditableButton_MouseDown);
            this.MouseUp        -= new MouseEventHandler(EditableButton_MouseUp);
            this.MouseEnter     -= new EventHandler(EditableButton_MouseEnter);
        }

        public void SetColor(int id)
        {
            _colorID = id % Colors.Length;
            updateColor(true);
        }

        void EditableButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _startPoint             = this.Parent.PointToClient(Control.MousePosition);
                _startPoint.X          -= this.Location.X;
                _startPoint.Y          -= this.Location.Y;
                _movingTimer.Interval = Interval;
                _movingTimer.Start();
                this.Cursor = Cursors.Hand;
            }
            else if (e.Button == MouseButtons.Right)
            {
                _startPoint = this.Parent.PointToClient(Control.MousePosition);
                _resizeTimer.Interval = Interval;
                _resizeTimer.Start();
                this.Cursor = Cursors.SizeAll;
            }
        }

        void EditableButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            if (e.Button == MouseButtons.Left)
            {
                _movingTimer.Stop();
            }
            else if (e.Button == MouseButtons.Right)
            {
                _resizeTimer.Stop();
            }
        }

        void EditableButton_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).Focus();
        }

        void EditableButton_MouseWheel(object sender, MouseEventArgs e)
        {
            updateColor(e.Delta > 0);
        }

        private void updateColor(bool up)
        {
            // Change control color on mouse wheel.
            _colorID = Math.Abs((_colorID + (up ? 1 : -1) + Colors.Length) % Colors.Length);
            if (!BorderColor)
            {
                this.BackColor = Colors[_colorID];
            }
            else
            {
                this.ForeColor = Colors[_colorID];
            }
        }

        void movingTimer_Tick(object sender, EventArgs e)
        {
            // Obtain new location to move control in.
            Point p = this.Parent.PointToClient(Control.MousePosition);
            p.X -= _startPoint.X;
            p.Y -= _startPoint.Y;
            this.Location = p;
        }

        void resizeTimer_Tick(object sender, EventArgs e)
        {
            Point p = this.Parent.PointToClient(Control.MousePosition);
            int dx = _startPoint.X - p.X;
            int dy = _startPoint.Y - p.Y;
            int prev;

            if (dx == dy && dx == 0)
            {
                return;
            }
            else if (Math.Abs(dx) > Math.Abs(dy))
            {
                this.Cursor = Cursors.SizeWE;
                int wi = this.Width;
                // Change width.
                prev = this.Width;
                this.Width = (this.Width - dx <= 0) ? 10 : this.Width - dx;
                this.Left += (wi - this.Width) / 2;
                if (BorderColor)
                {
                    this.FlatAppearance.BorderSize += ((this.Width - prev) / 4);
                }
            }
            else
            {
                this.Cursor = Cursors.SizeNS;
                int he = this.Height;
                // Change height.
                this.Height = (this.Height - dx <= 0) ? 10 : this.Height - dy;
                this.Top += (he - this.Height) / 2;
            }
            _startPoint = p;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
