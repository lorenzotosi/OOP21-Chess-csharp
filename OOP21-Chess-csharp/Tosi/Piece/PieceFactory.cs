using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Piece
{
    public class PieceFactory : IPieceFactory
    {
        public IPiece CreatePiece(Name name, Position position, Side color)
        {
            return name switch
            {
                Name.Queen => new Queen(position, color),
                Name.Knight => new Knight(position, color),
                _ => null
            };
        }
    }
}