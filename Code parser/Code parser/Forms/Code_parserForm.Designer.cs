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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.listOfFiles_tabPage = new System.Windows.Forms.TabPage();
            this.listOfFiles_listBox = new System.Windows.Forms.ListBox();
            this.contentFiles_tabPage = new System.Windows.Forms.TabPage();
            this.stat_grid = new System.Windows.Forms.DataGridView();
            this.stat_groupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.file_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolder_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportReport_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportWord_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settings_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorsSettings_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.file_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progress_groupBox = new System.Windows.Forms.GroupBox();
            this.prograss_label = new System.Windows.Forms.Label();
            this.directory_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Laboriousness_groupBox = new System.Windows.Forms.GroupBox();
            this.laboriousness_textBox = new System.Windows.Forms.TextBox();
            this.countLaboriousness_button = new System.Windows.Forms.Button();
            this.K3_groupBox = new System.Windows.Forms.GroupBox();
            this.K3_textBox = new System.Windows.Forms.TextBox();
            this.Kn_groupBox = new System.Windows.Forms.GroupBox();
            this.Kn_textBox = new System.Windows.Forms.TextBox();
            this.K2_groupBox = new System.Windows.Forms.GroupBox();
            this.K2_textBox = new System.Windows.Forms.TextBox();
            this.K1_groupBox = new System.Windows.Forms.GroupBox();
            this.K1_1_radioButton = new System.Windows.Forms.RadioButton();
            this.K1_125_radioButton = new System.Windows.Forms.RadioButton();
            this.Knp_groupBox = new System.Windows.Forms.GroupBox();
            this.Knp_textBox = new System.Windows.Forms.TextBox();
            this.Knp_trackBar = new System.Windows.Forms.TrackBar();
            this.Pp_groupBox = new System.Windows.Forms.GroupBox();
            this.Pp_textBox = new System.Windows.Forms.TextBox();
            this.N_groupBox = new System.Windows.Forms.GroupBox();
            this.N_textBox = new System.Windows.Forms.TextBox();
            this.dayDuration_groupBox = new System.Windows.Forms.GroupBox();
            this.dayDuration_textBox = new System.Windows.Forms.TextBox();
            this.fileContent_groupBox.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.listOfFiles_tabPage.SuspendLayout();
            this.contentFiles_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stat_grid)).BeginInit();
            this.stat_groupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.progress_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Laboriousness_groupBox.SuspendLayout();
            this.K3_groupBox.SuspendLayout();
            this.Kn_groupBox.SuspendLayout();
            this.K2_groupBox.SuspendLayout();
            this.K1_groupBox.SuspendLayout();
            this.Knp_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Knp_trackBar)).BeginInit();
            this.Pp_groupBox.SuspendLayout();
            this.N_groupBox.SuspendLayout();
            this.dayDuration_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileContent_richTextBox
            // 
            this.fileContent_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileContent_richTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.fileContent_richTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileContent_richTextBox.Location = new System.Drawing.Point(8, 6);
            this.fileContent_richTextBox.Name = "fileContent_richTextBox";
            this.fileContent_richTextBox.ReadOnly = true;
            this.fileContent_richTextBox.Size = new System.Drawing.Size(570, 152);
            this.fileContent_richTextBox.TabIndex = 1;
            this.fileContent_richTextBox.Text = "";
            // 
            // fileContent_groupBox
            // 
            this.fileContent_groupBox.Controls.Add(this.tabControl);
            this.fileContent_groupBox.Location = new System.Drawing.Point(13, 27);
            this.fileContent_groupBox.Name = "fileContent_groupBox";
            this.fileContent_groupBox.Size = new System.Drawing.Size(607, 215);
            this.fileContent_groupBox.TabIndex = 2;
            this.fileContent_groupBox.TabStop = false;
            this.fileContent_groupBox.Text = "Область просмотра";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.listOfFiles_tabPage);
            this.tabControl.Controls.Add(this.contentFiles_tabPage);
            this.tabControl.Location = new System.Drawing.Point(8, 19);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(594, 190);
            this.tabControl.TabIndex = 2;
            // 
            // listOfFiles_tabPage
            // 
            this.listOfFiles_tabPage.Controls.Add(this.listOfFiles_listBox);
            this.listOfFiles_tabPage.Location = new System.Drawing.Point(4, 22);
            this.listOfFiles_tabPage.Name = "listOfFiles_tabPage";
            this.listOfFiles_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.listOfFiles_tabPage.Size = new System.Drawing.Size(586, 164);
            this.listOfFiles_tabPage.TabIndex = 0;
            this.listOfFiles_tabPage.Text = "Список файлов";
            this.listOfFiles_tabPage.UseVisualStyleBackColor = true;
            // 
            // listOfFiles_listBox
            // 
            this.listOfFiles_listBox.FormattingEnabled = true;
            this.listOfFiles_listBox.Location = new System.Drawing.Point(8, 6);
            this.listOfFiles_listBox.Name = "listOfFiles_listBox";
            this.listOfFiles_listBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listOfFiles_listBox.Size = new System.Drawing.Size(570, 147);
            this.listOfFiles_listBox.TabIndex = 0;
            // 
            // contentFiles_tabPage
            // 
            this.contentFiles_tabPage.Controls.Add(this.fileContent_richTextBox);
            this.contentFiles_tabPage.Location = new System.Drawing.Point(4, 22);
            this.contentFiles_tabPage.Name = "contentFiles_tabPage";
            this.contentFiles_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.contentFiles_tabPage.Size = new System.Drawing.Size(586, 164);
            this.contentFiles_tabPage.TabIndex = 1;
            this.contentFiles_tabPage.Text = "Содержимое файлов";
            this.contentFiles_tabPage.UseVisualStyleBackColor = true;
            // 
            // stat_grid
            // 
            this.stat_grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.stat_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.stat_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stat_grid.Location = new System.Drawing.Point(9, 19);
            this.stat_grid.Name = "stat_grid";
            this.stat_grid.Size = new System.Drawing.Size(307, 241);
            this.stat_grid.TabIndex = 3;
            // 
            // stat_groupBox
            // 
            this.stat_groupBox.Controls.Add(this.stat_grid);
            this.stat_groupBox.Location = new System.Drawing.Point(11, 155);
            this.stat_groupBox.Name = "stat_groupBox";
            this.stat_groupBox.Size = new System.Drawing.Size(331, 269);
            this.stat_groupBox.TabIndex = 3;
            this.stat_groupBox.TabStop = false;
            this.stat_groupBox.Text = "Статистика операторов";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_ToolStripMenuItem,
            this.settings_ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(637, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // file_ToolStripMenuItem
            // 
            this.file_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile_ToolStripMenuItem,
            this.openFolder_ToolStripMenuItem,
            this.exportReport_ToolStripMenuItem,
            this.exportWord_ToolStripMenuItem});
            this.file_ToolStripMenuItem.Name = "file_ToolStripMenuItem";
            this.file_ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.file_ToolStripMenuItem.Text = "Файл";
            // 
            // openFile_ToolStripMenuItem
            // 
            this.openFile_ToolStripMenuItem.Name = "openFile_ToolStripMenuItem";
            this.openFile_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFile_ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.openFile_ToolStripMenuItem.Text = "Открыть файл";
            this.openFile_ToolStripMenuItem.Click += new System.EventHandler(this.openFile_ToolStripMenuItem_Click);
            // 
            // openFolder_ToolStripMenuItem
            // 
            this.openFolder_ToolStripMenuItem.Name = "openFolder_ToolStripMenuItem";
            this.openFolder_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.openFolder_ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.openFolder_ToolStripMenuItem.Text = "Открыть папку";
            this.openFolder_ToolStripMenuItem.Click += new System.EventHandler(this.openFolder_ToolStripMenuItem_Click);
            // 
            // exportReport_ToolStripMenuItem
            // 
            this.exportReport_ToolStripMenuItem.Name = "exportReport_ToolStripMenuItem";
            this.exportReport_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.exportReport_ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.exportReport_ToolStripMenuItem.Text = "Статистика операторов в CSV";
            this.exportReport_ToolStripMenuItem.Click += new System.EventHandler(this.exportReport_ToolStripMenuItem_Click);
            // 
            // exportWord_ToolStripMenuItem
            // 
            this.exportWord_ToolStripMenuItem.Name = "exportWord_ToolStripMenuItem";
            this.exportWord_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.exportWord_ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.exportWord_ToolStripMenuItem.Text = "Открыть отчет в Word";
            this.exportWord_ToolStripMenuItem.Click += new System.EventHandler(this.exportWord_ToolStripMenuItem_Click);
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
            // file_backgroundWorker
            // 
            this.file_backgroundWorker.WorkerReportsProgress = true;
            this.file_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.file_backgroundWorker_DoWork);
            this.file_backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.file_backgroundWorker_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 25);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(558, 19);
            this.progressBar.TabIndex = 5;
            // 
            // progress_groupBox
            // 
            this.progress_groupBox.Controls.Add(this.prograss_label);
            this.progress_groupBox.Controls.Add(this.progressBar);
            this.progress_groupBox.Location = new System.Drawing.Point(12, 248);
            this.progress_groupBox.Name = "progress_groupBox";
            this.progress_groupBox.Size = new System.Drawing.Size(607, 63);
            this.progress_groupBox.TabIndex = 6;
            this.progress_groupBox.TabStop = false;
            this.progress_groupBox.Text = "Степень готовности";
            // 
            // prograss_label
            // 
            this.prograss_label.AutoSize = true;
            this.prograss_label.Location = new System.Drawing.Point(574, 29);
            this.prograss_label.Name = "prograss_label";
            this.prograss_label.Size = new System.Drawing.Size(21, 13);
            this.prograss_label.TabIndex = 6;
            this.prograss_label.Text = "0%";
            // 
            // directory_backgroundWorker
            // 
            this.directory_backgroundWorker.WorkerReportsProgress = true;
            this.directory_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.directory_backgroundWorker_DoWork);
            this.directory_backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.directory_backgroundWorker_ProgressChanged);
            this.directory_backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.directory_backgroundWorker_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dayDuration_groupBox);
            this.groupBox1.Controls.Add(this.Laboriousness_groupBox);
            this.groupBox1.Controls.Add(this.K3_groupBox);
            this.groupBox1.Controls.Add(this.Kn_groupBox);
            this.groupBox1.Controls.Add(this.K2_groupBox);
            this.groupBox1.Controls.Add(this.stat_groupBox);
            this.groupBox1.Controls.Add(this.K1_groupBox);
            this.groupBox1.Controls.Add(this.Knp_groupBox);
            this.groupBox1.Controls.Add(this.Pp_groupBox);
            this.groupBox1.Controls.Add(this.N_groupBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 503);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расчет трудоемкости программного обеспечения";
            // 
            // Laboriousness_groupBox
            // 
            this.Laboriousness_groupBox.Controls.Add(this.laboriousness_textBox);
            this.Laboriousness_groupBox.Controls.Add(this.countLaboriousness_button);
            this.Laboriousness_groupBox.Location = new System.Drawing.Point(9, 430);
            this.Laboriousness_groupBox.Name = "Laboriousness_groupBox";
            this.Laboriousness_groupBox.Size = new System.Drawing.Size(331, 67);
            this.Laboriousness_groupBox.TabIndex = 28;
            this.Laboriousness_groupBox.TabStop = false;
            this.Laboriousness_groupBox.Text = "Трудоемкость разработки программного компонента (человеко-дни)";
            // 
            // laboriousness_textBox
            // 
            this.laboriousness_textBox.Location = new System.Drawing.Point(11, 32);
            this.laboriousness_textBox.Name = "laboriousness_textBox";
            this.laboriousness_textBox.ReadOnly = true;
            this.laboriousness_textBox.Size = new System.Drawing.Size(215, 20);
            this.laboriousness_textBox.TabIndex = 16;
            // 
            // countLaboriousness_button
            // 
            this.countLaboriousness_button.Location = new System.Drawing.Point(243, 31);
            this.countLaboriousness_button.Name = "countLaboriousness_button";
            this.countLaboriousness_button.Size = new System.Drawing.Size(75, 23);
            this.countLaboriousness_button.TabIndex = 14;
            this.countLaboriousness_button.Text = "Расчитать";
            this.countLaboriousness_button.UseVisualStyleBackColor = true;
            this.countLaboriousness_button.Click += new System.EventHandler(this.countLaboriousness_button_Click);
            // 
            // K3_groupBox
            // 
            this.K3_groupBox.Controls.Add(this.K3_textBox);
            this.K3_groupBox.Location = new System.Drawing.Point(349, 430);
            this.K3_groupBox.Name = "K3_groupBox";
            this.K3_groupBox.Size = new System.Drawing.Size(252, 67);
            this.K3_groupBox.TabIndex = 27;
            this.K3_groupBox.TabStop = false;
            this.K3_groupBox.Text = "Коэффициент, учитывающий структуру используемых вычислительных средств";
            // 
            // K3_textBox
            // 
            this.K3_textBox.Location = new System.Drawing.Point(11, 34);
            this.K3_textBox.Name = "K3_textBox";
            this.K3_textBox.Size = new System.Drawing.Size(230, 20);
            this.K3_textBox.TabIndex = 11;
            this.K3_textBox.Text = "1,0";
            // 
            // Kn_groupBox
            // 
            this.Kn_groupBox.Controls.Add(this.Kn_textBox);
            this.Kn_groupBox.Location = new System.Drawing.Point(348, 93);
            this.Kn_groupBox.Name = "Kn_groupBox";
            this.Kn_groupBox.Size = new System.Drawing.Size(253, 89);
            this.Kn_groupBox.TabIndex = 27;
            this.Kn_groupBox.TabStop = false;
            this.Kn_groupBox.Text = "Коэффициент, пересчета производительности проектировщиков алгоритмов к производит" +
    "ельности разработчиков программ";
            // 
            // Kn_textBox
            // 
            this.Kn_textBox.Location = new System.Drawing.Point(11, 62);
            this.Kn_textBox.Name = "Kn_textBox";
            this.Kn_textBox.Size = new System.Drawing.Size(236, 20);
            this.Kn_textBox.TabIndex = 7;
            this.Kn_textBox.Text = "0,58";
            // 
            // K2_groupBox
            // 
            this.K2_groupBox.Controls.Add(this.K2_textBox);
            this.K2_groupBox.Location = new System.Drawing.Point(349, 345);
            this.K2_groupBox.Name = "K2_groupBox";
            this.K2_groupBox.Size = new System.Drawing.Size(252, 79);
            this.K2_groupBox.TabIndex = 25;
            this.K2_groupBox.TabStop = false;
            this.K2_groupBox.Text = "Поправочный коэффициент, учитывающий затраты на отладку в зависимости от размеров" +
    " программы";
            // 
            // K2_textBox
            // 
            this.K2_textBox.Location = new System.Drawing.Point(11, 50);
            this.K2_textBox.Name = "K2_textBox";
            this.K2_textBox.ReadOnly = true;
            this.K2_textBox.Size = new System.Drawing.Size(234, 20);
            this.K2_textBox.TabIndex = 10;
            // 
            // K1_groupBox
            // 
            this.K1_groupBox.Controls.Add(this.K1_1_radioButton);
            this.K1_groupBox.Controls.Add(this.K1_125_radioButton);
            this.K1_groupBox.Location = new System.Drawing.Point(349, 279);
            this.K1_groupBox.Name = "K1_groupBox";
            this.K1_groupBox.Size = new System.Drawing.Size(252, 60);
            this.K1_groupBox.TabIndex = 24;
            this.K1_groupBox.TabStop = false;
            this.K1_groupBox.Text = "Коэффициент, учитывающий работу в реальном масштабе времени";
            // 
            // K1_1_radioButton
            // 
            this.K1_1_radioButton.AutoSize = true;
            this.K1_1_radioButton.Checked = true;
            this.K1_1_radioButton.Location = new System.Drawing.Point(57, 33);
            this.K1_1_radioButton.Name = "K1_1_radioButton";
            this.K1_1_radioButton.Size = new System.Drawing.Size(31, 17);
            this.K1_1_radioButton.TabIndex = 20;
            this.K1_1_radioButton.TabStop = true;
            this.K1_1_radioButton.Text = "1";
            this.K1_1_radioButton.UseVisualStyleBackColor = true;
            this.K1_1_radioButton.CheckedChanged += new System.EventHandler(this.K1_radioButton_CheckedChanged);
            // 
            // K1_125_radioButton
            // 
            this.K1_125_radioButton.AutoSize = true;
            this.K1_125_radioButton.Location = new System.Drawing.Point(137, 33);
            this.K1_125_radioButton.Name = "K1_125_radioButton";
            this.K1_125_radioButton.Size = new System.Drawing.Size(46, 17);
            this.K1_125_radioButton.TabIndex = 21;
            this.K1_125_radioButton.Text = "1,25";
            this.K1_125_radioButton.UseVisualStyleBackColor = true;
            this.K1_125_radioButton.CheckedChanged += new System.EventHandler(this.K1_radioButton_CheckedChanged);
            // 
            // Knp_groupBox
            // 
            this.Knp_groupBox.Controls.Add(this.Knp_textBox);
            this.Knp_groupBox.Controls.Add(this.Knp_trackBar);
            this.Knp_groupBox.Location = new System.Drawing.Point(349, 188);
            this.Knp_groupBox.Name = "Knp_groupBox";
            this.Knp_groupBox.Size = new System.Drawing.Size(252, 85);
            this.Knp_groupBox.TabIndex = 22;
            this.Knp_groupBox.TabStop = false;
            this.Knp_groupBox.Text = "Коэффициент приемственности программного компонента";
            // 
            // Knp_textBox
            // 
            this.Knp_textBox.Location = new System.Drawing.Point(205, 34);
            this.Knp_textBox.Name = "Knp_textBox";
            this.Knp_textBox.ReadOnly = true;
            this.Knp_textBox.Size = new System.Drawing.Size(40, 20);
            this.Knp_textBox.TabIndex = 21;
            // 
            // Knp_trackBar
            // 
            this.Knp_trackBar.LargeChange = 2;
            this.Knp_trackBar.Location = new System.Drawing.Point(10, 34);
            this.Knp_trackBar.Name = "Knp_trackBar";
            this.Knp_trackBar.Size = new System.Drawing.Size(195, 45);
            this.Knp_trackBar.TabIndex = 20;
            this.Knp_trackBar.Value = 10;
            this.Knp_trackBar.ValueChanged += new System.EventHandler(this.Knp_trackBar_ValueChanged);
            // 
            // Pp_groupBox
            // 
            this.Pp_groupBox.Controls.Add(this.Pp_textBox);
            this.Pp_groupBox.Location = new System.Drawing.Point(348, 30);
            this.Pp_groupBox.Name = "Pp_groupBox";
            this.Pp_groupBox.Size = new System.Drawing.Size(254, 57);
            this.Pp_groupBox.TabIndex = 26;
            this.Pp_groupBox.TabStop = false;
            this.Pp_groupBox.Text = "Средняя производительность разработчиков (команда / день)";
            // 
            // Pp_textBox
            // 
            this.Pp_textBox.Location = new System.Drawing.Point(11, 31);
            this.Pp_textBox.Name = "Pp_textBox";
            this.Pp_textBox.Size = new System.Drawing.Size(236, 20);
            this.Pp_textBox.TabIndex = 6;
            this.Pp_textBox.Text = "2,88";
            // 
            // N_groupBox
            // 
            this.N_groupBox.Controls.Add(this.N_textBox);
            this.N_groupBox.Location = new System.Drawing.Point(11, 30);
            this.N_groupBox.Name = "N_groupBox";
            this.N_groupBox.Size = new System.Drawing.Size(331, 57);
            this.N_groupBox.TabIndex = 23;
            this.N_groupBox.TabStop = false;
            this.N_groupBox.Text = "Общее количество операторов (шт.)";
            // 
            // N_textBox
            // 
            this.N_textBox.Location = new System.Drawing.Point(9, 19);
            this.N_textBox.Name = "N_textBox";
            this.N_textBox.ReadOnly = true;
            this.N_textBox.Size = new System.Drawing.Size(307, 20);
            this.N_textBox.TabIndex = 13;
            // 
            // dayDuration_groupBox
            // 
            this.dayDuration_groupBox.Controls.Add(this.dayDuration_textBox);
            this.dayDuration_groupBox.Location = new System.Drawing.Point(12, 93);
            this.dayDuration_groupBox.Name = "dayDuration_groupBox";
            this.dayDuration_groupBox.Size = new System.Drawing.Size(330, 55);
            this.dayDuration_groupBox.TabIndex = 29;
            this.dayDuration_groupBox.TabStop = false;
            this.dayDuration_groupBox.Text = "Продолжительность рабочего дня (часы)";
            // 
            // dayDuration_textBox
            // 
            this.dayDuration_textBox.Location = new System.Drawing.Point(8, 20);
            this.dayDuration_textBox.Name = "dayDuration_textBox";
            this.dayDuration_textBox.Size = new System.Drawing.Size(307, 20);
            this.dayDuration_textBox.TabIndex = 0;
            this.dayDuration_textBox.Text = "8,25";
            // 
            // Code_parserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 832);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progress_groupBox);
            this.Controls.Add(this.fileContent_groupBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Code_parserForm";
            this.Text = "Code parser";
            this.fileContent_groupBox.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.listOfFiles_tabPage.ResumeLayout(false);
            this.contentFiles_tabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stat_grid)).EndInit();
            this.stat_groupBox.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.progress_groupBox.ResumeLayout(false);
            this.progress_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.Laboriousness_groupBox.ResumeLayout(false);
            this.Laboriousness_groupBox.PerformLayout();
            this.K3_groupBox.ResumeLayout(false);
            this.K3_groupBox.PerformLayout();
            this.Kn_groupBox.ResumeLayout(false);
            this.Kn_groupBox.PerformLayout();
            this.K2_groupBox.ResumeLayout(false);
            this.K2_groupBox.PerformLayout();
            this.K1_groupBox.ResumeLayout(false);
            this.K1_groupBox.PerformLayout();
            this.Knp_groupBox.ResumeLayout(false);
            this.Knp_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Knp_trackBar)).EndInit();
            this.Pp_groupBox.ResumeLayout(false);
            this.Pp_groupBox.PerformLayout();
            this.N_groupBox.ResumeLayout(false);
            this.N_groupBox.PerformLayout();
            this.dayDuration_groupBox.ResumeLayout(false);
            this.dayDuration_groupBox.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem openFile_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolder_ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker file_backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox progress_groupBox;
        private System.Windows.Forms.Label prograss_label;
        private System.Windows.Forms.ToolStripMenuItem settings_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operatorsSettings_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportReport_ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker directory_backgroundWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox N_textBox;
        private System.Windows.Forms.TextBox K3_textBox;
        private System.Windows.Forms.TextBox K2_textBox;
        private System.Windows.Forms.TextBox Kn_textBox;
        private System.Windows.Forms.TextBox Pp_textBox;
        private System.Windows.Forms.Button countLaboriousness_button;
        private System.Windows.Forms.TextBox laboriousness_textBox;
        private System.Windows.Forms.RadioButton K1_125_radioButton;
        private System.Windows.Forms.RadioButton K1_1_radioButton;
        private System.Windows.Forms.GroupBox Knp_groupBox;
        private System.Windows.Forms.GroupBox N_groupBox;
        private System.Windows.Forms.GroupBox K1_groupBox;
        private System.Windows.Forms.GroupBox K2_groupBox;
        private System.Windows.Forms.GroupBox Pp_groupBox;
        private System.Windows.Forms.GroupBox K3_groupBox;
        private System.Windows.Forms.GroupBox Kn_groupBox;
        private System.Windows.Forms.GroupBox Laboriousness_groupBox;
        private System.Windows.Forms.TrackBar Knp_trackBar;
        private System.Windows.Forms.TextBox Knp_textBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage listOfFiles_tabPage;
        private System.Windows.Forms.TabPage contentFiles_tabPage;
        private System.Windows.Forms.ListBox listOfFiles_listBox;
        private System.Windows.Forms.ToolStripMenuItem exportWord_ToolStripMenuItem;
        private System.Windows.Forms.GroupBox dayDuration_groupBox;
        private System.Windows.Forms.TextBox dayDuration_textBox;
    }
}

