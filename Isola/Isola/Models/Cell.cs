using System.Collections.Generic;
using System.Windows.Forms;

namespace Isola
{
    public class Cell : Button, ICell
    {
        public Status Status { get; set; }
        public int PositionRow { get; set; }
        public int PositionColumn { get; set; }
        public KeyValuePair<int, int> NameTag { get; set; }
    }
}
