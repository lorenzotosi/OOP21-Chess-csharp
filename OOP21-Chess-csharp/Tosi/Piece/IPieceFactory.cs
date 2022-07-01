using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Piece
{
    public interface IPieceFactory
    {
        IPiece CreatePiece(Name name, Position position, Side color);
    }
}