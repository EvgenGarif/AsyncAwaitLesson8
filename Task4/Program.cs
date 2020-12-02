using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fstream = File.OpenRead(@"your path\data.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                var textFromFile = System.Text.Encoding.Default.GetString(array).ToArray();
                Parallel.ForEach(textFromFile, (item) =>
                {
                    Console.Write($"{item}");
                });
            }
        }
    }
}

            //Задание 4
            //Создайте приложение по шаблону Console Application. Используя параллельный цикл ForEach
            //прочитайте содержимое файла. Файл находится в папке с материалами. Название файла 
            //«data.txt».
