using System.Collections.Generic;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Move;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Piece
{
    public class Queen : AbstractPiece
    {
        private const int QueenValue = 9;

        protected internal Queen(Position position, Side side) : base(Name.Queen, position: position, side: side)
        {
        }

        public override List<Position> GetAllPossiblePositions(IChessboard chessboard) => new PieceMovement()
            .MultipleMove(Directions.QueenDir(), this, chessboard);

        public override int Value => QueenValue;
    }

}
