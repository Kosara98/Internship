using System;
using System.Collections.Generic;
using System.Linq;

namespace Isola
{
    public class AI : Player
    {
        private Board board;
        private Player opponent;
        private Random random = new Random();

        public KeyValuePair<int,int> MovePlayer(Board currentBoard, Player player)
        {
            opponent = player;
            board = currentBoard;

            List<KeyValuePair<int, int>> possibleMoves = LegalMoves(board);

            if (possibleMoves.Contains(new KeyValuePair<int, int>(opponent.Row, opponent.Column)))
                possibleMoves.Remove(new KeyValuePair<int, int>(opponent.Row, opponent.Column));
            
            KeyValuePair<int, int> result = MostWaysOut(possibleMoves);

            Row = result.Key;
            Column = result.Value;

            return result;
        }

        public KeyValuePair<int,int> EliminatedCell(Board board)
        {
            List<KeyValuePair<int, int>> freeCells = new List<KeyValuePair<int, int>>();
            List<KeyValuePair<int,int>> aiMoves = LegalMoves(board);
            List<KeyValuePair<int, int>> opponentMoves = opponent.LegalMoves(board);
            KeyValuePair<int, int> location = new KeyValuePair<int, int>(Row, Column);
            KeyValuePair<int, int> result = new KeyValuePair<int, int>();

            if (opponentMoves.Contains(new KeyValuePair<int, int>(Row, Column)))
            {
                if (aiMoves.Count == opponentMoves.Count && aiMoves.Count <= 4)
                    if (aiMoves.Count % 2 == 0)
                    {
                        for (int x = 0; x < board.Size; x++)
                            for (int y = 0; y < board.Size; y++)
                            {
                                KeyValuePair<int, int> cell = new KeyValuePair<int, int>(x, y);

                                if (board.Eliminated.Contains(cell) || aiMoves.Contains(cell) || opponentMoves.Contains(cell))
                                    break;
                                else
                                    freeCells.Add(cell);
                            }
                        int index = random.Next(freeCells.Count);
                        return freeCells[index];
                    }
                opponentMoves.Remove(new KeyValuePair<int, int>(Row, Column));
            }
                
            do
            {
                result = MostWaysOut(opponentMoves);
            } while (board.Eliminated.Contains(result));

            Row = location.Key;
            Column = location.Value;

            board.Eliminated.Add(result);
            return result;
        }

        private KeyValuePair<int, int> MostWaysOut(List<KeyValuePair<int,int>> possibleMoves)
        {
            List<KeyValuePair<int, int>> sameNumberOfWaysOut = new List<KeyValuePair<int, int>>();
            List<KeyValuePair<int, int>> futurePossibleMoves = new List<KeyValuePair<int, int>>();
            int mostWaysOut = 0;
            
            foreach (var item in possibleMoves)
            {
                Row = item.Key;
                Column = item.Value;
                futurePossibleMoves = LegalMoves(board);

                if (futurePossibleMoves.Contains(new KeyValuePair<int, int>(opponent.Row, opponent.Column)))
                    futurePossibleMoves.Remove(new KeyValuePair<int, int>(opponent.Row, opponent.Column));

                if (futurePossibleMoves.Count() >= mostWaysOut)
                {
                    if (mostWaysOut == futurePossibleMoves.Count())
                        sameNumberOfWaysOut.Add(new KeyValuePair<int, int>(Row,Column));
                    else
                    {
                        sameNumberOfWaysOut.Clear();
                        sameNumberOfWaysOut.Add(new KeyValuePair<int, int>(Row, Column));
                    }
                    mostWaysOut = futurePossibleMoves.Count();
                }
            }
            int index = random.Next(sameNumberOfWaysOut.Count());
            return sameNumberOfWaysOut[index];
        }
    }
}
