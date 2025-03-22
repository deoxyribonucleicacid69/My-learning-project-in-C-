using System;
using System.Globalization;
using System.IO;
using System.Xml;
using проджект2;
//Карнаухов Глеб БПИ-246(1) Вариант:11
class Program
{
    static void Main()
    {
        ReadCSVFile readCSVFile = new ReadCSVFile();
        Console.Write("Введите имя файла с расширением:");
        string? startPath = Console.ReadLine();
        while (!readCSVFile.isCorrectPath(startPath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Какая то ошибка, введите еще раз имя файла");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Имя файла:");
            startPath = Console.ReadLine();
            Console.WriteLine();
        }
        readCSVFile.filePath = startPath;
        
        Console.Clear();
        while (true) {
            Employee.print(Functional.Menu());
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.Write("Введите новое  имя файла с расширением:");
                string? path = Console.ReadLine();
                while (!readCSVFile.isCorrectPath(path))
                {
                    Console.Write("Введите имя файла:");
                    path = Console.ReadLine();
                    Console.WriteLine();
                }
                readCSVFile.filePath = path;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Нажмите любую кнопку для возрата в меню...");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                Console.Clear();

            }
            else if (input == "2")
            {
                string[][] output = readCSVFile.MakeArrayOfArray(',');
                

                Console.Write("Введите значение параметра ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Experience:");
                Console.ForegroundColor = ConsoleColor.White;
                string[] arrayWrite = new string[0];

                string? parameter = Functional.WhileNotCorrectData().Trim();
                int count = 0;
                for (int i = 1; i < output.Length; i++)
                {
                    try
                    {
                        if (output[i][3] == parameter)
                        {
                            Employee.print(output[i][1..]);
                            Console.WriteLine();
                            Array.Resize(ref arrayWrite, arrayWrite.Length + 1);
                            arrayWrite[^1] = arrayWrite.Length + "," + String.Join(',', output[i][1..]);
                            count++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
                if (count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введены некоректные данные, попробуйте снова\r\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Для возрата в меню нажмите любую клавишу...");
                    ConsoleKeyInfo key;
                    key = Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    
                    Console.WriteLine("Хотите закгрузить выборку в файл?");
                    Console.WriteLine("Введите 1");
                    string option = Console.ReadLine();
                    if (option == "1" && arrayWrite.Length!=0)
                    {
                        WriteInCSVFile wr = new WriteInCSVFile("employees.csv");
                        wr.Write(arrayWrite);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Программа отработала, нажмите какую-то кнопку для выхода в меню...");
                        Console.ForegroundColor = ConsoleColor.White;
                        ConsoleKeyInfo key1;
                        key1 = Console.ReadKey();
                        Console.Clear();

                    }
                    else if (option == "1" && arrayWrite.Length == 0) { Console.WriteLine("К сожалению данных нету, файл не будет создан"); }
                    else 
                    {
                        Console.Clear();
                    }
                    
                }
            }
            
            else if (input == "3")
            {
                Console.Write("Общее количество строк:");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(File.ReadAllLines(readCSVFile.filePath).Length - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Программа отработала, нажмите какую-то кнопку для выхода в меню...");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                Console.Clear();
            }
            else if (input == "4")
            {
                string[][] output1 = readCSVFile.MakeArrayOfArray('\"');
                string[][] output2 = readCSVFile.MakeArrayOfArray(',');
                string[] developers = new string[0];
                int min = int.MaxValue;
                int max = int.MinValue;
                string[] developersFile = readCSVFile.GetArray();
                for (int i = 1; i < output1.Length; i++)
                {
                    try
                    {
                        min = int.Min(min, Employee.ConverterСurrency(output1[i][1]));
                        max = int.Max(max, Employee.ConverterСurrency(output1[i][1]));
                    }
                    catch { continue; }
                }
                Console.WriteLine("Работники с самой большой зарплатой:");
                for (int i = 1; i < output2.Length; i++)
                {
                    try
                    {
                        if (Employee.ConverterСurrency(output1[i][1]) == max)
                        {
                            Employee.print(output2[i][1..]);
                        }
                    }
                    catch { Console.WriteLine("произошла ошибка, возможно в файле отсутствует нужная информация... "); }

                }
                Console.WriteLine();
                Console.WriteLine("Работники с самой маленькой зарплатой:");

                for (int i = 1; i < output2.Length; i++)
                {
                    try
                    {
                        if (Employee.ConverterСurrency(output1[i][1]) == min)
                        {
                            Employee.print(output2[i][1..]);
                        }
                    }
                    catch { Console.WriteLine("произошла ошибка, возможно в файле отсутствует нужная информация... "); }
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Программа отработала, нажмите какую-то кнопку для выхода в меню...");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                Console.Clear();
            }
            else if (input == "5")
            {
                int count = 0;
                string[][] output = readCSVFile.MakeArrayOfArray(',');
                for (int i = 0; i < output.Length; i++)
                {
                    try
                    {
                        if (output[i][8] == "GB" && output[i][2] == "Data Engineer")
                        {
                            count++;
                        }
                    }
                    catch { Console.WriteLine("произошла ошибка, возможно в файле отсутствует нужная информация... "); }
                }
                Console.Write("Количество Data Engineer работающих из Великобритании:");
                Console.WriteLine(count);
                Console.WriteLine("Нажмите любую кнопку для возрата в меню...");
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                Console.Clear();
            }
            else if (input == "6")
            {
                int count = 0;
                string[][] output = readCSVFile.MakeArrayOfArray(',');
                for (int i = 0; i < output.Length; i++)
                {
                    try
                    {
                        if (output[i][9] == "GB" && output[i][8] != "GB")
                        {
                            int len = 3 - output[i][0].Length;
                            Console.WriteLine("Номер работника:" + output[i][0] + Functional.Concatenation(len) + " " + "Место его работы:" + output[i][8]);// вывожу номер работника так как в условие не сказано как его вывести, либо всю строку либо только работу
                                                                                                                                                            // Но так как сказано выводить рядос с работником его метсо работы значит нужно выводить не строку так как в ней и так есть метсто работы
                            count++;
                        }
                    }
                    catch { Console.WriteLine("произошла ошибка, возможно в файле отсутствует нужная информация... "); }

                }
                Console.WriteLine("Итоговое количество:" + count);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Программа отработала, нажмите какую-то кнопку для выхода в меню...");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                Console.Clear();
            }
            else if (input == "7")
            {
                
                string[][] output = readCSVFile.MakeArrayOfArray('\"');
                string[] array = readCSVFile.GetArray();
                string[] fileWrite  = new string[0];
                try
                {
                    double max = int.MinValue;
                    for (int i = 1; i < output.Length; i++)
                    {
                        max = double.Max(max, Employee.ConverterСurrency(output[i][1]));
                    }
                    for (int i = 1; i < output.Length; i++)
                    {

                        double percent = Employee.ConverterСurrencyDouble(output[i][1]) / max * 100;
                        if (70 <= percent && percent <= 80)
                        {
                            int index = array[i].IndexOf(",") + 1;
                            Console.WriteLine(array[i][index..]);
                            Array.Resize(ref fileWrite, fileWrite.Length + 1);
                            fileWrite[^1] = fileWrite.Length + "," + array[i][index..];
                        }
                    }
                }
                catch { Console.WriteLine("произошла ошибка, возможно в файле отсутствует нужная информация... ");  }
                Console.WriteLine("Вы хотите сохранить выборку в файл?");
                Console.WriteLine("Тогда введите 1");
                string option = Console.ReadLine();
                if (option == "1" && fileWrite.Length != 0)
                {
                    WriteInCSVFile wr = new WriteInCSVFile("Salary7080-employees.csv");
                    wr.Write(fileWrite);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Программа отработала, нажмите какую-то кнопку для выхода в меню...");
                    Console.ForegroundColor = ConsoleColor.White;
                    ConsoleKeyInfo key1;
                    key1 = Console.ReadKey();
                    Console.Clear();

                }
                else if (option == "1" && fileWrite.Length == 0) { Console.WriteLine("К сожалению данных нету, файл не будет создан"); }
                else { Console.Clear(); }
                
            }
            else if (input == "8")
            {

                break;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введен некоректный номер...");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Программа отработала, нажмите какую-то кнопку для выхода в меню...");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                Console.Clear();

            }
        } 
    }
}