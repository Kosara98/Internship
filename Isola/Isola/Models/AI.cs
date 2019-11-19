using System;
using System.Collections.Generic;
using System.Linq;

namespace Isola
{
    public class AI : Player
    {
        private Player opponent;
        private Random random = new Random();
        private List<KeyValuePair<int, int>> opponentMoves;

        public void MovePlayer(Player player, ICell[,] matrix)
        {
            opponent = player;
            opponentMoves = opponent.LegalMoves(matrix);
            List<KeyValuePair<int, int>> possibleMoves = LegalMoves(matrix);
            
            if (opponentMoves.Count() == 1)
            {
                foreach (var item in opponentMoves)
                    if (possibleMoves.Contains(item))
                    {
                        Row = item.Key;
                        Column = item.Value;
                    }
            }
            else
            {
                KeyValuePair<int, int> result = MostWaysOut(possibleMoves, matrix);
                Row = result.Key;
                Column = result.Value;
            }
        }

        public KeyValuePair<int,int> EliminatedCell(ICell[,] matrix)
        {
            List<KeyValuePair<int, int>> freeCells = new List<KeyValuePair<int, int>>();
            List<KeyValuePair<int,int>> aiMoves = LegalMoves(matrix);
            KeyValuePair<int, int> result;
            KeyValuePair<int, int> location = new KeyValuePair<int, int>(Row, Column);
            opponentMoves = opponent.LegalMoves(matrix);

            if (opponentMoves.Contains(new KeyValuePair<int, int>(Row, Column)))
            {
                opponentMoves.Remove(new KeyValuePair<int, int>(Row, Column));
                
                if (opponentMoves.Count() == 1)
                    return opponentMoves[0];

                if (aiMoves.Count() == opponentMoves.Count() && aiMoves.Count() <= 4)
                    if (aiMoves.Count() % 2 == 0)
                    {
                        for (int x = 0; x < matrix.GetLength(0); x++)
                            for (int y = 0; y < matrix.GetLength(0); y++)
                            {
                                KeyValuePair<int, int> cell = new KeyValuePair<int, int>(x, y);

                                if (matrix[x,y].Status == Status.Inactive || aiMoves.Contains(cell) || opponentMoves.Contains(cell))
                                    break;
                                else
                                    freeCells.Add(cell);
                            }

                        if (freeCells.Count() != 0)
                        {
                            int index = random.Next(freeCells.Count());
                            return freeCells[index];
                        }
                    }
            }
            result = MostWaysOut(opponentMoves, matrix);
            Row = location.Key;
            Column = location.Value;
            return result;
        }

        private KeyValuePair<int, int> MostWaysOut(List<KeyValuePair<int,int>> possibleMoves, ICell[,] matrix)
        {
            List<KeyValuePair<int, int>> sameNumberOfWaysOut = new List<KeyValuePair<int, int>>();
            List<KeyValuePair<int, int>> futurePossibleMoves = new List<KeyValuePair<int, int>>();
            int mostWaysOut = 0;
            
            foreach (var item in possibleMoves)
            {
                Row = item.Key;
                Column = item.Value;
                futurePossibleMoves = LegalMoves(matrix);
                
                if (futurePossibleMoves.Count() >= mostWaysOut)
                {
                    if (mostWaysOut == futurePossibleMoves.Count())
                        sameNumberOfWaysOut.Add(item);
                    else
                    {
                        sameNumberOfWaysOut.Clear();
                        sameNumberOfWaysOut.Add(item);
                    }
                    mostWaysOut = futurePossibleMoves.Count();
                }
            }
            int index = random.Next(sameNumberOfWaysOut.Count());
            return sameNumberOfWaysOut[index];
        }
    }
}
