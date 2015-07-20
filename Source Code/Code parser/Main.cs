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
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = title;
            fd.Filter = filter;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                return fd.FileName;
            }

            return String.Empty;
        }

        //Выбор папки
        public List<string> OpenFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                return Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".cs") || s.EndsWith(".c") || s.EndsWith(".cpp")).ToList();
            }
            else
            {
                return null;
            }
        }

        public void Reset()
        {
            operators.ResetOperatorsCount();
            code.ClearCode();
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