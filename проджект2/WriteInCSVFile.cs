using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace проджект2
{
    /// <summary>
    /// Класс для записии в файл csv, с определенной структурой
    /// </summary>
    public class WriteInCSVFile
    {
        private string header = "Working_Year,Designation,Experience,Employment_Status,Salary_In_Rupees,Employee_Location,Company_Location,Company_Size,Remote_Working_Ratio";

        private static char pathSep = Path.DirectorySeparatorChar;// возращает элемент который раздляет названия папок на компьютере
        private protected string directoryProject = $@"..{pathSep}..{pathSep}..{pathSep}WorkingFiles{pathSep}";
        private protected string? defaultFilePath = null;
        /// <summary>
        /// Конструктор который создает файл, в который записывается выборки.
        /// Название файла - аргумент который передается в конструктор
        /// </summary>
        /// <param name="fileName"></param>
        public WriteInCSVFile(string fileName)
        {
            defaultFilePath = directoryProject + fileName;
        }
       
      /// <summary>
      /// Метод который записывает массив,который передается кака аргумент метода, в файл и заголовок
      /// </summary>
      /// <param name="arrayLines"></param>
        public void Write(string[] arrayLines)
        {
            string[] arrayLinesWithHeaders = new string[arrayLines.Length + 1];
            arrayLinesWithHeaders[0] =","+header;
            arrayLines.CopyTo(arrayLinesWithHeaders, 1);
            try
            {
                File.WriteAllLines(defaultFilePath, arrayLinesWithHeaders);
            }
            catch (IOException)
            {
                Console.WriteLine("Проблемы с открытием файла.");
            }
        }

    }
}
