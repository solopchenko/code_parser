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

            progressBar.Value = 0;
        }

        //Открытие файла
        private void openFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Кнопка расчета трудоемкости
            countLaboriousness_button.Enabled = false;
            //Очистка параметров расчета трудоемкости
            ClearLaboriousnessParams();

            //Если нить свободна
            if (!directory_backgroundWorker.IsBusy && !file_backgroundWorker.IsBusy)
            {
                
                setProgress(progressBar, prograss_label, 0);

                //Сброс статистики
                main.Reset();


                string fileName = main.OpenDialog("Выберите файл с исходным кодом","C# code *.cs | *.CS");


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

                //Кнопка расчета трудоемкости
                countLaboriousness_button.Enabled = true;
            }
        }



        //Открытие папки
        private void openFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Кнопка расчета трудоемкости
            countLaboriousness_button.Enabled = false;
            //Очистка параметров расчета трудоемкости
            ClearLaboriousnessParams();

            if (!directory_backgroundWorker.IsBusy && !file_backgroundWorker.IsBusy)
            {
                //Сброс статистики
                main.Reset();

                fileContent_richTextBox.Clear();

                List<string> files = main.OpenFolder("*.cs");


                if ((files != null) && (files.Count > 0))
                {
                    directory_backgroundWorker.RunWorkerAsync(files);
                }
                else
                {
                    MessageBox.Show("В выбранной папке отсутсвуют файлы с исходным кодом C#.", "Файлы не найлдены", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                //Кнопка расчета трудоемкости
                countLaboriousness_button.Enabled = true;
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
            lab.N = main.operators.CountAllOperators();
            N_textBox.Text = lab.N.ToString();

            lab.Kn = Convert.ToDouble(Kn_textBox.Text);
            lab.Pp = Convert.ToDouble(Pp_textBox.Text);

            lab.K2 = Convert.ToDouble(K2_textBox.Text);
            lab.K3 = Convert.ToDouble(K3_textBox.Text);

            laboriousness_textBox.Text = lab.CounLaboriousness().ToString();
        }

        //Сброс трудоемкости
        private void ClearLaboriousnessParams()
        {
            N_textBox.Clear();
            laboriousness_textBox.Clear();
        }

        //Выбор значения Knp для расчета трудоемкости
        private void Knp_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;

            string currentButton = radioBtn.Name;
            if (radioBtn.Checked == true)
            {
                switch (currentButton)
                {
                    case "Knp01_radioButton":
                        lab.Knp = 0.1;
                        break;
                    case "Knp06_radioButton":
                        lab.Knp = 0.6;
                        break;
                    case "Knp1_radioButton":
                        lab.Knp = 1.0;
                        break;
                }
            }
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
    }
}
