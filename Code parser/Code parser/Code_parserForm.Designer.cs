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
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progress_groupBox = new System.Windows.Forms.GroupBox();
            this.prograss_label = new System.Windows.Forms.Label();
            this.FileContent_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stat_grid)).BeginInit();
            this.stat_groupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.progress_groupBox.SuspendLayout();
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
            this.stat_groupBox.Location = new System.Drawing.Point(12, 345);
            this.stat_groupBox.Name = "stat_groupBox";
            this.stat_groupBox.Size = new System.Drawing.Size(487, 271);
            this.stat_groupBox.TabIndex = 3;
            this.stat_groupBox.TabStop = false;
            this.stat_groupBox.Text = "Статистика";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(514, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_ToolStripMenuItem,
            this.ExportReportToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // Open_ToolStripMenuItem
            // 
            this.Open_ToolStripMenuItem.Name = "Open_ToolStripMenuItem";
            this.Open_ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.Open_ToolStripMenuItem.Text = "Открыть";
            this.Open_ToolStripMenuItem.Click += new System.EventHandler(this.Open_ToolStripMenuItem_Click);
            // 
            // ExportReportToolStripMenuItem
            // 
            this.ExportReportToolStripMenuItem.Name = "ExportReportToolStripMenuItem";
            this.ExportReportToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ExportReportToolStripMenuItem.Text = "Сохранить отчет";
            this.ExportReportToolStripMenuItem.Click += new System.EventHandler(this.ExportReportToolStripMenuItem_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 31);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(431, 23);
            this.progressBar.TabIndex = 5;
            // 
            // progress_groupBox
            // 
            this.progress_groupBox.Controls.Add(this.prograss_label);
            this.progress_groupBox.Controls.Add(this.progressBar);
            this.progress_groupBox.Location = new System.Drawing.Point(12, 250);
            this.progress_groupBox.Name = "progress_groupBox";
            this.progress_groupBox.Size = new System.Drawing.Size(487, 79);
            this.progress_groupBox.TabIndex = 6;
            this.progress_groupBox.TabStop = false;
            this.progress_groupBox.Text = "Анализ файла...";
            // 
            // prograss_label
            // 
            this.prograss_label.AutoSize = true;
            this.prograss_label.Location = new System.Drawing.Point(446, 37);
            this.prograss_label.Name = "prograss_label";
            this.prograss_label.Size = new System.Drawing.Size(21, 13);
            this.prograss_label.TabIndex = 6;
            this.prograss_label.Text = "0%";
            // 
            // Code_parserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 637);
            this.Controls.Add(this.progress_groupBox);
            this.Controls.Add(this.stat_groupBox);
            this.Controls.Add(this.FileContent_groupBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Code_parserForm";
            this.Text = "Code parser";
            this.FileContent_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stat_grid)).EndInit();
            this.stat_groupBox.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.progress_groupBox.ResumeLayout(false);
            this.progress_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox FileContent_richTextBox;
        private System.Windows.Forms.GroupBox FileContent_groupBox;
        private System.Windows.Forms.DataGridView stat_grid;
        private System.Windows.Forms.GroupBox stat_groupBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Open_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportReportToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox progress_groupBox;
        private System.Windows.Forms.Label prograss_label;
    }
}

