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
        private AI ai;
        private Button[,] matrixBoard;
        private List<Player> players;
        private byte playerNumber = 1;
        private int turn;

        public BoardGameForm()
        {
            InitializeComponent();
        }

        public void BoardMaking(Board newBoard, List<Player> listOfPlayers, int aiTurn)
        {
            turn = aiTurn;
            players = listOfPlayers;
            board = newBoard;
            board.Eliminated = new List<KeyValuePair<int, int>>();
            player = players[1];
            matrixBoard = new Button[board.Size, board.Size];

            if (players[0].GetType() != players[1].GetType())
                ai = (AI)players[0];

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
                    matrixBoard[x, y].Tag = new KeyValuePair<int,int>(x,y);
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
                if (item.Tag.Equals(new KeyValuePair<int,int>(0,board.Size/2)))
                {
                    item.Text = players[0].Name.ToString();
                    players[0].Row = 0;
                    players[0].Column = board.Size / 2;
                }
                if (item.Tag.Equals(new KeyValuePair<int,int>(board.Size - 1, board.Size / 2)))
                {
                    item.Text = player.Name.ToString();
                    player.Row = board.Size - 1;
                    player.Column = board.Size / 2;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            player = players[playerNumber];
            Button currentButton = (Button)sender;
            KeyValuePair<int,int> currentLocation = (KeyValuePair<int,int>)currentButton.Tag;
            int row = currentLocation.Key;
            int column = currentLocation.Value;
            
            if (countMoves == 0)
                MovePlayer(currentButton, row, column);
            else if (countMoves == 1)
            {
                if (EliminatedCell(currentButton, row, column))
                {
                    countMoves = 0;
                    if (IsItEnded())
                    {
                        MessageBox.Show($"{player.Name} WON");
                        Close();
                    }
                    else if (players[0].GetType() != players[1].GetType())
                        AIMoves();
                } 
            }
        }

        private void AIMoves()
        {
            KeyValuePair<int, int> newLocation = ai.MovePlayer(board, player);
            KeyValuePair<int, int> eliminatedCell = ai.EliminatedCell(board, player);
            
            foreach (var item in matrixBoard)
            {
                if (item.Tag.Equals(newLocation))
                    item.Text = ai.Name;
                else if (item.Text == ai.Name)
                    item.Text = "";
                if (item.Tag.Equals(eliminatedCell))
                    item.Enabled = false;
            }
            
            if (IsItEnded())
            {
                MessageBox.Show($"{ai.Name} WON");
                Close();
            }
        }
        
        private bool IsItEnded()
        {
            Player opponent = new Player();

            if (players[0].GetType() != players[1].GetType())
            {
                playerNumber = 1;
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
            }
            else if (playerNumber == 0)
            {
                opponent = players[1];
                playerNumber = 1;
            }
            else
            {
                opponent = players[0];
                playerNumber = 0;
            }

            List<KeyValuePair<int, int>> legalMovesOpponent = opponent.LegalMoves(board);
            
            if (legalMovesOpponent.Count <= 1)
            {
                if (legalMovesOpponent.Count == 0)
                    return true;

                if (players[0].GetType() != players[1].GetType())
                {
                    if (legalMovesOpponent.Contains(new KeyValuePair<int, int>(player.Row, player.Column)) || legalMovesOpponent.Contains(new KeyValuePair<int, int>(ai.Row,ai.Column)))
                        return true;
                }
                else
                    if (legalMovesOpponent.Contains(new KeyValuePair<int, int>(player.Row, player.Column)))
                        return true;
            }
            
            return false;
        }

        private bool EliminatedCell(Button button, int row, int column)
        {
            if (button.Text != "")
                MessageBox.Show("Can't eliminated the cell when there is a player.");
            else
            {
                button.Enabled = false;
                board.Eliminated.Add(new KeyValuePair<int, int>(row, column));
                return true;
            }
            return false;
        }

        private void MovePlayer(Button button, int row, int column)
        {
            List<KeyValuePair<int, int>> legalMoves = player.LegalMoves(board);
            
            if (legalMoves.Contains(new KeyValuePair<int, int>(row, column)))
            {
                if (button.Text == "")
                {
                    //clear the previous location of the player
                    foreach (var cell in matrixBoard)
                        if (cell.Tag.Equals(new KeyValuePair<int,int>(player.Row,player.Column)))
                            cell.Text = "";

                    //setting the new location of the player
                    foreach (var item in legalMoves)
                        if (button.Tag.Equals(new KeyValuePair<int,int>(item.Key, item.Value)))
                        {
                            button.Text = player.Name;
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
    }
}
