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
    public partial class NewSaleForm : Form
    {
        string message;
        string newNameComboBox = "cb";
        string newNameLabel = "lb";
        string newNameNumeric = "num";

        Sale sale = new Sale();
        ClientConnection clientConnection = new ClientConnection();
        ProductConnection productConnection = new ProductConnection();
        SaleConnection saleConnection = new SaleConnection();


        public NewSaleForm()
        {
            InitializeComponent();

            cbClient.Items.AddRange(clientConnection.FillComboBox().ToArray());
            cbProduct.Items.AddRange(productConnection.FillComboBox().ToArray());
            
            Binding bindingInvoice = new Binding("Text", sale, "Invoice");
            Binding bindingDatе = new Binding("Text", sale, "SaleDate");

            dateTimePicker1.DataBindings.Add(bindingDatе);
            tbInvoice.DataBindings.Add(bindingInvoice);
        }

        private void btnAddMore_Click_1(object sender, EventArgs e)
        {
            //Name of the product
            ComboBox cb = new ComboBox();
            cb.Name = newNameComboBox;
            cb.Left = 112;
            int top = pSales.Controls.OfType<ComboBox>().Last().Top + 30;
            cb.Top = top;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Size = cbProduct.Size;
            cb.Items.AddRange(productConnection.FillComboBox().ToArray());

            //Quantity of the product
            Label lb = new Label();
            lb.Name = newNameLabel;
            lb.Text = "Quantity";
            lb.Left = 200;
            lb.Top = top;
            lb.Size = lblQuantity.Size;

            NumericUpDown numUp = new NumericUpDown();
            numUp.Name = newNameNumeric;
            numUp.Left = 251;
            numUp.Top = top;
            numUp.Size = numQuantity.Size;
            numUp.Minimum = 1;

            pSales.Controls.Add(cb);
            pSales.Controls.Add(lb);
            pSales.Controls.Add(numUp);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index = 0;
            List<int> quantity = new List<int>();

            if (tbInvoice.Text == null || cbClient.SelectedIndex == -1 || cbProduct.SelectedIndex == -1 || numQuantity.Value == 0)
            {
                message = "Fill in all the information";
                MessageBox.Show(message);
            }
            else if (tbInvoice.TextLength < 10 || tbInvoice.Text.Any(c => !char.IsDigit(c)))
            {
                message = "The invoice must be 10 numbers";
                MessageBox.Show(message);
            }
            else
            {
                foreach (NumericUpDown item in pSales.Controls.OfType<NumericUpDown>().ToList())
                    quantity.Add(Convert.ToInt32(item.Value));

                foreach (ComboBox item in pSales.Controls.OfType<ComboBox>().ToList())
                {
                    if (item.Name == "cbClient")
                        continue;

                    sale.Products.Add(item.SelectedIndex, quantity[index]);
                    index++;
                }

                saleConnection.Insert(sale.SaleDate, sale.Invoice, cbClient.SelectedIndex, sale.Products);

                sale.Products.Clear();

                message = "Successfully added new sale!";
                MessageBox.Show(message);
                Close();
            }
        }
    }
}
