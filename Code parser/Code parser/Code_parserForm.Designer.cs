namespace Code_parser
{
    partial class Code_parserForm
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
            this.FileContent_richTextBox = new System.Windows.Forms.RichTextBox();
            this.FileContent_groupBox = new System.Windows.Forms.GroupBox();
            this.stat_grid = new System.Windows.Forms.DataGridView();
            this.stat_groupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileContent_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stat_grid)).BeginInit();
            this.stat_groupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileContent_richTextBox
            // 
            this.FileContent_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileContent_richTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FileContent_richTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileContent_richTextBox.Location = new System.Drawing.Point(9, 29);
            this.FileContent_richTextBox.Name = "FileContent_richTextBox";
            this.FileContent_richTextBox.ReadOnly = true;
            this.FileContent_richTextBox.Size = new System.Drawing.Size(468, 145);
            this.FileContent_richTextBox.TabIndex = 1;
            this.FileContent_richTextBox.Text = "";
            // 
            // FileContent_groupBox
            // 
            this.FileContent_groupBox.Controls.Add(this.FileContent_richTextBox);
            this.FileContent_groupBox.Location = new System.Drawing.Point(12, 37);
            this.FileContent_groupBox.Name = "FileContent_groupBox";
            this.FileContent_groupBox.Size = new System.Drawing.Size(487, 189);
            this.FileContent_groupBox.TabIndex = 2;
            this.FileContent_groupBox.TabStop = false;
            this.FileContent_groupBox.Text = "Содержимое файла";
            // 
            // stat_grid
            // 
            this.stat_grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.stat_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.stat_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stat_grid.Location = new System.Drawing.Point(9, 24);
            this.stat_grid.Name = "stat_grid";
            this.stat_grid.Size = new System.Drawing.Size(468, 241);
            this.stat_grid.TabIndex = 3;
            // 
            // stat_groupBox
            // 
            this.stat_groupBox.Controls.Add(this.stat_grid);
            this.stat_groupBox.Location = new System.Drawing.Point(12, 243);
            this.stat_groupBox.Name = "stat_groupBox";
            this.stat_groupBox.Size = new System.Drawing.Size(487, 271);
            this.stat_groupBox.TabIndex = 3;
            this.stat_groupBox.TabStop = false;
            this.stat_groupBox.Text = "Статистика";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(524, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_ToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // Open_ToolStripMenuItem
            // 
            this.Open_ToolStripMenuItem.Name = "Open_ToolStripMenuItem";
            this.Open_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Open_ToolStripMenuItem.Text = "Открыть";
            this.Open_ToolStripMenuItem.Click += new System.EventHandler(this.Open_ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 573);
            this.Controls.Add(this.stat_groupBox);
            this.Controls.Add(this.FileContent_groupBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Code parser";
            this.FileContent_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stat_grid)).EndInit();
            this.stat_groupBox.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox FileContent_richTextBox;
        private System.Windows.Forms.GroupBox FileContent_groupBox;
        private System.Windows.Forms.DataGridView stat_grid;
        private System.Windows.Forms.GroupBox stat_groupBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Open_ToolStripMenuItem;
    }
}

