using Business.Abstract;
using Business.Concrete;
using Business.CustomExceptions;
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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        IProductService _productService = new ProductManager(new EfProductDal());
        ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        private void ProductForm_Load(object sender, EventArgs e)
        {
            dgrwProducts.DataSource = null;
            dgrwProducts.DataSource = _productService.GetAll();

            foreach (var category in _categoryService.GetAll())
            {
                cbxCategory.Items.Add(category);
                cbxCategory.DisplayMember = "CategoryName";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                CategoryId = ((Category)cbxCategory.SelectedItem).CategoryId,
                ProductName = tbxProductName.Text,
                QuantityPerUnit = tbxQuantityPerUnit.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                UnitsInStock = Convert.ToInt16(tbxUnitsInStock.Text)
            };

            try
            {
                _productService.Add(product);
            }
            catch (ProductNameException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch(Exception exception)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu.");
                MessageBox.Show($"Log : {exception.Message}");
            }
           
            ProductForm_Load(sender,e);
        }
    }
}
