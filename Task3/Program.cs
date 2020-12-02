using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {

                //        Задание 3
                //Выполните задание под номером 2. Переделайте пример, используя шаблон Producer-Consumer.
                //Вам необходимо использовать потокобезопасную оболочку BlockingCollection.Метод
                //            ProcessOrders должен работать пока работа с оболочкой не завершена.Когда покупатели
                //завершат покупку своих товаров, они должны об этом указать.

        internal class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public Product(string name, int quantity)
            {
                Name = name;
                Quantity = quantity;
            }
        }
        internal class Shop
        {
            public BlockingCollection<Product> products = new BlockingCollection<Product>(new ConcurrentQueue<Product>());
            public void MakeAnOrder(string name, int quantity)
            {
                var product = new Product(name, quantity);
                products.Add(product);
                Console.WriteLine($" {products.Count}");
            }
            public void ProcessOrders()
            {

                var proccesProduct = products.Take();
                Console.WriteLine($"Название продукта - {proccesProduct.Name}. Количество - {proccesProduct.Quantity}.");
            }
        }

        static async Task Main(string[] args)
        {
            var shop = new Shop();
            Action customer1 = new Action(() =>
            {
                shop.MakeAnOrder("Breаd", 2);
                shop.MakeAnOrder("Ham", 1);
            });
            var producer1 = Task.Run(() => customer1.Invoke());

            var shop1 = new Shop();
            Action customer2 = new Action(() => shop1.MakeAnOrder("Drink", 2));
            var producer2 = Task.Run(() => customer2.Invoke());

            var employee = new Action(() => 
            { 
                shop.ProcessOrders();
                shop1.ProcessOrders(); 
            });

            var consumer = Task.Run(() => employee.Invoke());

            await Task.WhenAll(producer1, producer2);

            shop.products.CompleteAdding();
            shop1.products.CompleteAdding();

            await consumer;

        }
    }
}
