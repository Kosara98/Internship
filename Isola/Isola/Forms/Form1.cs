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

        public Form1()
        {
            InitializeComponent();
            cbSize.DataSource = size;
            cbTurn.DataSource = turn;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            List<Player> newPlayers = new List<Player>();
            players = newPlayers;
            BoardGameForm boardForm = new BoardGameForm();
            boardForm.FormClosed += new FormClosedEventHandler(ChildForm_Closed);
            Player playerOne = new Player();
            Player playerTwo = new Player();

            if ((int)cbTurn.SelectedItem == 1)
            {
                playerOne.Turn = 1;
                playerTwo.Turn = 2;
            }
            else
            {
                playerOne.Turn = 2;
                playerTwo.Turn = 1;
            }
            playerOne.Name = playerOne.Turn.ToString();
            playerTwo.Name = playerTwo.Turn.ToString();

            players.Add(playerOne);
            players.Add(playerTwo);
            
            board.Size = (int)cbSize.SelectedItem;
            boardForm.BoardMaking(board, players);
            boardForm.Show();
            Hide();
        }

        private void ChildForm_Closed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}
