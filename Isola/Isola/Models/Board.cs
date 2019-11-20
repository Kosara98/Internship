using System;
using System.Collections.Generic;

namespace Isola
{
    public class Board
    {
        public Board(ICell[,] cells)
        {
            if (cells.GetLength(0) != cells.GetLength(1))
                throw new ArgumentOutOfRangeException();
            Matrix = cells;
        }

        public ICell[,] Matrix { get; private set; }

        public int Lenght { get => Matrix.GetLength(0); }

        public ICell this[int row, int column]
        {
            get { return Matrix[row,column]; }
            set { Matrix[row,column] = value; }
        }

        public bool GameOver(Player opponent, Player player)
        {
            List<KeyValuePair<int, int>> legalMovesOpponent = opponent.LegalMoves(this);

            if (legalMovesOpponent.Count <= 1)
                if (legalMovesOpponent.Count == 0 || legalMovesOpponent.Contains(new KeyValuePair<int, int>(player.Row, player.Column))
                    || legalMovesOpponent.Contains(new KeyValuePair<int, int>(opponent.Row, opponent.Column)))
                    return true;

            return false;
        }
    }
}
