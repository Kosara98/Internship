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
        private Board board = new Board();
        private List<Player> players = new List<Player>();
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
            List<Player> newPlayers = new List<Player>();
            players = newPlayers;
            BoardGameForm boardForm = new BoardGameForm();
            boardForm.FormClosed += new FormClosedEventHandler(ChildForm_Closed);
            Player playerOne = new Player();
            playerOne.Name = "U";

            if ((string)cbPlayerVs.SelectedItem == "Player VS Player")
            {
                Player playerTwo = new Player();
                playerTwo.Name = "U2";
                playerOne.Name = "U1";
                players.Add(playerTwo);
            }
            else
            {
                AI playerTwo = new AI();
                playerTwo.Name = "A";
                players.Add(playerTwo);
            }

            players.Add(playerOne);
            board.Size = (int)cbSize.SelectedItem;
            boardForm.BoardMaking(board, players);
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
