using System;
using System.Threading;
using System.Windows.Forms;

namespace FurnitureShop
{
    public partial class Form1 : Form
    {
        private static ProductConnection productConnection = new ProductConnection();
        private static ClientConnection clientConnection = new ClientConnection();
        private static SaleConnection saleConnection = new SaleConnection();
        private BindingSource productSource = new BindingSource(productConnection.GetAll(), null);
        private BindingSource clientSource = new BindingSource(clientConnection.GetAll(), null);
        private BindingSource saleSource = new BindingSource(saleConnection.GetAll(), null);

        public Form1()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);
            InitializeComponent();
        }

        private void newClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewClientForm newClient = new NewClientForm();
            newClient.FormClosed += new FormClosedEventHandler(childForm_Closed);
            newClient.Show();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProductForm newProduct = new NewProductForm();
            newProduct.FormClosed += new FormClosedEventHandler(childForm_Closed);
            newProduct.Show();
        }

        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSaleForm newSale = new NewSaleForm();
            newSale.FormClosed += new FormClosedEventHandler(childForm_Closed);
            newSale.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            BindingSource newProductSource = new BindingSource(productConnection.GetAll(), null);
            BindingSource newClientSource = new BindingSource(clientConnection.GetAll(), null);
            BindingSource newSaleSource = new BindingSource(saleConnection.GetAll(), null);
            productSource = newProductSource;
            clientSource = newClientSource;
            saleSource = newSaleSource;

            if (cbTables.SelectedIndex == 0)
            {
                dataGrid.DataSource = productSource;
                dataGrid.Columns["Id"].Visible = false;
            }
            else if (cbTables.SelectedIndex == 1)
            {
                dataGrid.DataSource = clientSource;
                dataGrid.Columns["Id"].Visible = false;
            }
            else if (cbTables.SelectedIndex == 2)
            {
                dataGrid.DataSource = saleSource;
                dataGrid.Columns["Id"].Visible = false;
            }
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbTables.SelectedIndex == 0)
            {
                Product currentProduct = (Product)productSource.Current;
                productConnection.Delete(currentProduct);
                MessageBox.Show("Successfully deleted the product!");
            }
            else if (cbTables.SelectedIndex == 1)
            {
                Client currentClient = (Client)clientSource.Current;
                clientConnection.Delete(currentClient);
                MessageBox.Show("Successfully deleted the client!");
            }
            else if (cbTables.SelectedIndex == 2)
            {
                Sale currentSale = (Sale)saleSource.Current;
                saleConnection.Delete(currentSale);
                MessageBox.Show("Successfully deleted the sale!");
            }
            btnShow.PerformClick();
        }

        private void CellSelected(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (cbTables.SelectedIndex != 2)
                btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductUpdateForm productUpdateForm = new ProductUpdateForm();
            productUpdateForm.FormClosed += new FormClosedEventHandler(childForm_Closed);

            ClientUpdateForm clientUpdateForm = new ClientUpdateForm();
            clientUpdateForm.FormClosed += new FormClosedEventHandler(childForm_Closed);

            SaleUpdateForm saleUpdateForm = new SaleUpdateForm();
            saleUpdateForm.FormClosed += new FormClosedEventHandler(childForm_Closed);

            if (cbTables.SelectedIndex == 0)
            {
                Product currentProduct = (Product)productSource.Current;
                productUpdateForm.SetInfo(currentProduct);
                productUpdateForm.Show();
            }
            else if (cbTables.SelectedIndex == 1)
            {
                Client currentClient = (Client)clientSource.Current;
                clientUpdateForm.SetInfo(currentClient);
                clientUpdateForm.Show();
            }
            else if (cbTables.SelectedIndex == 2)
            {
                Sale curentSale = (Sale)saleSource.Current;
                saleUpdateForm.SetInfo(curentSale);
                saleUpdateForm.Show();
            }
        }

        private void childForm_Closed(object sender, EventArgs e)
        {
            btnShow.PerformClick();
        }
    }
}
