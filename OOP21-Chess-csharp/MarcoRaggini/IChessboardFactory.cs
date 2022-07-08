using OOP21_Chess_csharp.Tosi.Piece;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_Chess_csharp.MarcoRaggini
{
    public interface IChessboardFactory
    {
        IChessboard CreateNormalCb();
        IChessboard CreateTestCb(List<IPiece> piecesList);
    }
}
