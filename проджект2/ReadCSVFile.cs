using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace проджект2
{
    /// <summary>
    /// Нестатический класс для чтнения файлов типа CSV.
    /// </summary>
    public class ReadCSVFile
    {
        private protected string? defaultFilePath = null;
        private static char pathSep = Path.DirectorySeparatorChar;
        private protected string directoryProject = $@"..{pathSep}..{pathSep}..{pathSep}WorkingFiles{pathSep}";
        /// <summary>
        /// Свойство которое производит установку путь файла из которого происходит закрузка файла
        /// </summary>
        public string? filePath
        {
           
        get => defaultFilePath;
            set
            {


                string? fullFilePath =   directoryProject+ value;
                try
                {

                    string[] file = File.ReadAllLines(fullFilePath);
                    if (file.Length == 0)
                    {
                        Console.WriteLine("Файл пустой");
                    }
                    else if (!Employee.CheckingTheStructure(file))
                    {
                        Console.WriteLine("Файл не соответсвует структуре");
                    }
                    else
                    {
                        
                        defaultFilePath = fullFilePath;
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Папка с файлом на диске отсутствует.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Возникла какая то ошибка:{e}");
                }

            }
        }
        /// <summary>
        /// Дэфолтный конструкторов 
        /// </summary>
        public  ReadCSVFile() 
        {

        }
        /// <summary>
        /// Контруктор обёектов класса, параметром которой передаетс имя файла
        /// </summary>
        /// <param name="path"></param>
        public ReadCSVFile(string? path)
        {
            filePath = path;

        }
        /// <summary>
        /// Метод который выводит обычный массив в строку
        /// </summary>
        public  void Print()
        {
            string[] array = File.ReadAllLines(filePath);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        /// <summary>
        /// Метод  который принимает параметром строку - имя файла, проверяет строку на коректность имени и существует ли такой файл 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>bool</returns>
        public bool isCorrectPath(string? path)
        {
            string path1 = directoryProject + path;

            if (!(path is null) && path.Length != 0)
            {
                try
                {
                    string[] file69 = File.ReadAllLines(path1);
                    if (file69.Length != 0)
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("файл в папке WorkinfFiles на диске отсутствует.");
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Возникла какая то ошибка:{e}");
                    return false;
                }

            }
            else 
            { 
                return false ;
            }
            
            
        }

        public string[][] MakeArrayOfArray(char sep)
        {
            string[][] arrayOfArray = new string[File.ReadAllLines(defaultFilePath).Length][];
            string[] array = File.ReadAllLines(defaultFilePath);
            for (int i = 0; i < File.ReadAllLines(defaultFilePath).Length; i++)
            {
                arrayOfArray[i] =  array[i].Split(sep);
            }
            return arrayOfArray;

        }
        /// <summary>
        /// Метод который возращает массив из строк файла
        /// </summary>
        /// <returns>строковый массив</returns>
        public string[] GetArray()
        {
            return File.ReadAllLines(defaultFilePath);
        }
        
    }
}
