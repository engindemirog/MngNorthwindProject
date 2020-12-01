using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Veri tabanı tablosuna eşleştirme
                var updatedEntity = context.Entry(entity);

                //Hangi işlem uygulanacak? Güncelleme,silme,ekleme
                updatedEntity.State = EntityState.Added;

                //Execute- Çalıştır
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            //disposing -- bellekten hızlıca silmek
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.ToList();
            }         
            //Select * from Products
        }

        public Product GetById(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.SingleOrDefault(p=>p.ProductId==id);
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
