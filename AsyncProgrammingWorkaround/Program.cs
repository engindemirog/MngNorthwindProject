using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgrammingWorkaround
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main metoduna başladım {Thread.CurrentThread.ManagedThreadId}");

            //Task task1 = new Task(Process1);
            //task1.Start();

            Task task1 = Task.Run(Process1);


            Task task2 = new Task(Process2);
            task2.Start();

            Task task3 = Task.Run(() =>
            {
                Console.WriteLine("Ben de asenkron çalışabilirim");
            });

            Task<int> task4 = Task.Run(Calculate);

            int sonuc = CalculateAsync(10).Result;

            Console.WriteLine(task4.Result);

            Task<List<Product>> task5 = Task.Run(GetAll);

            foreach (var item in task5.Result)
            {
                Console.WriteLine(item.ProductName);
            }

            foreach (var item in GetAllAsync().Result)
            {
                Console.WriteLine(item.ProductName);
            }




            Console.ReadKey();
        }

        static void Process1()
        {
            Console.WriteLine($"Process 1 metoduna başladım {Thread.CurrentThread.ManagedThreadId}");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine($"Process 1 metodunu bitirdim {Thread.CurrentThread.ManagedThreadId}");
        }

        static void Process2()
        {
            Console.WriteLine($"Process 2 metoduna başladım {Thread.CurrentThread.ManagedThreadId}");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine($"Process 2 metodunu bitirdim {Thread.CurrentThread.ManagedThreadId}");

        }

        static int Calculate()
        {
            return 10;
        }

        static async Task<int> CalculateAsync(int faiz)
        {
            return await Task.Run(() =>
            {
                return 10 * faiz;

            });

        }

        //C# actions
        static List<Product> GetAll()
        {
            return new List<Product>
            {
                new Product{ProductId=1, ProductName="Laptop 1"},
                new Product{ProductId=2, ProductName="Laptop 2"}
            };
        }



        static async Task<List<Product>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return new List<Product>
                {
                    new Product{ProductId=1, ProductName="Laptop 1"},
                    new Product{ProductId=2, ProductName="Laptop 2"}
                };
            });
        }
    }

    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
