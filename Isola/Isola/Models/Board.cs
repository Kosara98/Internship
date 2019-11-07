using System;
using System.Collections.Generic;

namespace Isola
{
    public class Board
    {
        public int Size { get; set; }
        public int[,] BoardMatrix { get; set; }
        public List<KeyValuePair<int, int>> Eliminated;
        

        public Board()
        {
            Eliminated = new List<KeyValuePair<int, int>>();
            BoardMatrix = new int[Size, Size];
        }
    }
}
