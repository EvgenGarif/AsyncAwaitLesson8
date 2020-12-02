using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[10_000_000];

            Parallel.For(0, array.Length, (i) =>
            {
                array[i] = i;
            });

            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();

            Parallel.ForEach(array, (item) =>
            {
                if (array[item] != 0 && (array[item] & (array[item] - 1)) == 0)
                    concurrentQueue.Enqueue(item);
            });

            foreach (var item in concurrentQueue)
                Console.Write($"{item} ");

            Console.ReadLine();
        }
    }
}

//Задание
//Создайте приложение по шаблону Console Application. Создайте массив целочисленных
//элементов, размерностью в 10 000 000. Проинициализируйте массив с помощью параллельного 
//цикла For от 0 до максимального размера. Создайте потокобезопасную коллекцию на свое 
//усмотрение. Используя параллельный цикл ForEach переберите элементы массива и добавляйте 
//в потокобезопасную коллекцию только те элементы, которые являются степенью двойки. 
//Выведите на экран консоли элементы из вашей потокобезопасной коллекции.
