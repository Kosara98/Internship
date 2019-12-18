using FurnitureShop.Core.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using FurnitureShop.Core.Repositories;

namespace FurnitureShop
{
    public partial class ClientUpdateForm : Form
    {
        private readonly IClientRepository clientConnection;
        private Client updatedClient;

        public ClientUpdateForm(IClientRepository clientRepository)
        {
            clientConnection = clientRepository;
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbAdress.Text == null || tbMol.Text == null || tbNameClient.Text == null || cbVat.SelectedIndex == -1)
                MessageBox.Show("Fill in all the information");
            else if (tbBulstat.TextLength < 9 || tbBulstat.Text.Any(c => !char.IsDigit(c)))
                MessageBox.Show("The bulstat must be 9 numbers");
            else if (tbMol.Text.Any(c => char.IsNumber(c)))
                MessageBox.Show("Тhe mol should not contains numbers.");
            else
            {
                updatedClient.Name = tbNameClient.Text;
                updatedClient.Address = tbAdress.Text;
                updatedClient.Bulstat = tbBulstat.Text;
                updatedClient.Mol = tbMol.Text;
                updatedClient.RegisteredVat = cbVat.SelectedIndex == 1 ? 'Y' : 'N';
                clientConnection.Update(updatedClient);
                MessageBox.Show("Successfully updated the client!");
                Close();
            }
        }

        public void SetInfo(Client client)
        {
            updatedClient = client;
            tbNameClient.Text = client.Name;
            tbAdress.Text = client.Address;
            tbBulstat.Text = client.Bulstat;
            tbMol.Text = client.Mol;
            cbVat.SelectedIndex = client.RegisteredVat == 'Y' ? 1 : 0;
        }
    }
}
