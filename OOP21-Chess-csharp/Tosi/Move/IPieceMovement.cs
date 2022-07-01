using System.Collections.Generic;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Move
{
    public interface IPieceMovement
    {
        List<Position> SingleMove(IEnumerable<Position> directions, IPiece piece);

        List<Position> MultipleMove(IEnumerable<Position> directions, IPiece piece);
    }
}