using System.Collections.Generic;
using System.Data.SqlTypes;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Piece
{
    public interface IPiece 
    {
        Name Name { get; }

        void SetPosition(Position position);

        Side Side { get; }

        int Value { get; }

        bool IsMoved();

        Position Position { get; }

        List<Position> GetAllPossiblePositions(IChessboard chessboard);
    }
}
