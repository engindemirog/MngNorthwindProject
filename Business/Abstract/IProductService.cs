using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        void Add(Product product);

        Task<List<Product>> GetAllAsync();
        Product GetById(int id);
        List<Product> GetByCategory(int id);
    }
}
