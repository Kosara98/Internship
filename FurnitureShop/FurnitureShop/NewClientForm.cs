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
        Client client = new Client();
        ClientConnection clientConnection = new ClientConnection();

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
            clientConnection.Insert(client.Name, client.Address, client.Bulstat, client.RegisteredVat, client.Mol);

            tbNameClient.Text = "";
            tbAdress.Text = "";
            tbMol.Text = "";
            tbBulstat.Text = "";
            cbVat.SelectedIndex = -1;
        }
    }
}
