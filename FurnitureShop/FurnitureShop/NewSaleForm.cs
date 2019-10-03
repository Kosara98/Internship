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

            Binding bindingQuantity = new Binding("Value", sale, "Quantity");
            Binding bindingInvoice = new Binding("Text", sale, "Invoice");
            Binding bindingData = new Binding("Value", sale, "SaleDate");

            tbInvoice.DataBindings.Add(bindingInvoice);
            numQuantity.DataBindings.Add(bindingQuantity);
            dateTimePicker1.DataBindings.Add(bindingData);
        }

        private void btnAddMore_Click_1(object sender, EventArgs e)
        {
            // For name of the product
            ComboBox cb = new ComboBox();
            cb.Name = newNameComboBox;
            cb.Left = 112;
            int top = pSales.Controls.OfType<ComboBox>().Last().Top + 30;
            cb.Top = top;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Size = cbProduct.Size;
            cb.Items.AddRange(productConnection.FillComboBox().ToArray());

            //For quantity of the product
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

            pSales.Controls.Add(cb);
            pSales.Controls.Add(lb);
            pSales.Controls.Add(numUp);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            saleConnection.Insert(sale.SaleDate, sale.Invoice,sale.Quantity,cbProduct.SelectedIndex,cbClient.SelectedIndex);

            //Return form to default
            cbClient.SelectedIndex = -1;
            tbInvoice.Text = "";
            cbProduct.SelectedIndex = -1;
            numQuantity.Value = 0;

            foreach (Control item in pSales.Controls.OfType<ComboBox>().ToList())
            {
                if (item.Name == newNameComboBox)
                    pSales.Controls.Remove(item);
            }

            foreach (Control item in pSales.Controls.OfType<Label>().ToList())
            {
                if (item.Name == newNameLabel)
                    pSales.Controls.Remove(item);
            }

            foreach (Control item in pSales.Controls.OfType<NumericUpDown>().ToList())
            {
                if (item.Name == newNameNumeric)
                    pSales.Controls.Remove(item);
            }
        }
    }
}
