using System.Collections.Generic;

namespace Isola
{
    public class Player
    {
        public string Name { get; set; }
        public int Turn { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public List<KeyValuePair<int, int>> LeaglMoves(Board currentBoard)
        {
            List<KeyValuePair<int,int>> legalMoves = new List<KeyValuePair<int, int>>();
            List<KeyValuePair<int, int>> possibleMoves = new List<KeyValuePair<int, int>>();

            int minRow = Row - 1 >= 0 ? Row - 1 : Row;
            int maxRow = Row + 1 < currentBoard.Size ? Row + 1 : Row;
            int minColumn = Column - 1 >= 0 ? Column - 1 : Column;
            int maxColumn = Column + 1 < currentBoard.Size ? Column + 1 : Column;

            for (int i = minRow; i <= maxRow; i++)
                for (int j = minColumn; j <= maxColumn; j++)
                    if (i != Row || j != Column)
                        possibleMoves.Add(new KeyValuePair<int,int>(i, j));

            foreach (var item in possibleMoves)
                if (!currentBoard.Eliminated.Contains(item))
                        legalMoves.Add(item);

            return legalMoves;
        }
    }
}
