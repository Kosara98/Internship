using System;
using System.Linq;
using System.Windows.Forms;
using FurnitureShopAdo.DataAccess.Models;
using FurnitureShopAdo.DataAccess;
using FurnitureShopAdo.DataAccess.Repositories;

namespace FurnitureShop
{
    public partial class ProductUpdateForm : Form
    {
        private ProductRepository productConnection = new ProductRepository();
        private Product updatedProduct;

        public ProductUpdateForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbNameProduct.Text == null || numPrice.Value == 0 || numWeight.Value == 0)
                MessageBox.Show("Fill in all the information");
            else if (tbBarcode.TextLength < 13)
                MessageBox.Show("The barcode must be 13 characters");
            else if (tbNameProduct.Text.Any(c => char.IsNumber(c)))
                MessageBox.Show("The name should not contains numbers.");
            else
            {
                updatedProduct.Name = tbNameProduct.Text;
                updatedProduct.Description = rtbDescription.Text;
                updatedProduct.Barcode = tbBarcode.Text;
                updatedProduct.Price = numPrice.Value;
                updatedProduct.Weight = numWeight.Value;
                productConnection.Update(updatedProduct);
                MessageBox.Show("Successfully updated the product!");
                Close();
            }
        }

        public void SetInfo(Product product)
        {
            updatedProduct = product;
            tbNameProduct.Text = product.Name;
            tbBarcode.Text = product.Barcode;
            numWeight.Value = product.Weight;
            numPrice.Value = product.Price;
            rtbDescription.Text = product.Description;
        }
    }
}
