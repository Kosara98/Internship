﻿using System;
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
        private ProductUpdateForm productUpdateForm = new ProductUpdateForm();
        private ClientUpdateForm clientUpdateForm = new ClientUpdateForm();

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
            {
                dataGrid.DataSource = new BindingSource(productConnection.ShowAll(), null); ;
                dataGrid.Columns["Id"].Visible = false;
            }
            else if (cbTables.SelectedIndex == 1)
            {
                dataGrid.DataSource = new BindingSource(clientConnection.ShowAll(), null);
                dataGrid.Columns["Id"].Visible = false;
            }
            else if (cbTables.SelectedIndex == 2)
                dataGrid.DataSource = new BindingSource(saleConnection.ShowAll(), null);

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
                BindingSource bindingSource = new BindingSource(productConnection.ShowAll(), null);
                Product currentProduct = (Product)bindingSource.Current;
                productConnection.Delete(currentProduct.Barcode);
            }
            else if (cbTables.SelectedIndex == 1)
            {
                BindingSource bindingSource = new BindingSource(clientConnection.ShowAll(), null);
                Client currentClient = (Client)bindingSource.Current;
                clientConnection.Delete(currentClient.Bulstat);
            }
            else if (cbTables.SelectedIndex == 2)
            {
                BindingSource bindingSource = new BindingSource(saleConnection.ShowAll(), null);
                Sale currentSale = (Sale)bindingSource.Current;
                saleConnection.Delete(currentSale.Invoice);
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
            if (cbTables.SelectedIndex == 0)
            {
                BindingSource bindingSource = new BindingSource(productConnection.ShowAll(), null);
                Product currentProduct = (Product)bindingSource.Current;

                productUpdateForm.SetInfo
                    (currentProduct.Id,currentProduct.Name,currentProduct.Barcode,currentProduct.Weight,currentProduct.Price, currentProduct.Description);
                productUpdateForm.Show();
            }
            else if (cbTables.SelectedIndex == 1)
            {
                BindingSource bindingSource = new BindingSource(clientConnection.ShowAll(), null);
                Client currentClient = (Client)bindingSource.Current;

                clientUpdateForm.SetInfo
                    (currentClient.Id,currentClient.Name,currentClient.Address,currentClient.Bulstat,currentClient.Mol,currentClient.RegisteredVat);
                clientUpdateForm.Show();
            }
            btnShow.PerformClick();
        }
    }
}
