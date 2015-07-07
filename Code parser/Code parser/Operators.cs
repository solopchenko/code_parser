using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_parser
{
    public class Operators
    {
        public List<string> operators_list {get; private set; }

        public Dictionary<string, int> operators_dic { get; private set; }

        private string config_path;

        public Operators()
        {
            operators_list = new List<string>();
            operators_dic = new Dictionary<string, int>();
            config_path = "config//operators.conf";

            //По умолчанию нужно читать из файла, если это невозможно, то устанавливать стандартные настройки
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(config_path))
                {
                    string line;

                    //Очистка старого списка
                    operators_list.Clear();
                    operators_dic.Clear();

                    List<string> file_operators = new List<string>();

                    //Добавление операторов из файла в список
                    while ((line = reader.ReadLine()) != null)
                    {
                        file_operators.Add(line);
                    }

                    reader.Close();

                    //Добавление операторов из списка в структуру
                    SetOperators(file_operators);
                }
            }

            catch
            {

                SetDefaultOperators();

                MessageBox.Show("Не удалось загрузить файл настроек.\nВозможно доступ к файлу запрещен. Либо файл отсутсвует.\nПрименен стандарнтный набор операторов. ", "Не удалось загрузить настройки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Установка операторов из списка
        public void SetOperators(List<string> op_list)
        {
            operators_list.Clear();
            operators_dic.Clear();

            foreach (var item in op_list)
            {
                operators_list.Add(item);
                operators_dic.Add(item, 0);
            }

            //ЕСЛИ ОДИНАКОВЫЕ ЗНАЧЕНИЯ ВВЕСТИ В ДЭЙТАГРИД, ТО ВОЗНИКАЕТ ИСКЛЮЧЕНИЕ ОЮ УЖЕ СУЩЕСТВУЮЩЕМ ЭЛЕМЕНТЕ

            //Запись в файл
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(config_path, false))
                {
                    foreach (var item in operators_list)
                    {
                        writer.WriteLine(item);
                    }
                    writer.Close();
                }
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл настроек.\nВозможно доступ к файлу запрещен. Либо файл используется другим приложением.", "Не удалось сохранить настройки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Установка стандартных операторов
        public void SetDefaultOperators()
        {
            //Стандартный набор операторов
            List<string> default_operators = new List<string>();
            default_operators.Add("if");
            default_operators.Add("for");
            default_operators.Add("foreach");
            default_operators.Add("while");
            default_operators.Add("switch");
            default_operators.Add("try");
            default_operators.Add("finally");
            default_operators.Add("=");

            SetOperators(default_operators);
        }

        //Сброс счетчиков операторов
        public void ResetOperatorsCount()
        {
            foreach (var item in operators_list)
            {
                operators_dic[item] = 0;
            }
        }

        //Создание отчета
        public void CreateReport(string fileName)
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(fileName, false))
                    {
                        writer.WriteLine("Оператор;Количество");
                        foreach (var item in operators_list)
                        {
                            writer.WriteLine(item + ";" + operators_dic[item]);
                        }
                        writer.Close();
                    }
                }

                catch
                {
                    MessageBox.Show("Не удалось сохранить файл.\nВозможно доступ к папке запрещен.", "Ошибка сохранения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
