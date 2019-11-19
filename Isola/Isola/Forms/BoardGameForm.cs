using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isola
{
    public partial class BoardGameForm : Form
    {
        private AI ai;
        private Player firstPlayer;
        private Player secondPlayer;
        private Player currentPlayer;
        private Cell[,] matrixBoard;
        private byte playerNumber = 0;
        private int countMoves = 0;
        private int turn;

        public BoardGameForm()
        {
            InitializeComponent();
        }

        public void BoardMaking(int size, Player playerOne, Player playerTwo, int aiTurn)
        {
            turn = aiTurn;
            firstPlayer = playerOne;
            matrixBoard = new Cell[size, size];

            if (playerOne.GetType() != playerTwo.GetType())
                ai = (AI)playerTwo;
            else
                secondPlayer = playerTwo;

            int top = 0;
            int left = 0;

            for (int y = 0; y < size; y++)
            {
                left += 35;
                top = -5;

                for (int x = 0; x < size; x++)
                {
                    top += 35;
                    matrixBoard[x, y] = new Cell()
                    {
                        Width = 35,
                        Height = 35,
                        Top = top,
                        Left = left,
                        Parent = panel,
                        Status = Status.Active,
                        PositionRow = x,
                        PositionColumn = y,
                        NameTag = new KeyValuePair<int,int> (x,y)
                    };
                    matrixBoard[x, y].Click += Button_Click;
                }
            }
            
            if (size == 3)
                this.Size = new Size(195, 200);
            else if (size == 5)
                this.Size = new Size(260, 270);
            else if (size == 7)
                this.Size = new Size(330, 350);

            panel.Size = new Size(this.Size.Width, this.Size.Height + 50);
            SetUpPlayers();

            if (turn == 1)
                AIMoves();
            else
                turn = 0;
        }

        private void SetUpPlayers()
        {
            Player playerTwo = secondPlayer == null ? ai : secondPlayer;
            foreach (var item in matrixBoard)
            {
                if (item.PositionRow == 0 && item.PositionColumn == matrixBoard.GetLength(0) / 2) 
                {
                    item.Text = playerTwo.Name.ToString();
                    playerTwo.Row = item.PositionRow;
                    playerTwo.Column = item.PositionColumn;
                    item.Status = Status.Inactive;
                }
                if (item.PositionRow == matrixBoard.GetLength(0) - 1 && item.PositionColumn == matrixBoard.GetLength(0) / 2)
                {
                    item.Text = firstPlayer.Name.ToString();
                    firstPlayer.Row = item.PositionRow;
                    firstPlayer.Column = item.PositionColumn;
                    item.Status = Status.Inactive;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            currentPlayer = playerNumber == 0 ? firstPlayer : secondPlayer;
            
            Cell currentCell = (Cell)sender;
            int row = currentCell.PositionRow;
            int column = currentCell.PositionColumn;
            
            if (countMoves == 0)
                MovePlayer(currentCell, row, column);
            else if (countMoves == 1)
            {
                if (EliminatedCell(currentCell, row, column))
                {
                    countMoves = 0;
                    if (IsItEnded())
                    {
                        currentPlayer.Name = currentPlayer.Name == "P1" ? "Player 1" : currentPlayer.Name == "P" ? "Player" : "Player 2";
                        MessageBox.Show($"{currentPlayer.Name} won");
                        Close();
                    }
                    else if (secondPlayer == null)
                        AIMoves();
                } 
            }
        }

        private void AIMoves()
        {
            ai.MovePlayer(firstPlayer, matrixBoard);
            KeyValuePair<int, int> eliminatedCell = ai.EliminatedCell(matrixBoard);
            
            foreach (var item in matrixBoard)
            {
                if (item.NameTag.Equals(new KeyValuePair<int,int>(ai.Row,ai.Column)))
                    item.Text = ai.Name;
                else if (item.Text == ai.Name)
                {
                    item.Text = "";
                    item.Status = Status.Active;
                }
                if (item.NameTag.Equals(eliminatedCell))
                {
                    item.Enabled = false;
                    item.Status = Status.Inactive;
                } 
            }
            
            if (IsItEnded())
            {
                MessageBox.Show("Computer won");
                Close();
            }
        }
        
        private bool IsItEnded()
        {
            Player opponent = new Player();

            if (secondPlayer == null)
            {
                playerNumber = (int)Turns.PlayerOne;
                if (turn == (int)Turns.PlayerOne)
                {
                    opponent = ai;
                    turn = (int)Turns.PlayerTwo;
                }
                else
                {
                    opponent = firstPlayer;
                    turn = (int)Turns.PlayerOne;
                } 
            }
            else if (playerNumber == (int)Turns.PlayerOne)
            {
                opponent = secondPlayer;
                playerNumber = (int)Turns.PlayerTwo;
            }
            else
            {
                opponent = firstPlayer;
                playerNumber = (int)Turns.PlayerOne;
            }
            List<KeyValuePair<int, int>> legalMovesOpponent = opponent.LegalMoves(matrixBoard);
            
            if (legalMovesOpponent.Count() <= 1)
                if (legalMovesOpponent.Count() == 0 || legalMovesOpponent.Contains(new KeyValuePair<int, int>(firstPlayer.Row, firstPlayer.Column))
                    || legalMovesOpponent.Contains(new KeyValuePair<int, int>(opponent.Row, opponent.Column)))
                    return true;

            return false;
        }

        private bool EliminatedCell(Cell cell, int row, int column)
        {
            if (cell.Text != "")
                MessageBox.Show("Can't eliminated the cell when there is a player.");
            else
            {
                cell.Enabled = false;
                cell.Status = Status.Inactive;
                return true;
            }
            return false;
        }

        private void MovePlayer(Cell button, int row, int column)
        {
            List<KeyValuePair<int, int>> legalMoves = currentPlayer.LegalMoves(matrixBoard);
            
            if (legalMoves.Contains(button.NameTag))
            {
                if (button.Text == "")
                {
                    //clear the previous location of the player
                    foreach (var cell in matrixBoard)
                        if (cell.NameTag.Equals(new KeyValuePair<int,int>(currentPlayer.Row, currentPlayer.Column)))
                        {
                            cell.Text = "";
                            cell.Status = Status.Active;
                        }
                            
                    //setting the new location of the player
                    foreach (var item in legalMoves)
                        if (button.NameTag.Equals(item))
                        {
                            button.Text = currentPlayer.Name;
                            currentPlayer.Row = row;
                            currentPlayer.Column = column;
                            button.Status = Status.Inactive;
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
