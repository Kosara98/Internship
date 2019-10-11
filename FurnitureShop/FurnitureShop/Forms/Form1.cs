using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureShop
{
    public partial class Form1 : Form
    {
        private ProductConnection productConnection = new ProductConnection();
        private ClientConnection clientConnection = new ClientConnection();
        private SaleConnection saleConnection = new SaleConnection();

        public Form1()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);
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
                dataGridView1.DataSource = new BindingSource(productConnection.ShowAllProducts(), null); 
            else if (cbTables.SelectedIndex == 1)
                dataGridView1.DataSource = new BindingSource(clientConnection.ShowAllClients(), null);
            else if (cbTables.SelectedIndex == 2)
                dataGridView1.DataSource = new BindingSource(saleConnection.ShowAllSales(), null);
        }

        private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Error", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Error",
                        "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact the adminstrator " +
                "with the following information:\n\n";
            errorMsg += e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
        }
    }
}
