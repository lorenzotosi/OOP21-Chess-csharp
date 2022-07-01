using OOP21_Chess_csharp.Piece;

namespace OOP21_Chess_csharp.Utils
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
            return position.X < 8 && position.X >= 0 && position.Y < 8 && position.Y >= 0;
        }

        public static bool CheckPieceOnPosition(Position position)
        {
            return false;
        }

        public static bool CheckEnemyOnPosition(Position position)
        {
            return false;
        }
        
    }
}