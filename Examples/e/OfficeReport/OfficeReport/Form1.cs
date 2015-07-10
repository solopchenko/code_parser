using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OfficeReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info info  = new Info(100, 1, 2, 3, 4, 5, 6, 7, 8, 9);

            try
            {
                WordDocument document = new WordDocument(@"C:\Users\user\Desktop\rep1.dotx");
                document.ReportGeneration(info);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                throw;
            }
            
        }
    }
}
