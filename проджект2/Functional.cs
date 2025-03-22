using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace проджект2
{
    /// <summary>
    /// Статический класс-обертка, предназначенный для хранения методов личного использования. 
    /// </summary>
    public static class Functional
    {
        /// <summary>
        /// Метод который возращает массив со строками консольного меню
        /// </summary>
        /// <returns></returns>
        public static string[] Menu()
        {
            string tab = "    ";
            string[] menu = {
                "Введите номер нужного пункта меню\r\n",
                "1.Загрузить данные из файла(введите путь к файлу)\r\n",
                "2.Отфильтровать входные данные с клавиатуры по признка:Experience(после выполнения пункта будет предложено сохранить выборку в файл)\r\n",
                "Вывести на экран сводную статистику по данным из файла:\r\n",
                 $"3.Вывести общее количество строк с данными без учёта строки с заголовками\r\n",
                 $"4.Вывести работников с наибольшей и наименьшей зарплатой\r\n",
                 $"5.Количество Data Engineer работающих из Великобритании\r\n",
                 $"6.Количество работников, работающих в компаниях из Великобритании, но работающих из иной страны\r\n",
                "7.Вывести на экран выборку работников, зарплата которых находится в диапазоне от 70 до 80% от максимально возможной по выборке.(после выполнения пункта будет предложено сохранить выборку в файл)\r\n",
                "8.Завершить работу\r\n"

            };
            return menu;
        }
        /// <summary>
        /// Метод осуществляющий запись переменной не Null строкой и не нулевой строкой.
        /// </summary>
        /// <returns></returns>
        public static string WhileNotCorrectData()
        {
            string newPathFile = Console.ReadLine();
            while (newPathFile == null || newPathFile.Length==0)
            {
                newPathFile = Console.ReadLine();
            }
            return newPathFile;
        }
        /// <summary>
        /// Метод позволяющий сделать сроку из пробелов длинной n - передаваемый параметр.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Concatenation(int n)
        {
            string str = "";
            for (int i = 0; i < n; i++)
            {
                str += " ";
            }
            return str;
        }
        
    }


}
