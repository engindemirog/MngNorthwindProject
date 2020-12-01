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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        IProductService _productService = new ProductManager(new EfProductDal());
        private void ProductForm_Load(object sender, EventArgs e)
        {
            dgrwProducts.DataSource = null;
            dgrwProducts.DataSource = _productService.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                CategoryId = Convert.ToInt32(tbxCategoryId.Text),
                ProductName = tbxProductName.Text,
                QuantityPerUnit = tbxQuantityPerUnit.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                UnitsInStock = Convert.ToInt16(tbxUnitsInStock.Text)
            };

            _productService.Add(product);
            ProductForm_Load(sender,e);
        }
    }
}
