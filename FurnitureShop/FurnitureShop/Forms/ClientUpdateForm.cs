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
    public partial class ClientUpdateForm : Form
    {
        private ClientConnection clientConnection = new ClientConnection();
        private int clientId;

        public ClientUpdateForm()
        {
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
                clientConnection.Update(tbNameClient.Text, tbAdress.Text, tbBulstat.Text, Convert.ToChar(cbVat.SelectedText), tbMol.Text, clientId);
                MessageBox.Show("Successfully updated the client!");
                Close();
            }
        }

        public void SetInfo(int id, string name, string address, string bulstat, string mol, char vat)
        {
            clientId = id;
            tbNameClient.Text = name;
            tbAdress.Text = address;
            tbBulstat.Text = bulstat;
            tbMol.Text = mol;
            cbVat.SelectedIndex = vat == 'Y' ? 1 : 0;
        }
    }
}
