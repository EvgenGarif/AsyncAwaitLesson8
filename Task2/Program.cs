using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {

            //        Задание 2
            //Создайте приложение по шаблону Console Application.Создайте следующий класс:
            // internal class Product
            //        {
            //            public string Name { get; set; }
            //            public int Quantity { get; set; }
            //        }
            //        Создайте класс Shop.Внутри него создайте:
            //• Коллекцию для хранения элементов типа Product.
            //• Метод с названием MakeAnOrder, в теле которого должен создаваться новый экземпляр
            //класса Product и добавлять в коллекцию.
            //• Метод с названием ProcessOrders, в теле которого вы должны изымать из коллекции
            //продукты и выводить на экран консоли название продукта и сколько единиц было
            //куплено.
            //В классе Program используя задачи создайте несколько покупателей, которые будут делать
            //несколько заказов, а также создайте одного сотрудника, который будет обрабатывать заказы.


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
            public  Queue<Product> Products = new Queue<Product>();
            public void MakeAnOrder(string name, int quantity)
            {
                var product = new Product(name, quantity);
                Products.Enqueue(product);
                Console.WriteLine($" {Products.Count}");
            }
            public void ProcessOrders()
            {

                var proccesProduct =Products.Dequeue();              
              Console.WriteLine($"Название продукта - {proccesProduct.Name}. Количество - {proccesProduct.Quantity}.");
            }
        }
      
        static void Main(string[] args)
        {
            var shop = new Shop();
            Action customer1 = new Action(() => 
            { 
                shop.MakeAnOrder("Breаd", 2);
                shop.MakeAnOrder("Ham", 1);
            });
            customer1.Invoke();

            var shop1 = new Shop();
            Action customer2 = new Action(() => shop1.MakeAnOrder("Drink", 2));
            customer2.Invoke();

            var employee = new Action(() => 
            { 
                shop.ProcessOrders(); 
                shop1.ProcessOrders(); 
            });
            employee.Invoke();

        }
    }
}
