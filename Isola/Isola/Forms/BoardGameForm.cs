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
    public partial class BoardGameForm : Form
    {
        private int countMoves = 0;
        private Board board;
        private Player player;
        private List<Player> players = new List<Player>();
        private Button[,] matrixBoard;
        private byte turn = 0;

        public BoardGameForm()
        {
            InitializeComponent();
        }

        public void BoardMaking(Board newBoard, List<Player> listOfPlayers)
        {
            board = newBoard;
            players = listOfPlayers;
            matrixBoard = new Button[board.Size, board.Size];

            int top = 0;
            int left = 0;

            for (int y = 0; y < board.Size; y++)
            {
                left += 35;
                top = -5;

                for (int x = 0; x < board.Size; x++)
                {
                    top += 35;
                    matrixBoard[x, y] = new Button()
                    {
                        Width = 35,
                        Height = 35,
                        Left = left,
                        Top = top,
                        Parent = panel
                    };
                    matrixBoard[x, y].Tag = $"{x}_{y}";
                    matrixBoard[x, y].Click += Button_Click;
                }
            }
            
            if (board.Size == 3)
                this.Size = new Size(195, 200);
            else if (board.Size == 5)
                this.Size = new Size(260, 270);
            else if (board.Size == 7)
                this.Size = new Size(330, 350);

            panel.Size = new Size(this.Size.Width, this.Size.Height + 50);
            SetUpPlayers();
        }

        private void SetUpPlayers()
        {
            foreach (var item in matrixBoard)
            {
                if (item.Tag.ToString() == $"0_{board.Size / 2}")
                {
                    item.Text = players[1].Name.ToString();
                    players[1].Row = 0;
                    players[1].Column = board.Size / 2;
                }
                if (item.Tag.ToString() == $"{board.Size - 1}_{board.Size / 2}")
                {
                    item.Text = players[0].Name.ToString();
                    players[0].Row = board.Size - 1;
                    players[0].Column = board.Size / 2;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            player = players[turn];
            Button currentButton = (Button)sender;
            string[] currentLocation = new string[2];

            currentLocation = currentButton.Tag.ToString().Split('_');
            int row = Convert.ToInt32(currentLocation[0]);
            int column = Convert.ToInt32(currentLocation[1]);

            List<KeyValuePair<int, int>> legalMoves = player.LeaglMoves(board);

            if (countMoves == 0)
            {
                if (legalMoves.Contains(new KeyValuePair<int,int>(row,column)))
                {
                    if (currentButton.Text == "")
                    {
                        //clear the previous lovation of the player
                        foreach (var button in matrixBoard)
                            if (button.Tag.ToString() == $"{player.Row}_{player.Column}")
                                button.Text = "";

                        //setting the new location of the player
                        foreach (var item in legalMoves)
                            if (currentButton.Tag.ToString() == $"{item.Key}_{item.Value}")
                            {
                                currentButton.Text = player.Name;
                                player.Row = row;
                                player.Column = column;
                            }

                        countMoves++;
                    }
                    else
                        MessageBox.Show("You can't be on the same spot as your opponent.");
                }
                else
                    MessageBox.Show("You can move with only one cell");
            }
            else if (countMoves == 1)
            {
                countMoves = 0;
                currentButton.Enabled = false;
                board.Eliminated.Add(new KeyValuePair<int, int>(row, column));
                Player opponent;

                if (turn == 0)
                {
                    opponent = players[1];
                    turn = 1;
                }
                else
                {
                    opponent = players[0];
                    turn = 0;
                }

                List<KeyValuePair<int, int>> legalMovesOpponent = opponent.LeaglMoves(board);

                if (legalMovesOpponent.Count <= 1 )
                {
                    if (legalMovesOpponent.Contains(new KeyValuePair<int, int>(player.Row,player.Column)))
                    {
                        MessageBox.Show($"{player.Name} WON");
                        Close();
                    }
                }
            }
        }
    }
}
