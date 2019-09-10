using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file:");
            string pathToFile = "drive2.txt" /*Console.ReadLine()*/;
            List<string> drive1 = File.ReadAllLines(pathToFile).ToList();
            ConsoleColor defaultForegroundColor = Console.ForegroundColor;
            Console.WriteLine();
            Console.WriteLine("=====================");

            foreach (var line in drive1)
            {
                string folderPath1 = line.Substring(0, line.IndexOf(';'));
                string folderPath2 = line.Substring(line.IndexOf(';')).Trim(';', ' ', '\t');

                if (GetDirectorySize(folderPath1) == -1)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Путь {folderPath1} либо не найден, либо что-то пошло не так.");
                    Console.WriteLine();
                    Console.ForegroundColor = defaultForegroundColor;
                    Console.WriteLine("=====================");
                    
                    continue;
                }
                long directorySize1 = GetDirectorySize(folderPath1);
                long directoryXize2 = GetDirectorySize(folderPath2);

                if (directorySize1 == directoryXize2)
                {
                    Console.WriteLine(folderPath1);
                    Console.WriteLine(directorySize1);
                    Console.WriteLine(folderPath2);
                    Console.WriteLine(directoryXize2);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Folders are equal");
                    Console.ForegroundColor = defaultForegroundColor;
                }
                else
                {
                    Console.WriteLine(folderPath1);
                    Console.WriteLine(directorySize1);
                    Console.WriteLine(folderPath2);
                    Console.WriteLine(directoryXize2);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Folders are not equal");
                    Console.ForegroundColor = defaultForegroundColor;
                }
                Console.WriteLine();
                Console.WriteLine("=====================");
            }

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        private static long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);

            try
            {
                return di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
            }
            catch (Exception e)
            {
                #if DEBUG
                Console.WriteLine(e);
                #endif

                return -1;
            }

        }
    }
}
