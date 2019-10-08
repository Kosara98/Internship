using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureShop
{
    public partial class NewProductForm : Form
    {
        string message;
        Product product = new Product();
        ProductConnection productConnection = new ProductConnection();

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
            if (tbNameProduct.Text == null || tbBarcode.Text == null || numPrice.Value == 0 || numWeight.Value == 0)
            {
                message = "Fill in all the information";
                MessageBox.Show(message);
            }
            else if (tbBarcode.TextLength < 13)
            {
                message = "The barcode must be 13 characters";
                MessageBox.Show(message);
            }
            else if (tbNameProduct.Text.Any(c => !char.IsLetter(c)))
            {
                message = "The name should not contains numbers.";
                MessageBox.Show(message);
            }
            else
            {
                productConnection.Insert(product.Name, product.Description, product.Weight, product.Barcode, product.Price);

                message = "Successfully added new product!";
                MessageBox.Show(message);
                Close();
            }
        }
    }
}
