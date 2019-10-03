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
    public partial class Form1 : Form
    {
        ProductConnection productConnection = new ProductConnection();
        ClientConnection clientConnection = new ClientConnection();
        SaleConnection saleConnection = new SaleConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void newClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewClientForm newClient = new NewClientForm();
            newClient.Show();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProductForm newProduct = new NewProductForm();
            newProduct.Show();
        }

        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSaleForm newSale = new NewSaleForm();
            newSale.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cbTables.SelectedIndex == 0)
                dataGridView1.DataSource = new BindingSource(productConnection.SelectTable(), null);
            else if (cbTables.SelectedIndex == 1)
                dataGridView1.DataSource = new BindingSource(clientConnection.SelectTable(), null);
            else if (cbTables.SelectedIndex == 2)
                dataGridView1.DataSource = new BindingSource(saleConnection.SelectTable(), null);
        }
    }
}
