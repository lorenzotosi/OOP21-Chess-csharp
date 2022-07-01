using System.Collections.Generic;
using OOP21_Chess_csharp.Move;
using OOP21_Chess_csharp.Utils;

namespace OOP21_Chess_csharp.Piece
{
    public class Queen : AbstractPiece
    {
        private const int QueenValue = 9;
        protected Queen(Position position, Side side) : base(Name.Queen, position: position, side: side)
        {
        }

        public override List<Position> GetAllPossiblePositions => new PieceMovementImpl()
            .MultipleMove(Directions.QueenDir(), this);

        public override int Value => QueenValue;
    }
}
