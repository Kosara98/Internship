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
    public partial class ProductUpdateForm : Form
    {
        private ProductConnection productConnection = new ProductConnection();
        private int productId;

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
                productConnection.Update(tbNameProduct.Text, rtbDescription.Text, numWeight.Value, tbBarcode.Text, numPrice.Value, productId);
                MessageBox.Show("Successfully updated the product!");
                Close();
            }
        }

        public void SetInfo(int id, string name, string barcode, decimal weight, decimal price, string description)
        {
            productId = id;
            tbNameProduct.Text = name;
            tbBarcode.Text = barcode;
            numWeight.Value = weight;
            numPrice.Value = price;
            rtbDescription.Text = description;
        }
    }
}
