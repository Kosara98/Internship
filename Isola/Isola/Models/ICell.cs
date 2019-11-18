using System.Collections.Generic;

namespace Isola
{
    public enum Status
    {
        Active,
        Inactive
    }

    public interface ICell
    {
        Status Status { get; set; }
        int PositionRow { get; set; }
        int PositionColumn { get; set; }
        KeyValuePair<int,int> NameTag { get; set; }
    }
}
