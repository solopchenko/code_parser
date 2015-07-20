using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_parser
{
    public class Code
    {
        //Исходный код файла без изменений
        public string raw_code { get; private set; }

        //Исходный код, использованный в алгоритмах
        public string code { get; private set; }

        //Путь к файлу с кодом
        public string code_file_name { get; private set; }

        public Code()
        {
            raw_code = String.Empty;
            code = String.Empty;
        }

        //Чтение файла
        public void SetCodeFromFile(string fileName)
        {
            ClearCode();

            if (fileName != string.Empty)
            {
                code_file_name = fileName;
                try
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        raw_code = reader.ReadToEnd();
                        reader.Close();
                    }
                }

                catch
                {
                    MessageBox.Show("Не удалось открыть файл.\nВозможно доступ к файлу запрещен. Либо файл был перемещен или удален.", "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    raw_code = String.Empty;
                    code = String.Empty;
                    code_file_name = String.Empty;

                    return;
                }
            }
        }

        public void ClearCode()
        {
            raw_code = String.Empty;
            code = String.Empty;
            code_file_name = String.Empty;
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

                    i = a + 1;
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

                //Удаление символов ''
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

            //Удаление возвратов каретки
            code = code.Replace("\r", String.Empty);

            //Удаление Tab-ов
            code = code.Replace("\t", String.Empty);
        }

        //Подсчет операторов
        public void CountOperatorsFromFile(Operators o)
        {
            RemoveCommentsAndStrings();

            char[] spit_array = { ' ', '\n', ';' };

            string[] split_code = code.Split(spit_array);

            

            foreach (var item in split_code)
            {
                if (o.operators_dic.Keys.Contains(item))
                {
                    o.operators_dic[item] = o.operators_dic[item] + 1;
                }
            }

            //Для расчета количества ;
            if (o.operators_dic.ContainsKey(";"))
            {
                o.operators_dic[";"] = 0;
                for (int i = 0; i < code.Length; i++)
                {
                    if (code[i] == ';')
                    {
                        o.operators_dic[";"] = o.operators_dic[";"] + 1;
                    }
                }
            }
        }

        public string ShowCode()
        {
            string str = String.Empty;

            if((!String.IsNullOrEmpty(code_file_name) && (!String.IsNullOrEmpty(raw_code))))
            {
                str =
                    "\n\n=========================================================================\n" +
                    code_file_name +
                    "\n=========================================================================\n\n" +
                    raw_code;
            }

            return str;
        }

    }
}
