using System;
using System.Collections.Generic;
using System.Linq;

namespace Isola
{
    public class AI : Player
    {
        private Board board;
        private Player opponent;
        
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

        public KeyValuePair<int,int> EliminatedCell(Board board, Player player)
        {
            KeyValuePair<int, int> location = new KeyValuePair<int, int>(Row, Column);
            List<KeyValuePair<int, int>> opponentMoves = opponent.LegalMoves(board);
            KeyValuePair<int, int> result = new KeyValuePair<int, int>();

            if (opponentMoves.Contains(new KeyValuePair<int, int>(Row, Column)))
                opponentMoves.Remove(new KeyValuePair<int, int>(Row, Column));

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
            List<KeyValuePair<int, int>> futurePossibleMoves = new List<KeyValuePair<int, int>>();
            KeyValuePair<int, int> result = new KeyValuePair<int, int>();
            int mostWaysOut = 0;
            
            foreach (var item in possibleMoves)
            {
                Row = item.Key;
                Column = item.Value;
                futurePossibleMoves = LegalMoves(board);

                if (futurePossibleMoves.Contains(new KeyValuePair<int, int>(opponent.Row, opponent.Column)))
                    futurePossibleMoves.Remove(new KeyValuePair<int, int>(opponent.Row, opponent.Column));

                if (futurePossibleMoves.Count() > mostWaysOut)
                {
                    mostWaysOut = futurePossibleMoves.Count();
                    result = new KeyValuePair<int, int>(Row, Column);
                }
            }
            return result;
        }
    }
}
