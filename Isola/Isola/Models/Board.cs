using System;
using System.Collections.Generic;

namespace Isola
{
    public class Board
    {
        public int Size { get; set; }
        public int[,] BoardMatrix;
        public List<KeyValuePair<int, int>> Eliminated = new List<KeyValuePair<int,int>>();

        public Board()
        {
            BoardMatrix = new int[Size, Size];
        }
    }
}
