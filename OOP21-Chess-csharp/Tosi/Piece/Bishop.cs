using System.Collections.Generic;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Move;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Piece
{
    public class Bishop : AbstractPiece
    {
        private const int BishopValue = 3;
        
        protected internal Bishop(Position position, Side side) : base(Name.Bishop, position, side)
        {
        }

        public override List<Position> GetAllPossiblePositions(IChessboard chessboard) =>
            new PieceMovement().MultipleMove(Directions.BishopDir(), this, chessboard);

        public override int Value => BishopValue;
    }
}