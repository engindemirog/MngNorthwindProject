using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            EfProductDal productDal = new EfProductDal();

            ProductManager productManager = new ProductManager(productDal);

            //List<Product> products = productDal.GetAll();

            productManager.Add(new Product {CategoryId=2, ProductName="Acer Laptop", QuantityPerUnit="64 Gb Ram" , UnitPrice=10000, UnitsInStock=2 });
            

            foreach (var product in productManager.GetAllAsync().Result)
            {
                Console.WriteLine(product.ProductName);
            }

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            EfEmployeeDal employeeDal = new EfEmployeeDal();

            foreach (var employee in employeeDal.GetAll())
            {
                Console.WriteLine(employee.FirstName);
            }

        }
    }
}
