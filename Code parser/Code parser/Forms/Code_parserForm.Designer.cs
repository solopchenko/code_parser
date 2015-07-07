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
            this.fileContent_richTextBox = new System.Windows.Forms.RichTextBox();
            this.fileContent_groupBox = new System.Windows.Forms.GroupBox();
            this.stat_grid = new System.Windows.Forms.DataGridView();
            this.stat_groupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.file_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportReport_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settings_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorsSettings_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progress_groupBox = new System.Windows.Forms.GroupBox();
            this.prograss_label = new System.Windows.Forms.Label();
            this.fileContent_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stat_grid)).BeginInit();
            this.stat_groupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.progress_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileContent_richTextBox
            // 
            this.fileContent_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileContent_richTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.fileContent_richTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileContent_richTextBox.Location = new System.Drawing.Point(9, 29);
            this.fileContent_richTextBox.Name = "fileContent_richTextBox";
            this.fileContent_richTextBox.ReadOnly = true;
            this.fileContent_richTextBox.Size = new System.Drawing.Size(468, 174);
            this.fileContent_richTextBox.TabIndex = 1;
            this.fileContent_richTextBox.Text = "";
            // 
            // fileContent_groupBox
            // 
            this.fileContent_groupBox.Controls.Add(this.fileContent_richTextBox);
            this.fileContent_groupBox.Location = new System.Drawing.Point(12, 37);
            this.fileContent_groupBox.Name = "fileContent_groupBox";
            this.fileContent_groupBox.Size = new System.Drawing.Size(487, 215);
            this.fileContent_groupBox.TabIndex = 2;
            this.fileContent_groupBox.TabStop = false;
            this.fileContent_groupBox.Text = "Содержимое файла";
            // 
            // stat_grid
            // 
            this.stat_grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.stat_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.stat_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stat_grid.Location = new System.Drawing.Point(9, 19);
            this.stat_grid.Name = "stat_grid";
            this.stat_grid.Size = new System.Drawing.Size(468, 225);
            this.stat_grid.TabIndex = 3;
            // 
            // stat_groupBox
            // 
            this.stat_groupBox.Controls.Add(this.stat_grid);
            this.stat_groupBox.Location = new System.Drawing.Point(12, 368);
            this.stat_groupBox.Name = "stat_groupBox";
            this.stat_groupBox.Size = new System.Drawing.Size(487, 256);
            this.stat_groupBox.TabIndex = 3;
            this.stat_groupBox.TabStop = false;
            this.stat_groupBox.Text = "Статистика";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_ToolStripMenuItem,
            this.settings_ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(514, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // file_ToolStripMenuItem
            // 
            this.file_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_ToolStripMenuItem,
            this.exportReport_ToolStripMenuItem});
            this.file_ToolStripMenuItem.Name = "file_ToolStripMenuItem";
            this.file_ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.file_ToolStripMenuItem.Text = "Файл";
            // 
            // open_ToolStripMenuItem
            // 
            this.open_ToolStripMenuItem.Name = "open_ToolStripMenuItem";
            this.open_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.open_ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.open_ToolStripMenuItem.Text = "Открыть";
            this.open_ToolStripMenuItem.Click += new System.EventHandler(this.Open_ToolStripMenuItem_Click);
            // 
            // exportReport_ToolStripMenuItem
            // 
            this.exportReport_ToolStripMenuItem.Name = "exportReport_ToolStripMenuItem";
            this.exportReport_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.exportReport_ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exportReport_ToolStripMenuItem.Text = "Сохранить отчет";
            this.exportReport_ToolStripMenuItem.Click += new System.EventHandler(this.ExportReportToolStripMenuItem_Click);
            // 
            // settings_ToolStripMenuItem
            // 
            this.settings_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operatorsSettings_ToolStripMenuItem});
            this.settings_ToolStripMenuItem.Name = "settings_ToolStripMenuItem";
            this.settings_ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settings_ToolStripMenuItem.Text = "Настройки";
            // 
            // operatorsSettings_ToolStripMenuItem
            // 
            this.operatorsSettings_ToolStripMenuItem.Name = "operatorsSettings_ToolStripMenuItem";
            this.operatorsSettings_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.operatorsSettings_ToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.operatorsSettings_ToolStripMenuItem.Text = "Настройка операторов";
            this.operatorsSettings_ToolStripMenuItem.Click += new System.EventHandler(this.operatorsSettings_ToolStripMenuItem_Click);
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
            this.progress_groupBox.Location = new System.Drawing.Point(12, 273);
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
            this.ClientSize = new System.Drawing.Size(514, 635);
            this.Controls.Add(this.progress_groupBox);
            this.Controls.Add(this.stat_groupBox);
            this.Controls.Add(this.fileContent_groupBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Code_parserForm";
            this.Text = "Code parser";
            this.fileContent_groupBox.ResumeLayout(false);
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

        private System.Windows.Forms.RichTextBox fileContent_richTextBox;
        private System.Windows.Forms.GroupBox fileContent_groupBox;
        private System.Windows.Forms.DataGridView stat_grid;
        private System.Windows.Forms.GroupBox stat_groupBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem file_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem open_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportReport_ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox progress_groupBox;
        private System.Windows.Forms.Label prograss_label;
        private System.Windows.Forms.ToolStripMenuItem settings_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operatorsSettings_ToolStripMenuItem;
    }
}

