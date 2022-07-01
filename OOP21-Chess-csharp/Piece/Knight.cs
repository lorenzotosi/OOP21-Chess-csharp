using System.Collections.Generic;
using OOP21_Chess_csharp.Move;
using OOP21_Chess_csharp.Utils;

namespace OOP21_Chess_csharp.Piece
{
    public class Knight : AbstractPiece
    {
        private const int KnightValue = 3;
        
        public Knight(Position position, Side side) : base(Name.Knight, position, side)
        {
        }

        public override List<Position> GetAllPossiblePositions =>
            new PieceMovementImpl().SingleMove(Directions.KnightDir(), this);
        
        public override int Value => KnightValue;
    }
}