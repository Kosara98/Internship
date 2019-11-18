using System;
using System.Collections.Generic;

namespace Isola
{
    public class Board
    {
        public int Size { get; private set; }
        
        public Board(int size)
        {
            Size = size;
        }
    }
}
