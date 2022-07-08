using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.AndreaZavatta
{
    public interface IFenBuilder
    {
        public IFenBuilder ActiveColor(Side side);
        public IFenBuilder BlackCastlingKingSide();
        public IFenBuilder BlackCastlingQueenSide();
        public IFenBuilder WhiteCastlingQueenSide();
        public IFenBuilder WhiteCastlingKingSide();
        public IFenBuilder EnPassant(string pos);
        public IFenBuilder HalfMoveClock(int halfMove);
        public IFenBuilder FullMoveNumber(int fullMove);
        public string Build(IChessboard chessboard);

    }
}
