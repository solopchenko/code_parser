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
        public AppFunctions f;

        public Code_parserForm()
        {
            InitializeComponent();

            f = new AppFunctions();

            stat_grid.GridColor = Color.Black;

            stat_grid.RowHeadersVisible = false;

            stat_grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            stat_grid.BorderStyle = BorderStyle.None;

            stat_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            progressBar.Value = 0;
        }

        private void Open_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy != true)
            {
                progress(progressBar, prograss_label, 0);
                string FileName = f.OpenDialog();

                if (!String.IsNullOrEmpty(FileName))
                {
                    progress(progressBar, prograss_label, 15);
                    if (f.ReadFile(FileName))
                    {
                        backgroundWorker.RunWorkerAsync();
                        FileContent_richTextBox.Text = f.raw_code;

                        Random rnd = new Random();

                        if (f.raw_code.Length < 2000)
                        {
                            progress(progressBar, prograss_label, rnd.Next(95, 98));
                        }
                        else
                        {
                            progress(progressBar, prograss_label, rnd.Next(80, 98));
                        }

                    }
                }
            }

            else
            {
                MessageBox.Show("Дождитесь окончания предыдущей операции проверки файла.", "Операция не может быть выполнена", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ExportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.ExportReport();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            f.CountOperators();
        }

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
                progress(progressBar, prograss_label, 100);

                stat_grid.DataSource = f.operators.ToList();

                stat_grid.Columns[0].HeaderText = "Оператор";
                stat_grid.Columns[1].HeaderText = "Количество";
            }


        }

        public void progress(ProgressBar pg, Label lb, int value)
        {
            pg.Value = value;
            lb.Text = value.ToString() + "%";
        }
    }
}
