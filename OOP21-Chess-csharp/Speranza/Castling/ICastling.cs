using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;

namespace OOP21_Chess_csharp.Speranza.Castling
{
    public interface ICastling
    {
        bool CanCastle(IChessboard chessboard, IPiece king, int xRook);
    }
}