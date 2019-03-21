using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;

namespace Voice.Visual
{
    public partial class AddForm : Form
    {
        public AddForm(string defaultName)
        {
            InitializeComponent();
            AddText.Text = defaultName;
            AddText.Focus();
            AddText.SelectAll();
        }

        public AddForm(string defaultName, string title)
        {
            InitializeComponent();
            this.Text = title + "Нажмите Enter.";
            AddText.Text = defaultName;
            AddText.Focus();
            AddText.SelectAll();
            Configer.Tmp = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Configer.Tmp = AddText.Text;
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                Configer.Tmp = "";
                this.Close();
            }
        }
    }
}
