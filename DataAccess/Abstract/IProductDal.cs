using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>,IAsyncEntityRepository<Product>
    {
        //CRUD
        Product GetProductOfMonth();
        List<Product> GetProductsByCategory(int categoryId);
    }
}
