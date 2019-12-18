using System;
using System.Linq;
using System.Windows.Forms;
using FurnitureShopAdo.DataAccess.Models;
using FurnitureShopAdo.DataAccess.Repositories;

namespace FurnitureShop
{
    public partial class NewProductForm : Form
    {
        private Product product = new Product();
        private ProductRepository productConnection = new ProductRepository();

        public NewProductForm()
        {
            InitializeComponent();

            Binding bindingName = new Binding("Text", product, "Name");
            Binding bindingDescription = new Binding("Text", product, "Description");
            Binding bindingBarcode = new Binding("Text", product, "Barcode");
            Binding bindingWeight = new Binding("Value", product, "Weight");
            Binding bindingPrice = new Binding("Value", product, "Price");

            tbNameProduct.DataBindings.Add(bindingName);
            rtbDescription.DataBindings.Add(bindingDescription);
            tbBarcode.DataBindings.Add(bindingBarcode);
            numWeight.DataBindings.Add(bindingWeight);
            numPrice.DataBindings.Add(bindingPrice);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbNameProduct.Text == null ||  numPrice.Value == 0 || numWeight.Value == 0)
                MessageBox.Show("Fill in all the information");
            else if (tbBarcode.TextLength < 13)
                MessageBox.Show("The barcode must be 13 characters");
            else if (tbNameProduct.Text.Any(c => char.IsNumber(c)))
                MessageBox.Show("The name should not contains numbers.");
            else
            {
                productConnection.Insert(product);
                MessageBox.Show("Successfully added new product!");
                Close();
            }
        }
    }
}
