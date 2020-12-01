using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                throw new Exception("Ürün ismi en az iki kararkter olmalıdır.");
            }

            if (product.CategoryId==1)
            {
                throw new Exception("Şu an içecek kategorisinde ürün kabul edilmiyor.");
            }

            _productDal.Add(product);

            
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }
    }
}
