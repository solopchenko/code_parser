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

        public bool flag = false;

        public Code_parserForm()
        {
            InitializeComponent();

            main = new Main();

            //Настройки таблицы статистики
            stat_grid.GridColor = Color.Black;
            stat_grid.RowHeadersVisible = false;
            stat_grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            stat_grid.BorderStyle = BorderStyle.None;
            stat_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            progressBar.Value = 0;
        }

        private void open_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Если нить свободна
            if (backgroundWorker.IsBusy != true)
            {
                
                setProgress(progressBar, prograss_label, 0);

                //Сброс статистики
                main.Reset();


                string fileName = main.OpenDialog("Выберите файл с исходным кодом","C# code *.cs | *.CS");


                if (!String.IsNullOrEmpty(fileName))
                {
                    setProgress(progressBar, prograss_label, 15);

                    main.code.SetCodeFromFile(fileName);

                    fileContent_richTextBox.Text = main.code.raw_code;

                    Random rnd = new Random();

                    if (main.code.raw_code.Length < 2000)
                    {
                        setProgress(progressBar, prograss_label, rnd.Next(95, 98));
                    }
                    else
                    {
                        setProgress(progressBar, prograss_label, rnd.Next(80, 98));
                    }

                    backgroundWorker.RunWorkerAsync();
                }
            }

            else
            {
                MessageBox.Show("Дождитесь окончания предыдущей операции проверки файла.", "Операция не может быть выполнена", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Открытие папки
        private void openFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fileContent_richTextBox.Clear();

            List<string> files = main.OpenFolder("*.cs");

            if ((files != null) && (files.Count > 0))
            {
                int fileCount = 0;
                while (fileCount < files.Count)
                {
                    if (backgroundWorker.IsBusy != true)
                    {
                        setProgress(progressBar, prograss_label, 15);

                        main.code.SetCodeFromFile(files[fileCount]);

                        fileContent_richTextBox.Text += main.code.raw_code;

                        Random rnd = new Random();

                        if (main.code.raw_code.Length < 2000)
                        {
                            setProgress(progressBar, prograss_label, rnd.Next(95, 98));
                        }
                        else
                        {
                            setProgress(progressBar, prograss_label, rnd.Next(80, 98));
                        }

                        fileCount = fileCount + 1;    
                        backgroundWorker.RunWorkerAsync();
                        //backgroundWorker.WorkerSupportsCancellation ??
                    }
                }
            }
            else
            {
                MessageBox.Show("В выбранной папке отсутсвуют файлы с исходным кодом C#.", "Файлы не найлдены", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }  
        }

        //Тело нити
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            main.code.CountOperators(main.operators);
        }

        //Завершение нити
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            }

            //Оповещение о завершении обработки очередного файла
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
    }
}
