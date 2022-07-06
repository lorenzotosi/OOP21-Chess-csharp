using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;

namespace OOP21_Chess_csharp.Tosi.Utils
{
    public static class ControlUtils
    {
        public static Position GetNewPosition(IPiece piece, Position direction, int multiplier) 
        {
            return Position.CreateNumericPosition(piece.Position.X + (direction.X * multiplier),
                piece.Position.Y + (direction.Y * multiplier));
        }
        
        public static bool CheckPositionOnBoard(Position position) 
        {
            return position.X is < 8 and >= 0 && position.Y is < 8 and >= 0;
        }

        public static bool CheckPieceOnPosition(Position position, IChessboard chessboard)
        {
            return chessboard.PiecesList.Select(x => x.Position).Contains(position);
        }

        public static bool CheckEnemyOnPosition(Position position, IChessboard chessboard, IPiece piece)
        {
            return CheckPieceOnPosition(position, chessboard) &&
                   !chessboard.GetPieceOnPosition(position).Side.Equals(piece.Side);
        }

    }
}