using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.AndreaZavatta
{
    interface IControlCheck
    {
        List<Position> ControlledMoves(IChessboard chessboard, IPiece piece);
        bool IsInCheckWithoutKing(IChessboard chessboard, Side color);
        bool IsInCheck(IChessboard chessboard, Side color);
    }
}
