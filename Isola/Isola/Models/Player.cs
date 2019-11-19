using System.Collections.Generic;

namespace Isola
{
    public class Player
    {
        public string Name { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public List<KeyValuePair<int, int>> LegalMoves(ICell[,] matrix)
        {
            List<KeyValuePair<int, int>> legalMoves = new List<KeyValuePair<int, int>>();
            int minRow = Row - 1 >= 0 ? Row - 1 : Row;
            int maxRow = Row + 1 < matrix.GetLength(0) ? Row + 1 : Row;
            int minColumn = Column - 1 >= 0 ? Column - 1 : Column;
            int maxColumn = Column + 1 < matrix.GetLength(0) ? Column + 1 : Column;

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
