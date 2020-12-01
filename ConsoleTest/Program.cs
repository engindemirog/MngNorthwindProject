using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EfProductDal productDal = new EfProductDal();
            //List<Product> products = productDal.GetAll();

            foreach (var product in productDal.GetAll())
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
