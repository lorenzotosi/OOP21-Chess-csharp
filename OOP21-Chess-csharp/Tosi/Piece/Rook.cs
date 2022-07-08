using System.Collections.Generic;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Move;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Piece
{
    public class Rook : AbstractPiece
    {
        private const int RookValue = 5;
        
        public Rook(Name name, Position position, Side side) : base(Name.Rook, position, side)
        {
        }

        public override List<Position> GetAllPossiblePositions(IChessboard chessboard) =>
            new PieceMovement().SingleMove(Directions.RookDir(), this, chessboard);

        public override int Value => RookValue;
    }
}