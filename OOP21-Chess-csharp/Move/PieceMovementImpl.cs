using System.Collections.Generic;
using System.Linq;
using OOP21_Chess_csharp.Piece;
using OOP21_Chess_csharp.Utils;

namespace OOP21_Chess_csharp.Move
{
    public class PieceMovementImpl : IPieceMovement
    {
        public List<Position> SingleMove(IEnumerable<Position> directions, IPiece piece)
        {
            return directions.Select(pos => ControlUtils.GetNewPosition(piece, pos, 1))
                .Where(ControlUtils.CheckPositionOnBoard)
                .Where(p => !ControlUtils.CheckPieceOnPosition(p)
                || ControlUtils.CheckEnemyOnPosition(p))
                .ToList();
        }

        public List<Position> MultipleMove(IEnumerable<Position> directions, IPiece piece)
        {
            return directions.SelectMany(d => Enumerable.Range(1, 8)
                .TakeWhile(i => IsMovementValid(piece, i, d))
                .Select(i => ControlUtils.GetNewPosition(piece, d, i)))
                .ToList();
        }

        private bool IsMovementValid(IPiece piece, int lenght, Position position)
        { 
            var p = ControlUtils.GetNewPosition(piece, position, lenght);
            if (!ControlUtils.CheckPositionOnBoard(p))
            {
                return false;
            }
            var previousPosition = ControlUtils.GetNewPosition(piece, position, lenght - 1);
            if (ControlUtils.CheckEnemyOnPosition(previousPosition))
            {
                return false;
            }
            return !(ControlUtils.CheckPieceOnPosition(p) && !ControlUtils.CheckEnemyOnPosition(p));
        }
    }
}