using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace проджект2
{
    /// <summary>
    /// Класс предназначеный для представления/вывода информациии из файлова.  
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Метод который выводит обычный массив в столбец.
        /// </summary>
        public static void print(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        /// <summary>
        /// Перегрузка метода, выводит двумерный массив, подмассив выводится в строку, каждый элемент разделен одним пробелом, каждый новый массив - с новой строки.
        /// </summary>
        /// <param name="array"></param>
        public static void print(string[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод проверпяющий файл на структуру, аргементом принимает массив состоящий из строк файла
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckingTheStructure(string[] str)
        {
            string firstStr = str[0];
            firstStr = firstStr[1..].Trim();
            string header = "Working_Year,Designation,Experience,Employment_Status,Salary_In_Rupees,Employee_Location,Company_Location,Company_Size,Remote_Working_Ratio";
            if (firstStr == header)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// Метод который специализированный специально для парсинга  значения зарплаты из файла, в тип int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ConverterСurrency(string value)
        {
            int indexPoint = value.IndexOf(".") + 1;

            string floatChapter = "0," + value[indexPoint..];
            double dbChapter = double.Parse(floatChapter);
            indexPoint--;
            string number = value[..indexPoint].Replace(",", "").Replace(".", "");
            int output = int.Parse(number) + (dbChapter == 0 ? 0 : 1);
            return output;
        }
        /// <summary>
        /// Метод который специализированный специально для парсинга  значения зарплаты из файла, в тип вщгиду
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ConverterСurrencyDouble(string value)
        {
            int indexPoint = value.IndexOf(".") + 1;

            string floatChapter = "0," + value[indexPoint..];
            double dbChapter = double.Parse(floatChapter);
            indexPoint--;
            string number = value[..indexPoint].Replace(",", "").Replace(".", "");
            double output = double.Parse(number) + dbChapter;
            return output;
        }
    }
}
