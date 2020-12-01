using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            dgrwProducts.DataSource = _productService.GetAll();
        }
    }
}
