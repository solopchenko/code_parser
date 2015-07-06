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
        public bool ReadFile(string fileName)
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
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        //Удаление коментариев и строк
        public void RemoveCommentsAndStrings()
        {

            for (int i = 0; i < raw_code.Length - 1; i++)
            {
                //Удаление комментариев типа //
                if ((raw_code[i] == '/') && (raw_code[i + 1] == '/'))
                {
                    while ((raw_code[i] != '\n') & (i < raw_code.Length - 1))
                    {
                        i++;
                    }
                }

                //Удаление коментариев /* */
                if ((raw_code[i] == '/') && (raw_code[i + 1] == '*'))
                {
                    int a = raw_code.IndexOf("*/", i + 2);

                    i = a + 2;
                }

                //Удаление строк "" (проблема с кавычками в кавычках)
                if (raw_code[i] == '\"')
                {
                    i++;

                    while ((raw_code[i] != '\"'))
                    {
                        i++;
                    }

                    i++;
                }

                //Удаление символов
                if (raw_code[i] == '\'')
                {
                    i++;
                    while (raw_code[i] != '\'')
                    {
                        i++;
                    }
                    i++;
                }

                code = code + raw_code[i];
            }

            //Удаление переходов на новую строку
            //code = code.Replace("\n", String.Empty);

            //Удаление возвратов каретки
            code = code.Replace("\r", String.Empty);

            //Удаление Tab-ов
            code = code.Replace("\t", String.Empty);
        }

        //Подсчет операторов
        public void CountOperators()
        {
            RemoveCommentsAndStrings();

            char[] spit_array = { ' ', '\n', '\r' };

            string[] split_code = code.Split(spit_array);

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

        //Сброс количества операторов
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

        //Выбор места сохранения файлов
        public string SaveDialog()
        {
            var fd = new SaveFileDialog();
            fd.Title = "Выберите место для сохранения отчета";
            fd.Filter = "CSV file *.csv | *.CSV";
            fd.FileName = "Report " + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");

            fd.ShowDialog();

            return fd.FileName;
        }

        //Формирование отчета
        public void CreateReportFile(string FileName)
        {
            if (!String.IsNullOrEmpty(FileName))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(FileName, false))
                    {
                        sw.WriteLine("Оператор;Количество");
                        foreach (var elem in operators_list)
                        {
                            sw.WriteLine(elem + ";" + operators[elem]);
                        }
                    }
                }

                catch
                {
                    MessageBox.Show("Не удалось сохранить файл.\nВозможно доступ к папке запрещен.", "Ошибка сохранения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        //Экспорт отчета
        public void ExportReport()
        {
            string FileName = SaveDialog();

            CreateReportFile(FileName);
        }

        public void ShowProgress(ProgressBar pg, int max, int value)
        {
            pg.Maximum = max;
            pg.Value = value;
            pg.Step = 1;
        }
    }
}