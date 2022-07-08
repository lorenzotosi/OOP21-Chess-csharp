using OOP21_Chess_csharp.Tosi.Piece;
using System.Collections.Generic;

namespace OOP21_Chess_csharp.MarcoRaggini
{
    public interface IChessboardFactory
    {
        IChessboard CreateNormalCb();
        IChessboard CreateTestCb(IList<IPiece> piecesList);
    }
}
