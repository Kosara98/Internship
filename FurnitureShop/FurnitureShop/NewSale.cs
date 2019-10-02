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
    public partial class NewSale : Form
    {
        Sales sale = new Sales();

        public NewSale()
        {
            InitializeComponent();
            
        }

        private void btnAddMore_Click_1(object sender, EventArgs e)
        {
            // For name of the product
            ComboBox cb = new ComboBox();
            cb.Left = 112;
            int top = pSales.Controls.OfType<ComboBox>().Last().Top + 30;
            cb.Top = top;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Size = cbProduct.Size;

            //For quantity of the product
            Label lb = new Label();
            lb.Text = "Quantity";
            lb.Left = 200;
            lb.Top = top;
            lb.Size = lblQuantity.Size;

            NumericUpDown numUp = new NumericUpDown();
            numUp.Left = 251;
            numUp.Top = top;
            numUp.Size = numQuantity.Size;

            pSales.Controls.Add(cb);
            pSales.Controls.Add(lb);
            pSales.Controls.Add(numUp);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
