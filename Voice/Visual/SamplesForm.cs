using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceEngine.Logic;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using VoiceEngine.Logic.Sound;

namespace Voice.Visual
{
    public partial class SamplesForm : Form
    {
        Profile _profile;
        SoundEditor _soundEditor;

        static int WidthSmall = 280;
        static int WidthLarge = 816;

        #region Init
        public SamplesForm(Profile profile)
        {
            InitializeComponent();
            _profile = profile;
            ProfileComboBox.Items.AddRange(Configer.GetProfiles());
            if(!string.IsNullOrEmpty(_profile.Name))
            {
                ProfileComboBox.SelectedIndex = ProfileComboBox.Items.IndexOf(_profile.Name);
            }
            WidthSmall = MainSplitContainer.Width + 6;
            initSoundEditor();
            fillCharBox();
            this.Width = WidthSmall;
        }

        private void initSoundEditor()
        {
            _soundEditor = new SoundEditor(EditorPanel);
            _soundEditor.Parent = EditorPanel;
            _soundEditor.Visible = true;
            _soundEditor.Enabled = true;
            _soundEditor.Dock = DockStyle.Fill;
            WidthLarge = _soundEditor.Width + WidthSmall;
            _soundEditor.Parent.Visible = true;
            _soundEditor.SaveEvent += new SaveWavDelegate(SoundEditor_SaveEvent);
            EditorPanel.Refresh();
        }

        void SoundEditor_SaveEvent(object sender, SaveWavEventArgs e)
        {
            bool added = false;
            string path = "";
            // new sound adding.
            if(e.wavInfo.name == "")
            {
                AddForm add = new AddForm("музыка" + _profile.GetSpecificSoundsByType("музыка").Length);
                add.ShowDialog(this);
                if (Configer.Tmp != "")
                {
                     _profile.AddSound("музыка", Configer.Tmp, e.wavInfo.bytes);
                    if(CharBox.SelectedItem.ToString() == "музыка")
                    {
                        fillSpecificMediaList("музыка");
                        ListViewItem item = CharListView.Items.Find(Configer.Tmp, false)[0];
                        //item.Selected = true;
                        item.ToolTipText = item.Text;
                        added = true;
                        path = "музыка\\" + Configer.Tmp;  
                        //CharListView.Focus();
                    }
                }
            }
            else
            {
                if(MessageBox.Show("Заменить звук " + e.wavInfo.name + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string [] name = e.wavInfo.name.Split(new char[]{'\\'});
                    path = name[0]; 
                    // general sound
                    if (name.Length == 1)
                    {
                        _profile.AddSound(name[0], e.wavInfo.bytes);
                    }
                    else
                    {
                        _profile.AddSound(name[0], name[1], e.wavInfo.bytes);
                        path += "\\" + name[1]; ;  
                    }
                    added = true;
                }
            }
            if (added)
            {
                // store bytes to disk
                path = _profile.Name + "\\" + path + ".wav";
                if(File.Exists(path))
                {
                   File.Delete(path);
                }
                FileStream s = File.Create(path);
                s.Write(e.wavInfo.bytes, 0, e.wavInfo.bytes.Length);
                s.Close();
             }
           // e.wavInfo.
        }

        private void fillCharBox()
        {
            CharBox.Items.AddRange(Chars.SoundTypes());
            CharBox.Items.AddRange(_profile.SpecififcSoundTypes);
        }

        private void fillSpecificMediaList(string type)
        {
            CharListView.Clear();
            AddSoundButton.Enabled = true;
            string[] media = _profile.GetSpecificSoundsByType(type);
            for (int i = 0; i < media.Length; i++)
            {
                ListViewItem item = new ListViewItem(media[i]);
                item.ToolTipText = item.Text;
                item.Tag = type;
                item.Name = media[i];
                CharListView.Items.Add(item);
                SetCharBoxItemColor(i, true);
            }
        }

        private void fillMediaList(string type)
        {
            CharListView.Clear();
            string[] media = Chars.GetSoundsByTypes(type);
            for (int i = 0; i < media.Length; i++)
            {
                ListViewItem item = new ListViewItem(media[i]);
                item.Tag = null;
                item.Name = media[i];
                CharListView.Items.Add(item);
                SetCharBoxItemColor(i);
            }
        }

        private void SetCharBoxItemColor(int idx)
        {
            SetCharBoxItemColor(idx, _profile.IsSoundExists(CharListView.Items[idx].Text));
        }

        private void SetCharBoxItemColor(int idx, bool loaded)
        {
            if (loaded)
            {
                CharListView.Items[idx].BackColor = Color.LightGreen;
            }
            else
            {
                CharListView.Items[idx].BackColor = Color.MistyRose;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            _soundEditor.OnShow();
            base.OnShown(e);
        }
        #endregion

        #region Selections
        // new profile choosed
        private void ProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_profile.Name != ProfileComboBox.SelectedItem.ToString())
            {
                Configer.LoadProfile(_profile, ProfileComboBox.SelectedItem.ToString());
            }
            CharBox.Enabled = true;
            CharsStatusLabel.Text = ProfileComboBox.SelectedItem.ToString() + ": " + _profile.LoadedSounds.ToString() + " загружено";
        }

