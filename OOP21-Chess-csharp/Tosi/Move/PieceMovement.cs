using System.Collections.Generic;
using System.Linq;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Move
{
    public class PieceMovement : IPieceMovement
    {
        public List<Position> SingleMove(IEnumerable<Position> directions, IPiece piece, IChessboard chessboard)
        {
            return directions.Select(pos => ControlUtils.GetNewPosition(piece, pos, 1))
                .Where(ControlUtils.CheckPositionOnBoard)
                .Where(p => !ControlUtils.CheckPieceOnPosition(p, chessboard)
                || ControlUtils.CheckEnemyOnPosition(p, chessboard, piece))
                .ToList();
        }

        public List<Position> MultipleMove(IEnumerable<Position> directions, IPiece piece, IChessboard chessboard)
        {
            return directions.SelectMany(d => Enumerable.Range(1, 8)
                .TakeWhile(i => IsMovementValid(piece, i, d, chessboard))
                .Select(i => ControlUtils.GetNewPosition(piece, d, i)))
                .ToList();
        }

        private bool IsMovementValid(IPiece piece, int length, Position position, IChessboard chessboard)
        { 
            var p = ControlUtils.GetNewPosition(piece, position, length);
            if (!ControlUtils.CheckPositionOnBoard(p))
            {
                return false;
            }
            var previousPosition = ControlUtils.GetNewPosition(piece, position, length - 1);
            if (ControlUtils.CheckEnemyOnPosition(previousPosition, chessboard, piece))
            {
                return false;
            }
            return !(ControlUtils.CheckPieceOnPosition(p, chessboard) 
                     && !ControlUtils.CheckEnemyOnPosition(p, chessboard, piece));
        }
    }
}