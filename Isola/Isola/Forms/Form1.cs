using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isola
{
    public partial class Form1 : Form
    {
        private int[] size = { 3, 5, 7 };
        private int[] turn = { 1, 2 };
        private string[] vs = { "Player VS Player", "Player VS Computer" };

        public Form1()
        {
            InitializeComponent();
            cbSize.DataSource = size;
            cbTurn.DataSource = turn;
            cbPlayerVs.DataSource = vs;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            BoardGameForm boardForm = new BoardGameForm();
            boardForm.FormClosed += new FormClosedEventHandler(ChildForm_Closed);
            Player playerOne = new Player();
            Player playerTwo;
            playerOne.Name = "P";
            int chosenTurn = 0;

            if ((string)cbPlayerVs.SelectedItem == "Player VS Player")
            {
                playerTwo = new Player();
                playerTwo.Name = "P2";
                playerOne.Name = "P1";
            }
            else
            {
                playerTwo = new AI();
                playerTwo.Name = "C";
                chosenTurn = (int)cbTurn.SelectedItem;
            }
            int boardSize = (int)cbSize.SelectedItem;

            if (cbTurn.Enabled == false)
                chosenTurn = 0;

            boardForm.BoardMaking(boardSize, playerOne, playerTwo, chosenTurn);
            boardForm.Show();
            Hide();
        }

        private void ChildForm_Closed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void cbPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbPlayerVs.SelectedItem == "Player VS Player")
                cbTurn.Enabled = false;
            else
                cbTurn.Enabled = true;
        }
    }
}
