namespace OOP21_Chess_csharp.Tosi.Utils
{
    public class ChessNotations
    {
        public string GetChessNotation(Name pieceName)
        {
            return pieceName switch
            {
                Name.King => "K",
                Name.Knight => "N",
                Name.Queen => "Q",
                Name.Rook => "R",
                _ => null
            };
        }
    }
}