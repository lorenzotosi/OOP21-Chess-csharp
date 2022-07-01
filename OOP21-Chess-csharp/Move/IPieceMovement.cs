using System.Collections.Generic;
using OOP21_Chess_csharp.Piece;
using OOP21_Chess_csharp.Utils;

namespace OOP21_Chess_csharp.Move
{
    public interface IPieceMovement
    {
        List<Position> SingleMove(IEnumerable<Position> directions, IPiece piece);

        List<Position> MultipleMove(IEnumerable<Position> directions, IPiece piece);
    }
}