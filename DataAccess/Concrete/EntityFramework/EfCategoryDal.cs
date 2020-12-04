using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var categoryToAdded = context.Entry(entity);
                categoryToAdded.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public bool CheckIfCategoryStartsWithC(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var category = context.Categories.SingleOrDefault(c=>c.CategoryId==categoryId);
                return category.CategoryName.ToLower().StartsWith("c");
            }
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
