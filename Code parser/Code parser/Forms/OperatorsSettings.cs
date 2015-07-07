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
    public partial class OperatorsSettings : Form
    {
        public Main main;

        public OperatorsSettings(Main m)
        {
            InitializeComponent();

            main = m;

            operators_grid.GridColor = Color.Black;
            operators_grid.RowHeadersVisible = false;
            operators_grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            operators_grid.BorderStyle = BorderStyle.None;
            operators_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            operators_grid.Columns.Add("operators", "Операторы");

            foreach (var op in main.operators.operators_list)
            {
                operators_grid.Rows.Add(op);
            }

            operators_grid.Columns[0].DefaultCellStyle.DataSourceNullValue = " ";
        }



        private void saveOperatorsSettings_btn_Click(object sender, EventArgs e)
        {
            List<string> new_operators = new List<string>();

            for (int i = 0; i < operators_grid.Rows.Count - 1; i++)
            {
                new_operators.Add(operators_grid.Rows[i].Cells[0].Value.ToString());
            }

            main.operators.SetOperators(new_operators);

            this.Close();
        }
    }
}
