using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FurnitureShop.Core.Models;
using FurnitureShop.Core.Repositories;

namespace FurnitureShop
{
    public partial class SaleUpdateForm : Form
    {
        private readonly ISaleRepository saleConnection;
        private readonly IProductRepository productConnection;
        private List<ProductSale> productSales;
        private Sale upgradeSale;

        public SaleUpdateForm(ISaleRepository saleRepository, IProductRepository productRepository)
        {
            saleConnection = saleRepository;
            productConnection = productRepository;
            upgradeSale = new Sale();
            productSales = new List<ProductSale>();

            InitializeComponent();

            cbProduct.DataSource = productConnection.GetAll();
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "Id";

            var productSale = new ProductSale();
            productSales.Add(productSale);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbProduct.SelectedIndex == -1)
                MessageBox.Show("Fill in all the information");
            else if (pSales.Controls.OfType<ComboBox>().ToList().Count() > 2)
            {
                bool hasBeenChosen = false;
                List<ComboBox> controls = pSales.Controls.OfType<ComboBox>().ToList();

                for (int i = 1; i < controls.Count(); i++)
                {
                    if (hasBeenChosen == true)
                        break;
                    else
                        for (int index = i + 1; index < controls.Count(); index++)
                            if (controls[i].SelectedIndex == controls[index].SelectedIndex && hasBeenChosen == false)
                            {
                                MessageBox.Show("Selected Option has already been chosen");
                                hasBeenChosen = true;
                                break;
                            }
                }
                if (hasBeenChosen == false)
                    InsertSale();
            }
            else
                InsertSale();
        }

        private void InsertSale()
        {
            foreach (var item in productSales)
            {
                if (upgradeSale.Products.ContainsKey(item.ProductId))
                    continue;
                else
                    upgradeSale.Products.Add(item.ProductId, item.Quantity);
            }

            saleConnection.Insert(upgradeSale);
            upgradeSale.Products.Clear();

            MessageBox.Show("Successfully added new sale!");
            Close();
        }

        public void SetInfo(Sale sale)
        {
            upgradeSale = sale;
            tbInvoice.Text = sale.Invoice;
            tbDate.Text = sale.SaleDate.ToLongDateString();
            tbClient.Text = sale.Client;
        }
    }
}
