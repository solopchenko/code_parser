using System;
using System.Collections.Generic;
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
        public string OpenDialog(string filter)
        {
            var fd = new OpenFileDialog();
            fd.Title = "Выберите файл";
            fd.Filter = filter;

            fd.ShowDialog();

            return fd.FileName;
        }

        public void Reset()
        {
            operators.ResetOperatorsCount();
            code.ResetCode();
        }
    }
}
