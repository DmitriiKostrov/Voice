namespace Voice.Visual
{
    partial class BoomBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BoomDataGrid = new System.Windows.Forms.DataGridView();
            this.C1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MusicComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.BoomDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // BoomDataGrid
            // 
            this.BoomDataGrid.AllowUserToAddRows = false;
            this.BoomDataGrid.AllowUserToDeleteRows = false;
            this.BoomDataGrid.AllowUserToResizeColumns = false;
            this.BoomDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(175)))));
            this.BoomDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.BoomDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(238)))), ((int)(((byte)(233)))));
            this.BoomDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.BoomDataGrid.ColumnHeadersHeight = 26;
            this.BoomDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.BoomDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C1});
            this.BoomDataGrid.GridColor = System.Drawing.Color.DarkGray;
            this.BoomDataGrid.Location = new System.Drawing.Point(132, 0);
            this.BoomDataGrid.Name = "BoomDataGrid";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BoomDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.BoomDataGrid.RowHeadersVisible = false;
            this.BoomDataGrid.RowHeadersWidth = 25;
            this.BoomDataGrid.Size = new System.Drawing.Size(753, 269);
            this.BoomDataGrid.TabIndex = 10;
            this.BoomDataGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BoomDataGrid_CellMouseClick);
            this.BoomDataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BoomDataGrid_ColumnHeaderMouseClick);
            // 
            // C1
            // 
            this.C1.HeaderText = "";
            this.C1.Name = "C1";
            this.C1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.C1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.C1.Width = 25;
            // 
            // MusicComboBox
            // 
            this.MusicComboBox.BackColor = System.Drawing.Color.White;
            this.MusicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MusicComboBox.FormattingEnabled = true;
            this.MusicComboBox.Location = new System.Drawing.Point(5, 3);
            this.MusicComboBox.Name = "MusicComboBox";
            this.MusicComboBox.Size = new System.Drawing.Size(121, 21);
            this.MusicComboBox.TabIndex = 11;
            this.MusicComboBox.SelectedIndexChanged += new System.EventHandler(this.MusicComboBox_SelectedIndexChanged);
            // 
            // BoomBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.MusicComboBox);
            this.Controls.Add(this.BoomDataGrid);
            this.DoubleBuffered = true;
            this.Name = "BoomBox";
            this.Size = new System.Drawing.Size(888, 271);
            this.EnabledChanged += new System.EventHandler(this.BoomBox_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.BoomDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BoomDataGrid;
        private System.Windows.Forms.DataGridViewButtonColumn C1;
        private System.Windows.Forms.ComboBox MusicComboBox;
    }
}
