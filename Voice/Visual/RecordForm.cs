using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;
using System.Threading;
using System.IO;
using VoiceEngine.Logic.Sound;

namespace Voice.Visual
{
    public partial class RecordForm : Form
    {
        private VoiceRecorder _rec;
        private string _sound;
        private Profile _profile;

        public RecordForm(Profile profile, string sound)
        {
            InitializeComponent();

            this.Text = "Запись " + sound;
            _sound = sound;
            _profile = profile;
            Configer.Tmp = "";
        }

        private void RecordStopButton_Click(object sender, EventArgs e)
        {
            if (RecordStopButton.Text == "STOP")
            {
                _rec.recordStop();
                Configer.Tmp = "Recorded";
                this.Close();

            }
            else
            {
                this.ControlBox = false;
                for (int i = 0; i < 100; i++)
                {
                    RecordStopButton.Text = (100 - i).ToString();
                    RecordStopButton.Refresh();
                    Thread.Sleep(10);
                }
                _rec = new VoiceRecorder();
                _rec.recordStart(Path.Combine(_profile.Name, _sound));
                RecordStopButton.Text = "STOP";
            }
        }
    }
}
