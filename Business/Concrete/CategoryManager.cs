using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            if (category.CategoryName.Length<2)
            {
                throw new Exception("Kategori ismi min 2 karakter olmalıdır");
            }

            _categoryDal.Add(category);
        }

        public bool CheckIfCategoryStartsWithC(int categoryId)
        {
            //
            return _categoryDal.CheckIfCategoryStartsWithC(categoryId);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
    }
}
