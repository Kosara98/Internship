using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FurnitureShop.Core.Models;
using FurnitureShop.Core.Repositories;

namespace FurnitureShop
{
    public partial class NewSaleForm : Form
    {
        private readonly ISaleRepository saleConnection;
        private readonly IClientRepository clientConnection;
        private readonly IProductRepository productConnection;
        private Sale sale;
        private List<ProductSale> productSales;
        private Button button;
       
        public NewSaleForm(ISaleRepository saleRepository, IClientRepository clientRepository, IProductRepository productRepository)
        {
            saleConnection = saleRepository;
            clientConnection = clientRepository;
            productConnection = productRepository;
            sale = new Sale();
            productSales = new List<ProductSale>();
            button = new Button();

            InitializeComponent();

            cbClient.DataSource = clientConnection.GetAll();
            cbClient.DisplayMember = "Name";
            cbClient.ValueMember = "Id";

            cbProduct.DataSource = productConnection.GetAll();
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "Id";

            var productSale = new ProductSale();
            productSales.Add(productSale);

            Binding bindingInvoice = new Binding("Text", sale, "Invoice");
            Binding bindingDatе = new Binding("Text", sale, "SaleDate");
            Binding bindingProduct = new Binding("SelectedValue", productSale, "ProductId");
            Binding bindingQuantity = new Binding("Value", productSale, "Quantity");

            dateTimePicker1.DataBindings.Add(bindingDatе);
            tbInvoice.DataBindings.Add(bindingInvoice);
            cbProduct.DataBindings.Add(bindingProduct);
            numQuantity.DataBindings.Add(bindingQuantity);
        }

        private void btnAddMore_Click_1(object sender, EventArgs e)
        {
            var newProductSaleViewModel = new ProductSale();
            productSales.Add(newProductSaleViewModel);
            int top = pSales.Controls.OfType<ComboBox>().Last().Top + 30;

            //Name of the product
            ComboBox cb = new ComboBox
            {
                Name = "cb",
                Left = 112,
                Top = top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Size = cbProduct.Size,
                DataSource = productConnection.GetAll(),
                DisplayMember = "Name",
                ValueMember = "Id"
            };
            cb.DataBindings.Add(new Binding("SelectedValue", newProductSaleViewModel, "ProductId"));

            //Quantity of the product
            Label lb = new Label
            {
                Name = "lb",
                Text = "Quantity",
                Left = 200,
                Top = top,
                Size = lblQuantity.Size
            };

            NumericUpDown numUp = new NumericUpDown
            {
                Name = "num",
                Left = 251,
                Top = top,
                Size = numQuantity.Size,
                Minimum = 1
            };
            numUp.DataBindings.Add(new Binding("Value", newProductSaleViewModel, "Quantity"));

            button.Name = "btnClear";
            button.Text = "Clear";
            button.Left = 314;
            button.Top = numUp.Top;
            button.Size = btnAddMore.Size;
            button.Click += btnClear_Click;

            pSales.Controls.Add(cb);
            pSales.Controls.Add(lb);
            pSales.Controls.Add(numUp);
            pSales.Controls.Add(button);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control item in pSales.Controls.OfType<Control>().ToList())
                if (item.Name == "cb" || item.Name == "lb" || item.Name == "num" || item.Name == "btnClear")
                    pSales.Controls.Remove(item); 

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbClient.SelectedIndex == -1 || cbProduct.SelectedIndex == -1)
                MessageBox.Show("Fill in all the information");
            else if (tbInvoice.TextLength < 10 || tbInvoice.Text.Any(c => !char.IsDigit(c)))
                MessageBox.Show("The invoice must be 10 numbers");
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
                if (sale.Products.ContainsKey(item.ProductId))
                    continue;
                else
                    sale.Products.Add(item.ProductId, item.Quantity);
            }

            sale.Client = cbClient.Text;
            saleConnection.Insert(sale);
            sale.Products.Clear();

            MessageBox.Show("Successfully added new sale!");
            Close();
        }
    }
}
