using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_parser
{
    public class Main
    {
        public Code code;
        public Operators operators;

        public Main()
        {
            code = new Code();
            operators = new Operators();
        }

        //Выбор файла
        public string OpenDialog(string title, string filter)
        {
            var fd = new OpenFileDialog();
            fd.Title = title;
            fd.Filter = filter;

            fd.ShowDialog();

            return fd.FileName;
        }

        public void Reset()
        {
            operators.ResetOperatorsCount();
            code.ResetCode();
        }

        public string SaveDialog(string title, string filter, string fileName)
        {
            var fd = new SaveFileDialog();
            fd.Title = title; 
            fd.Filter = filter;
            fd.FileName = fileName + " " + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");


            fd.ShowDialog();

            return fd.FileName;
        }
    }
}