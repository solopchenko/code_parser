using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Code_parser
{
    public class AppFunctions
    {
        public List<string> operators_list; 

        public Dictionary<string, int> operators {get; private set;}
        
        //Исходный код файла без изменений
        public string raw_code { get; private set; }

        //Исходный код, использованный в алгоритмах
        public string code { get; private set; }

        public AppFunctions()
        {
            operators_list = new List<string>();
            operators_list.Add("if");
            operators_list.Add(";");
            operators_list.Add("foreach");
            operators_list.Add("for");
            operators_list.Add("while");
            operators_list.Add("switch");
            operators_list.Add("try");
            operators_list.Add("throw");

            operators = new Dictionary<string, int>();
            foreach (var op in operators_list)
            {
                operators.Add(op, 0);
            }

            raw_code = String.Empty;

            code = String.Empty;
        }

        //Выбор файла
        public string OpenDialog()
        {
            var fd = new OpenFileDialog();
            fd.Title = "Выберите файл";
            fd.Filter = "C# code *.cs | *.CS";

            fd.ShowDialog();

            return fd.FileName;
        }

        //Чтение файла
        public void ReadFile(string fileName)
        {
            string str = string.Empty;

            if (fileName != string.Empty)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        raw_code = sr.ReadToEnd();
                    }
                }

                catch
                {
                    MessageBox.Show("Не удалось открыть файл.\nВозможно доступ к файлу запрещен. Либо файл был перемещен или удален.", "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public void RemoveComments()
        {

            for (int i = 0; i < raw_code.Length - 1; i++)
            {
                //Удаление комментариев типа //
                if ((raw_code[i] == '/') && (raw_code[i + 1] == '/'))
                {
                    while ((raw_code[i] != '\n') & (i < raw_code.Length - 1))
                    {
                        raw_code.Replace(raw_code[i].ToString(), String.Empty);
                        i++;
                    }
                }

                //Удаление коментариев /* */
                if ((raw_code[i] == '/') && (raw_code[i + 1] == '*'))
                {
                    int a = raw_code.IndexOf("*/", i + 2);

                    i = a + 1;
                }

                //Удаление строк ""
                if ((raw_code[i] == '\"'))
                {
                    i++;
                    while (raw_code[i] != '\"')
                    {
                        i++;
                    }
                }

                code = code + raw_code[i];
            }

            //Удаление переходов на новую строку
            code = code.Replace("\n", String.Empty);

            //Удаление вощвратов каретки
            code = code.Replace("\r", String.Empty);

            //Удаление Tab-ов
            code = code.Replace("\t", String.Empty);

            //Удаление тройных пробелов
            code = code.Replace("   ", String.Empty);
        }

        //Разбиение кода на части
        public string[] SplitCode()
        {
            RemoveComments();

            char[] spit_array = { ' ', '\n', '\r' };

            string[] s_code = code.Split(spit_array);

            return s_code;
        }

        //Подсчет операторов
        public void CountOperators(string[] split_code)
        {

            foreach (var op in operators_list)
            {
                foreach (var s in split_code)
                {
                    if (s.Contains(op))
                    {
                        operators[op] = operators[op] + 1;
                    }
                }

            }
        }

        public void Reset()
        {
            operators = new Dictionary<string, int>();
            foreach (var op in operators_list)
            {
                operators.Add(op, 0);
            }
            
            raw_code = String.Empty;

            code = String.Empty;
        }


        public void AnalyzeCode()
        {
            Reset();

            string fileName = OpenDialog();

            if (fileName == String.Empty)
            {
                MessageBox.Show("Файл не выбран.");
            }

            ReadFile(fileName);

            string[] s_code = SplitCode();

            CountOperators(s_code);
        }

    }
}











//        public void FormatCode()
//        {
//            //string s = String.Empty;


//            for (int i = 0; i < raw_code.Length - 1; i++)
//            {
//                //Удаление комментариев типа //
//                if ((raw_code[i] == '/') && (raw_code[i + 1] == '/'))
//                {
//                    while ((raw_code[i] != '\n') & (i < raw_code.Length - 1))
//                    {
//                        raw_code.Replace(raw_code[i].ToString(), String.Empty);
//                        i++;
//                    }
//                }


//                ////Удаление строк "" работает так себе
//                //if ((code[i] == '\"'))
//                //{
//                //    int a = code.IndexOf("\"", i + 1);

//                //    int b = code.IndexOf("\\\"", i + 1);

//                //    if ((a >= 0) & (b >= 0))
//                //    {
//                //        if (a < b)
//                //            i = a;
//                //        else
//                //            i = b + 1;
//                //    }
//                //}
                

//                //Удаление коментариев /* */
//                if ((raw_code[i] == '/') && (raw_code[i + 1] == '*'))
//                {
//                    int a = raw_code.IndexOf("*/", i + 2);

//                    i = a + 2;
//                }

//                code = code + raw_code[i];
//            }
            
//            code = code.Replace("\n", String.Empty);
//            code = code.Replace("\r", String.Empty);
//            code = code.Replace("\r\n", String.Empty);
//            code = code.Replace("\t", String.Empty);
//        }



//    }
//}
