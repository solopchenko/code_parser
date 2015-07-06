/*
 Это файл для тестирования приложения
 */



using System;
using System.Collections.Generic;
using System.Linq;
//Однострочный комментарий
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Многострочный
 * комментарий
 * 1
 * 2
 * 3
 */

namespace Code_parser
{
    class Test
    {
        //Комментраий в //коментарии

        public void function()
        {
            string s = "Обычная строка!";

            string s1 = "Я строка с \"кавычками\"";

            try
            {
                List<int> k = new List<int>();

                foreach (var item in k)
                {
                    while (true)
                    {
                        char ch = 'z';

                        switch (ch)
                        {
                            case 'm':
                                {
                                    break;
                                }
                            case 'l':
                                {
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                    }
                }
            }

            catch
            {
                MessageBox.Show("Сообщение");
            }

            int num = 0;
            switch (num)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            if (num == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        string str = "Строка throw throw throw";
                    }

                    catch
                    {
                        return;
                    }
                }
            }
            else if (num == 10)
            {

            }
            else
            {

            }
        }
    }
}

/*
 * Привет
 * мир!
 */

//Комментарий внизу;

/* Привет */

//Комментарий внизу