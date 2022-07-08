using System;

namespace OOP21_Chess_csharp.Tosi.Utils
{
    public static class ChessNotations
    {
        public static char GetChessNotation(Name? pieceName)
        {
            return pieceName switch
            {
                Name.King => 'K',
                Name.Knight => 'N',
                Name.Queen => 'Q',
                Name.Rook => 'R',
                Name.Bishop => 'B',
                Name.Pawn => 'p',
                _ => throw new ArgumentOutOfRangeException(nameof(pieceName), pieceName, null)
            };
        }
    }
}