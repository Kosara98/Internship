using System.Collections.Generic;

namespace Isola
{
    public class Player
    {
        public string Name { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public List<KeyValuePair<int, int>> LegalMoves(Board board, ICell[,] matrix)
        {
            List<KeyValuePair<int, int>> legalMoves = new List<KeyValuePair<int, int>>();
            //KeyValuePair<int, int> opponentLocation = Row == board.PlayerOneLocation.Key && Column == board.PlayerOneLocation.Value ?
            //    board.PlayerOneLocation : board.PlayerTwoLocation;

            int minRow = Row - 1 >= 0 ? Row - 1 : Row;
            int maxRow = Row + 1 < board.Size ? Row + 1 : Row;
            int minColumn = Column - 1 >= 0 ? Column - 1 : Column;
            int maxColumn = Column + 1 < board.Size ? Column + 1 : Column;

            for (int row = minRow; row <= maxRow; row++)
                for (int column = minColumn; column <= maxColumn; column++)
                    if (row != Row || column != Column)
                    {
                        KeyValuePair<int, int> cell = new KeyValuePair<int, int>(row, column);
                        if (matrix[row,column].Status == Status.Active)
                            legalMoves.Add(cell);
                    }

            return legalMoves;
        }
    }
}
