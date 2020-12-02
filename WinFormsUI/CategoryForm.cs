using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            dgrwCategories.DataSource = null;
            dgrwCategories.DataSource = _categoryService.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var category = new Category { CategoryName = tbxCategoryName.Text };
            _categoryService.Add(category);
            CategoryForm_Load(sender,e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToShortDateString());
        }
    }
}
