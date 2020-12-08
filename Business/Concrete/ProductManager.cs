using Business.Abstract;
using Business.CustomExceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

       

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public void Add(Product product)
        {

            if (_categoryService.CheckIfCategoryStartsWithC(product.CategoryId))
            {
                throw new Exception();
            }
            if (_productDal.GetProductsByCategory(product.CategoryId).Count >= 10)
            {
                //throw exception
            }
            //Bir kategoride max 10 farklı ürün olabilir kuralı getiriyor.
            if (product.ProductName.Length<2)
            {
                throw new ProductNameException("Ürün ismi kurallara uygun değil.");
            }

            if (product.CategoryId==1)
            {
                throw new CategoryForbiddenException("Şu an içecek kategorisinde ürün kabul edilmiyor.");
            }

            _productDal.Add(product);

            
        }

        public List<Product> GetAll()
        {
            Console.WriteLine($"Normal Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            return _productDal.GetAll();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await Task.Run(()=> {
                Console.WriteLine($"Async Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                return _productDal.GetAllAsync();
            });
            
        }

        public List<Product> GetByCategory(int id)
        {
            return _productDal.GetProductsByCategory(id);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }
    }
}
