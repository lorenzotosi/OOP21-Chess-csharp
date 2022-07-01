using System.Collections.Generic;

namespace OOP21_Chess_csharp.Utils
{
    public class Directions
    {
        public IEnumerable<Position> QueenDir()
        {
            var positions = new List<Position>
            {
                Position.CreateNumericPosition(+1, +1),
                Position.CreateNumericPosition(-1, -1),
                Position.CreateNumericPosition(+1, -1),
                Position.CreateNumericPosition(-1, +1),
                Position.CreateNumericPosition(+1, 0),
                Position.CreateNumericPosition(-1, 0),
                Position.CreateNumericPosition(0, +1),
                Position.CreateNumericPosition(0, -1)
            };
            return positions;
        }
        
        public IEnumerable<Position> KnightDir()
        {
            var positions = new List<Position>
            {
                Position.CreateNumericPosition(-1, -2),
                Position.CreateNumericPosition(+1, -2),
                Position.CreateNumericPosition(+2, -1),
                Position.CreateNumericPosition(+2, +1),
                Position.CreateNumericPosition(-1, +2),
                Position.CreateNumericPosition(+1, +2),
                Position.CreateNumericPosition(-2, -1),
                Position.CreateNumericPosition(-2, +1)
            };
            return positions;
        }
    }
}