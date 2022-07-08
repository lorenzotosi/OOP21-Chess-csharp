using OOP21_Chess_csharp.Tosi.Piece;
using System.Collections.Generic;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.MarcoRaggini
{
    public class ChessboardFactory : IChessboardFactory
    {
        public IChessboard CreateNormalCb()
        {
            var pieces = CreateKnight(0, Side.Black);
            pieces.AddRange(CreateKnight(7,Side.White));
            return new Chessboard(pieces, 7, 7);
        }

        public IChessboard CreateTestCb(List<IPiece> piecesList)
        {
            return new Chessboard(CreateCopyOf(piecesList), 7, 7);
        }

        private List<IPiece> CreateKnight(int row, Side color)
        {
            IPieceFactory pieceCreator = new PieceFactory();
            var pieces = new List<IPiece>();
            for (var i = 0; i < 8; i++)
            {
                pieces.Add(pieceCreator.CreatePiece(Name.Knight, Position.CreateNumericPosition(i, row), color));
            }
            return pieces;
        }

        private List<IPiece> CreateCopyOf(List<IPiece> originalList)
        {
            var copy = new List<IPiece>();
            var pieceFct = new PieceFactory();
            originalList.ForEach(p => copy.Add(pieceFct.CreatePiece(p.Name, p.Position, p.Side)));
            return copy;
        }
    }
}
