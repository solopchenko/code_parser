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
        }

        private void Open_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.AnalyzeCode();

            FileContent_richTextBox.Text = f.raw_code;

            stat_grid.DataSource = f.operators.ToList();

            stat_grid.Columns[0].HeaderText = "Оператор";
            stat_grid.Columns[1].HeaderText = "Количество";
        }

        private void ExportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.ExportReport();
        }
    }
}
