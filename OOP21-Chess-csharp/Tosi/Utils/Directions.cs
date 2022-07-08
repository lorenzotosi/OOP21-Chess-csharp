using System.Collections.Generic;
using System.Linq;

namespace OOP21_Chess_csharp.Tosi.Utils
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

        public IEnumerable<Position> KingDir()
        {
            return RookDir().Concat(BishopDir());
        }
        
        public IEnumerable<Position> RookDir()
        {
           var positions = new List<Position>()
            {
                Position.CreateNumericPosition(+1, 0),
                Position.CreateNumericPosition(-1, 0),
                Position.CreateNumericPosition(0, +1),
                Position.CreateNumericPosition(0, -1)
            };
            return positions;
        }
        
        public IEnumerable<Position> BishopDir()
        {
           var positions = new List<Position>()
            {
                Position.CreateNumericPosition(+1, +1),
                Position.CreateNumericPosition(-1, -1),
                Position.CreateNumericPosition(+1, -1),
                Position.CreateNumericPosition(-1, +1)
            };
           return positions;
        }
    }
}