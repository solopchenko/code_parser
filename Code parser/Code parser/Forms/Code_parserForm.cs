using Code_parser.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_parser
{
    public partial class Code_parserForm : Form
    {
        
        public Main main;

        public Laboriousness lab;

        public Code_parserForm()
        {
            InitializeComponent();

            main = new Main();

            lab = new Laboriousness();

            //Настройки таблицы статистики
            stat_grid.GridColor = Color.Black;
            stat_grid.RowHeadersVisible = false;
            stat_grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            stat_grid.BorderStyle = BorderStyle.None;
            stat_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Кнопка расчета трудоемкости
            countLaboriousness_button.Enabled = false;

            //Knp trackBar


            //Экспорт
            exportWord_ToolStripMenuItem.Enabled = false;
            exportReport_ToolStripMenuItem.Enabled = false;

            //Заполнение трудоемкости
            N_textBox.Text = lab.N.ToString();
            Knp_textBox.Text = lab.Knp.ToString();
            Pp_textBox.Text = lab.Pp.ToString();
            Knp_trackBar.Value = (int)(lab.Knp * 10); 
            Kn_textBox.Text = lab.Kn.ToString();
            K2_textBox.Text = lab.K2.ToString();
            K3_textBox.Text = lab.K3.ToString();

            progressBar.Value = 0;
        }

        //Открытие файла
        private void openFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Кнопка расчета трудоемкости
            countLaboriousness_button.Enabled = false;
            //Очистка параметров расчета трудоемкости
            ClearLaboriousnessParams();
            //Кнопка расчета трудоемкости
            countLaboriousness_button.Enabled = false;
            //Экспорт
            exportReport_ToolStripMenuItem.Enabled = false;

            //Если нить свободна
            if (!directory_backgroundWorker.IsBusy && !file_backgroundWorker.IsBusy)
            {
                
                setProgress(progressBar, prograss_label, 0);

                //Сброс статистики
                main.Reset();


                string fileName = main.OpenDialog("Выберите файл с исходным кодом", "C# code|*.cs|C code|*.c|C++ code|*.cpp");


                if (!String.IsNullOrEmpty(fileName))
                {
                    setProgress(progressBar, prograss_label, 15);

                    main.code.SetCodeFromFile(fileName);

                    fileContent_richTextBox.Text = main.code.ShowCode();

                    Random rnd = new Random();

                    if (main.code.raw_code.Length < 2000)
                    {
                        setProgress(progressBar, prograss_label, rnd.Next(95, 98));
                    }
                    else
                    {
                        setProgress(progressBar, prograss_label, rnd.Next(80, 98));
                    }

                    file_backgroundWorker.RunWorkerAsync();
                }
            }

            else
            {
                MessageBox.Show("Дождитесь окончания предыдущей операции анализа файла.", "Операция не может быть выполнена", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Тело нити обработки файла
        private void file_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            main.code.CountOperatorsFromFile(main.operators);
        }

        //Завершение нити обработки файла
        private void file_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Операция прервана.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Ошибка: " + e.Error.Message);
            }
            else
            {
                //Успешное завершение
                setProgress(progressBar, prograss_label, 100);

                stat_grid.DataSource = main.operators.operators_dic.ToList();

                stat_grid.Columns[0].HeaderText = "Оператор";
                stat_grid.Columns[1].HeaderText = "Количество";

                //Общее количество операторов
                lab.N = main.operators.CountAllOperators();
                N_textBox.Text = lab.N.ToString();

                //K2 - поправочный коэффициент
                lab.K2 = lab.SearchK2(lab.N, 1.0).value;
                K2_textBox.Text = lab.K2.ToString();

                //Кнопка расчета трудоемкости
                countLaboriousness_button.Enabled = true;

                //Экспорт
                exportReport_ToolStripMenuItem.Enabled = true;

                //Открытие вкладки с содержанием
                tabControl.SelectedIndex = 1;
            }
        }



        //Открытие папки
        private void openFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Кнопка расчета трудоемкости
            countLaboriousness_button.Enabled = false;
            //Очистка параметров расчета трудоемкости
            ClearLaboriousnessParams();
            //Кнопка расчета трудоемкости
            countLaboriousness_button.Enabled = false;
            //Экспорт
            exportReport_ToolStripMenuItem.Enabled = false;

            if (!directory_backgroundWorker.IsBusy && !file_backgroundWorker.IsBusy)
            {
                //Сброс статистики
                main.Reset();

                fileContent_richTextBox.Clear();

                List<string> files = main.OpenFolder();

                listOfFiles_listBox.DataSource = files;


                if ((files != null) && (files.Count > 0))
                {
                    directory_backgroundWorker.RunWorkerAsync(files);
                }
                else
                {
                    MessageBox.Show("В выбранной папке отсутствуют файлы с исходным кодом.", "Файлы не найлдены", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }  
            }
            else
            {
                MessageBox.Show("Дождитесь окончания предыдущей операции анализа файла.", "Операция не может быть выполнена", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Тело обработки директории
        private void directory_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Список файлов
            List<string> files = (List<string>)e.Argument;

            //Код из файлов для отображения на форме
            string content = String.Empty;

            //Счетчик файлов
            int filesCount = 0;
            if ((files != null) && (files.Count > 0))
            {
                while (filesCount < files.Count)
                {


                    main.code.SetCodeFromFile(files[filesCount]);
                    
                    content = content + main.code.ShowCode();
                    
                    main.code.CountOperatorsFromFile(main.operators);

                    //Оповещение directory_backgroundWorker о том, что очередной файл обработан
                    directory_backgroundWorker.ReportProgress(filesCount * 100 / files.Count);

                    filesCount++;
                }

                e.Result = content;
            }
        }

        //Завершение нити обработки директорий
        private void directory_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Операция прервана.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Ошибка: " + e.Error.Message);
            }
            else
            {
                
                //Успешное завершение
                setProgress(progressBar, prograss_label, 100);

                fileContent_richTextBox.Text = (string)e.Result;


                stat_grid.DataSource = main.operators.operators_dic.ToList();

                stat_grid.Columns[0].HeaderText = "Оператор";
                stat_grid.Columns[1].HeaderText = "Количество";

                //Общее количество операторов
                lab.N = main.operators.CountAllOperators();
                N_textBox.Text = lab.N.ToString();

                //K2 - поправочный коэффициент
                lab.K2 = lab.SearchK2(lab.N, 1.0).value;
                K2_textBox.Text = lab.K2.ToString();

                //Кнопка расчета трудоемкости
                countLaboriousness_button.Enabled = true;

                //Экспорт
                exportReport_ToolStripMenuItem.Enabled = true;

                //Открытие вкладки со списком файлов
                tabControl.SelectedIndex = 0;
            }

        }

        //Отображении прогресса обработки директории
        private void directory_backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            setProgress(progressBar, prograss_label, e.ProgressPercentage);
        }



        //Установка визуализации обработки файлов
        public void setProgress(ProgressBar pg, Label lb, int value)
        {
            pg.Value = value;
            lb.Text = value.ToString() + "%";
        }

        //Настройка операторов
        private void operatorsSettings_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperatorsSettings OperatorsSettingsForm = new OperatorsSettings(main);
            OperatorsSettingsForm.Show();
        }

        //Экспорт отчета
        private void exportReport_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = main.SaveDialog("Выберите место для сохранения отчета", "CSV file *.csv | *.CSV", "Report");

            main.operators.CreateReport(fileName);
        }

        //Расчет трудоемкости
        private void countLaboriousness_button_Click(object sender, EventArgs e)
        {
            try
            {
                lab.N = Convert.ToInt32(N_textBox.Text);

                lab.dayDuration = Convert.ToDouble(dayDuration_textBox.Text);

                lab.Kn = Convert.ToDouble(Kn_textBox.Text);
                lab.Pp = Convert.ToDouble(Pp_textBox.Text);

                lab.K2 = Convert.ToDouble(K2_textBox.Text);
                lab.K3 = Convert.ToDouble(K3_textBox.Text);

                if( (lab.dayDuration >= 0) && (lab.Kn >= 0) && (lab.Pp >=0) && (lab.K2 >= 0) && (lab.K3 >=0))
                {
                    lab.laboriousness = lab.CounLaboriousness();
                    lab.resultVal = lab.dayDuration * lab.laboriousness;
                    laboriousness_textBox.Text = lab.resultVal.ToString();
                }
                else
                {
                    MessageBox.Show("Коэффициенты не могут быть отрицательными.", "Проверьте коэффициенты", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Проверьте корректность ввода параметров для расчета трудоемкости разработки программного обеспечения.", "Проверьте коэффициенты", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Экспорт
            exportWord_ToolStripMenuItem.Enabled = true;
        }

        //Сброс трудоемкости
        private void ClearLaboriousnessParams()
        {
            N_textBox.Clear();
            laboriousness_textBox.Clear();
        }
        
        //Выбор значения K1 для расчета трудоемкости
        private void K1_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;

            string currentButton = radioBtn.Name;
            if (radioBtn.Checked == true)
            {
                switch (currentButton)
                {
                    case "K1_1_radioButton":
                        lab.K1 = 1.0;
                        break;
                    case "K1_125_radioButton":
                        lab.K1 = 1.25;
                        break;
                }
            }
        }

        private void Knp_trackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;

            double Knp_value = trackBar.Value / 10.0;
            lab.Knp = Knp_value;

            Knp_textBox.Text = Knp_value.ToString();
        }

        private void exportWord_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info(lab.dayDuration * lab.laboriousness, lab.N, 5, lab.Pp, lab.Kn, lab.Knp, lab.K1, lab.K2, lab.K3, lab.laboriousness);

            try
            {
                WordDocument document = new WordDocument(Application.StartupPath + "\\Resources\\report_template.dotx");
                document.ReportGeneration(info);
            }
            catch (Exception error)
            {
                MessageBox.Show("Ошибка экспорта в Microsoft Office Word.\n" + error, "Не удалось открыть файл", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
