using System.Collections.Generic;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Speranza.Castling;
using OOP21_Chess_csharp.Tosi.Move;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Piece
{
    public class King : AbstractPiece
    {
        private const int KingValue = 0;
        private readonly ICastling _castle = new Castling();
        
        protected internal King(Position position, Side side) : base(Name.King, position, side)
        {
        }

        public override List<Position> GetAllPossiblePositions(IChessboard chessboard)
        {
            var positions = new PieceMovement().SingleMove(Directions.KingDir(), this, chessboard);
            if (_castle.CanCastle(chessboard, this, 0)) {
                positions.Add(CastleKingPosition(-2));
            }
            if (_castle.CanCastle(chessboard, this, 7)) {
                positions.Add(CastleKingPosition(2));
            }

            return positions;
        }

        public override int Value => KingValue;
        
        private Position CastleKingPosition(int direction) {
            return Position.CreateNumericPosition(this.Position.X + direction, this.Position.Y);
        }
    }
}