using System.Collections.Generic;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Move;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Piece
{
    public class Knight : AbstractPiece
    {
        private const int KnightValue = 3;
        
        protected internal Knight(Position position, Side side) : base(Name.Knight, position, side)
        {
        }

        public override List<Position> GetAllPossiblePositions(IChessboard chessboard) =>
            new PieceMovement().SingleMove(Directions.KnightDir(), this, chessboard);
        
        public override int Value => KnightValue;
    }
}