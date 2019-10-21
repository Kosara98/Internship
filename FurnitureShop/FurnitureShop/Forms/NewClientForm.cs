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
    public partial class NewClientForm : Form
    {
        private Client client = new Client();
        private ClientConnection clientConnection = new ClientConnection();

        public NewClientForm()
        {
            InitializeComponent();

            Binding bindingName = new Binding("Text", client, "Name");
            Binding bindingAddress = new Binding("Text", client, "Address");
            Binding bindingBulstat = new Binding("Text", client, "Bulstat");
            Binding bindingMol = new Binding("Text", client, "Mol");
            Binding bindingVat = new Binding("Text", client, "RegisteredVat");
                
            tbNameClient.DataBindings.Add(bindingName);
            tbAdress.DataBindings.Add(bindingAddress);
            tbBulstat.DataBindings.Add(bindingBulstat);
            tbMol.DataBindings.Add(bindingMol);
            cbVat.DataBindings.Add(bindingVat);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbAdress.Text == null || tbMol.Text == null || tbNameClient.Text == null || cbVat.SelectedIndex == -1)
                MessageBox.Show("Fill in all the information");
            else if (tbBulstat.TextLength < 9 || tbBulstat.Text.Any(c => !char.IsDigit(c)))
                MessageBox.Show("The bulstat must be 9 numbers");
            else if (tbMol.Text.Any(c => char.IsNumber(c)))
                MessageBox.Show("Тhe mol should not contains numbers.");
            else
            {
                clientConnection.Insert(client);
                MessageBox.Show("Successfully added new client!");
                Close();
            }
        }
    }
}
