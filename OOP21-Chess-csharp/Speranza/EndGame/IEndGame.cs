using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Speranza.EndGame
{
    public interface IEndGame
    {
        bool IsCheckmate(Chessboard chessboard, Side side);

        bool IsStalemate(IChessboard chessboard, Side side);

        bool IsDrawByInsufficientMaterial(IChessboard chessboard);

        bool IsDraw(IChessboard chessboard, Side side);
    }
}