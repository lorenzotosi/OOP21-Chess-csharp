using System.Collections.Generic;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.MarcoRaggini
{
    public interface IChessboard
    {
        public List<IPiece> PiecesList { get; }
        public int XBorder { get; }
        public int YBorder { get; }
        void Move(Position actualPos, Position finalPos);
        IPiece GetPieceOnPosition(Position selectedPos);
    }
}