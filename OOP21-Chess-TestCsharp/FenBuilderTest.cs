using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OOP21_Chess_csharp.AndreaZavatta;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_TestCsharp
{
    class FenBuilderTest
    {
        private readonly IPieceFactory _pieceFact = new PieceFactory();
        private readonly IChessboardFactory _chessboardFact = new ChessboardFactory();
        private readonly IControlCheck contr = new ControlCheck();
        private readonly IFenBuilder fenBuilder = new FenBuilder();
        [Test]
        public void TestFirstPosition()
        {
            List<IPiece> list = new List<IPiece>
            {
                _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("a8"), Side.Black),
                _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("e8"), Side.Black),
                _pieceFact.CreatePiece(Name.Bishop, Position.CreateNewPosition("h8"), Side.Black),
                _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("a1"), Side.White),
                _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("d2"), Side.White)
            };

            IChessboard board = _chessboardFact.CreateTestCb(list);
            Assert.AreEqual("r3k2b/8/8/8/8/8/3K4/R7 w q - 0 1",
                fenBuilder.ActiveColor(Side.White)
                    .BlackCastlingKingSide()
                    .WhiteCastlingKingSide()
                    .WhiteCastlingQueenSide()
                    .Build(board));
        }
        [Test]
        public void TestSecondPosition()
        {
            List<IPiece> list = new List<IPiece>
            {
                _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("b5"), Side.Black),
                _pieceFact.CreatePiece(Name.Bishop, Position.CreateNewPosition("a2"), Side.Black),
                _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("f2"), Side.White),
                _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("h4"), Side.White)
            };
            IChessboard board = _chessboardFact.CreateTestCb(list);
            Assert.AreEqual("8/8/8/1k6/7R/8/b4K2/8 b - - 0 1",
                fenBuilder.ActiveColor(Side.Black)
                    .BlackCastlingKingSide()
                    .BlackCastlingQueenSide()
                    .WhiteCastlingKingSide()
                    .WhiteCastlingQueenSide()
                    .Build(board));
        }
        [Test]
        public void TestThirdPosition()
        {
            List<IPiece> list = new List<IPiece>
            {
                _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("b5"), Side.Black),
                _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("c8"), Side.White),
                _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("f2"), Side.White),
                _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("h4"), Side.Black)
            };
            IChessboard board = _chessboardFact.CreateTestCb(list);
            Assert.AreEqual("2R5/8/8/1k6/7r/8/5K2/8 w - - 0 1",
                fenBuilder.ActiveColor(Side.White)
                    .BlackCastlingKingSide()
                    .BlackCastlingQueenSide()
                    .WhiteCastlingKingSide()
                    .WhiteCastlingQueenSide()
                    .Build(board));
        }
    }
}
