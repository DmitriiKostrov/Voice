namespace Voice.Visual
{
    partial class RecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RecordStopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RecordStopButton
            // 
            this.RecordStopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecordStopButton.Location = new System.Drawing.Point(0, 0);
            this.RecordStopButton.Name = "RecordStopButton";
            this.RecordStopButton.Size = new System.Drawing.Size(306, 193);
            this.RecordStopButton.TabIndex = 0;
            this.RecordStopButton.Text = "START";
            this.RecordStopButton.UseVisualStyleBackColor = true;
            this.RecordStopButton.Click += new System.EventHandler(this.RecordStopButton_Click);
            // 
            // RecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 193);
            this.Controls.Add(this.RecordStopButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Запись";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RecordStopButton;
    }
}