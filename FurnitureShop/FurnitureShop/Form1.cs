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
        Products product = new Products();
        Clients client = new Clients();
        Sales sale = new Sales();

        public Form1()
        {
            InitializeComponent();
        }

        private void newClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewClient newClient = new NewClient();
            newClient.Show();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.Show();
        }

        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSale newSale = new NewSale();
            newSale.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string text = cbTables.SelectedText;
        }
    }
}