        // section choosed
        private void CharBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CharBox.SelectedItem == null)
            {
                return;
            }
            char []cons = Chars.Consonents;
            //this.Width = WidthSmall;
            if(Chars.IsSoundType(CharBox.SelectedItem.ToString()))
            {
                fillMediaList(CharBox.SelectedItem.ToString());
            }
            else
            {
                fillSpecificMediaList(CharBox.SelectedItem.ToString());
            }
            CharListView.Focus();
            if (CharListView.Items.Count > 0)
            {
                CharListView.Items[0].Selected = true;
            }
            CharsStatusLabel.Text = "Тип: " + CharBox.SelectedItem.ToString();
        }

        // sound item choosed
        private void CharListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CharListView.SelectedItems.Count > 0)
            {
                //this.Width = WidthSmall;
                ButtonRecord.Enabled = true;
                bool soundExist = (CharListView.SelectedItems[0].BackColor == Color.LightGreen);
                ButtonPlay.Enabled = soundExist;
                ButtonRemove.Enabled = soundExist;
                ButtonChange.Enabled = soundExist;
                ButtonRename.Enabled = (CharListView.SelectedItems[0].Tag != null) ? soundExist : false ;
                AddSoundButton.Enabled = (CharListView.SelectedItems[0].Tag != null);
                if(soundExist && this.Width == WidthLarge)
                {
                    // show amplitude diagram
                    showDiagramm();
                }
                CharsStatusLabel.Text = "Звук: " + CharListView.SelectedItems[0].Text;
            }
        }
        
        // sound item leaved
        private void CharListView_Leave(object sender, EventArgs e)
        {
            if (!ButtonPlay.Focused && !ButtonRecord.Focused && !ButtonRemove.Focused && !ButtonChange.Focused && !ButtonRename.Focused)
            {
                //ButtonRecord.Enabled    = false;
                ///ButtonPlay.Enabled      = false;
                //ButtonRemove.Enabled    = false;
                //ButtonChange.Enabled    = false;
                //ButtonRename.Enabled    = false;
            }
        }
        #endregion

        #region Main Buttons
        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            if (CharListView.SelectedItems.Count > 0)
            {
                try
                {
                    MediaPlayer mPlayer = new MediaPlayer(this);
                    if (Chars.IsSoundType(CharBox.SelectedItem.ToString()))
                    {
                        mPlayer.Play(_profile.GetSoundMedia(CharListView.SelectedItems[0].Text));
                    }
                    else
                    {
                        mPlayer.Play(_profile.GetSpecificSoundMedia(CharBox.SelectedItem.ToString(), CharListView.SelectedItems[0].Text));
                    }
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.Message, "Failed to play sound");
                }
            }
        }

        private void ButtonRecord_Click(object sender, EventArgs e)
        {
            if (CharListView.SelectedItems.Count > 0)
            {
                string type = CharBox.SelectedItem.ToString();
                if (_profile.SpecififcSoundTypes.Contains(type))
                {
                    record(CharListView.SelectedItems[0].Text, type);
                }
                else
                {
                    record(CharListView.SelectedItems[0].Text, "");
                }
            }
        }

        private bool record(string name, string path)
        {
            try
            {
                RecordForm recf = new RecordForm(_profile, "./" + path + "/" + name + ".wav");
                recf.ShowDialog(this);
                if (Configer.Tmp == "")
                {
                    return false;
                }
                //AudioModifier.RemoveSilence(Path.Combine(_profile.Name, path + "/" + name + ".wav"));
                Configer.LoadProfile(_profile, _profile.Name);
                SetCharBoxItemColor((CharListView.SelectedItems.Count > 0) ? CharListView.SelectedItems[0].Index : CharListView.Items.Count - 1, true);
                ButtonPlay.Enabled = true;
                ButtonRemove.Enabled = true;
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Failed to record sound", ee.Message);
            }
            return false;
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (CharListView.SelectedItems.Count > 0)
            {
                ListViewItem item = CharListView.SelectedItems[0];
                if (MessageBox.Show("Удалить звук '" + item.Text + "'?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                if (item.Tag == null)
                {
                    File.Delete(Path.Combine(_profile.Name, item.Text) + ".wav");
                    _profile.RemoveSound(CharListView.SelectedItems[0].Text);
                    SetCharBoxItemColor(CharListView.SelectedItems[0].Index, false);
                }
                else
                {
                    File.Delete(Path.Combine(Path.Combine(_profile.Name, item.Tag.ToString()), item.Text) + ".wav");
                    _profile.RemoveSound(item.Tag.ToString(), item.Text);
                    CharListView.Items.Remove(item);
                }
                ButtonPlay.Enabled = false;
                ButtonRemove.Enabled = false;
            }
        }

        private void AddProfile_Click(object sender, EventArgs e)
        {
            try
            {
                AddForm add = new AddForm("профиль0");
                add.ShowDialog(this);
                string name = Configer.Tmp;
                if (name == "")
                {
                    return;
                }
                if (Directory.Exists(name))
                {
                    MessageBox.Show("Профиль уже существует.");
                    return;
                }
                if(MessageBox.Show(string.Format("Создать профиль '{0}'?",
                                        name), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Directory.CreateDirectory(name);
                    foreach (string s in _profile.SpecififcSoundTypes)
                    {
                        Directory.CreateDirectory(Path.Combine(name, s));
                    }
                    ProfileComboBox.SelectedIndex = ProfileComboBox.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно создать профиль: " + ex.Message);
            }
        }

        private void DeleteProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(ProfileComboBox.SelectedItem.ToString()))
                {
                    if (MessageBox.Show(string.Format("Удалить профиль '{0}' со всеми звуками?",
                                        ProfileComboBox.SelectedItem.ToString()), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Directory.Delete(ProfileComboBox.SelectedItem.ToString(), true);
                        ProfileComboBox.Items.Remove(ProfileComboBox.SelectedItem.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно удалить профиль: " + ex.Message);
            }
        }

        private void AddSoundButton_Click(object sender, EventArgs e)
        {
            string type = CharBox.SelectedItem.ToString(); 
            AddForm add = new AddForm(type + CharListView.Items.Count.ToString());
            add.ShowDialog(this);
            string name = Configer.Tmp;
            if (name != "")
            {
                 _profile.AddSound(type, Configer.Tmp, null);
                 if (record(name, type))
                 {
                     fillSpecificMediaList(type);
                     ListViewItem item = CharListView.Items.Find(name, false)[0];
                     item.Selected = true;
                     item.ToolTipText = item.Text;
                     CharListView.Focus();
                 }
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (CharListView.SelectedItems.Count > 0)
            {
                ListViewItem item = CharListView.SelectedItems[0];
                if (item.Tag != null)
                {
                    AddForm add = new AddForm(item.Text, "Введите новое имя.");
                    add.ShowDialog(this);
                    if (Configer.Tmp != "" && Configer.Tmp != item.Text)
                    {
                        if (File.Exists(Path.Combine(Path.Combine(_profile.Name, item.Tag.ToString()), Configer.Tmp) + ".wav"))
                        {
                            MessageBox.Show("Звук с таким именем уже существует.");
                            return;
                        }
                        File.Move(  Path.Combine(Path.Combine(_profile.Name, item.Tag.ToString()), item.Text) + ".wav", 
                                    Path.Combine(Path.Combine(_profile.Name, item.Tag.ToString()), Configer.Tmp) + ".wav");
                        Configer.LoadProfile(_profile, _profile.Name);
                        item.Text = Configer.Tmp;
                        item.ToolTipText = item.Text;
                        CharListView.Sort();
                    }
                }
            }
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            this.Width = (this.Width == WidthSmall) ? WidthLarge : WidthSmall;
            if (this.Width == WidthLarge)
            {
                // show amplitude diagram
                showDiagramm();
            }
        }

        #endregion

        #region Sound changing
        
        private void showDiagramm()
        {
            ListViewItem item = CharListView.SelectedItems[0];
            string type = CharBox.SelectedItem.ToString();
            if (_profile.SpecififcSoundTypes.Contains(type))
            {
                _soundEditor.ShowAmplitudes(_profile.GetSpecificSoundMedia(type, item.Name), type + "\\" + item.Name);
            }
            else
            {
                _soundEditor.ShowAmplitudes(_profile.GetSoundMedia(item.Name), item.Name);
            }
        }

        #endregion

    }
}
