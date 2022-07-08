using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OOP21_Chess_csharp.AndreaZavatta;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_TestCsharp
{
    class ControlCheckTest
    {
        private readonly IPieceFactory _pieceFact = new PieceFactory();
        private readonly IChessboardFactory _chessboardFact = new ChessboardFactory();
        private readonly IControlCheck contr = new ControlCheck();

        [Test]
        public void IsInCheckTrue()
        {
            IChessboard chessboard = _chessboardFact.CreateTestCB(new List<IPiece>
            {
                _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("a2"), Side.White),
                _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("a5"), Side.Black)
            });
            Assert.True(contr.IsInCheck(chessboard, Side.White));
        }

        [Test]
        public void ableToMovePinOnKingFalse()
        {
            IPiece whiteKing = _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("a2"), Side.White);
            IPiece whiteBishop =_pieceFact.CreatePiece(Name.Bishop, Position.CreateNewPosition("a4"), Side.White);
            IPiece blackRook = _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("a5"), Side.Black);
            IChessboard chessboard = _chessboardFact.CreateTestCB(new List<IPiece>
            {
                whiteKing, whiteBishop, blackRook
            });
            Assert.AreEqual(contr.ControlledMoves(chessboard, whiteBishop).Count, 0);
        }

        [Test]
        public void ableToMoveOnlyToCoverCheckTrue()
        {
            IPiece whiteKing = _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("a2"), Side.White);
            IPiece whiteBishop = _pieceFact.CreatePiece(Name.Bishop, Position.CreateNewPosition("d6"), Side.White);
            IPiece blackRook = _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("a5"), Side.Black);
            IChessboard chessboard = _chessboardFact.CreateTestCB(new List<IPiece>
            {
                whiteKing, whiteBishop, blackRook
            });
            Assert.AreEqual(contr.ControlledMoves(chessboard, whiteBishop).Count, 1);
            Assert.AreEqual(contr.ControlledMoves(chessboard, whiteBishop).First(), Position.CreateNewPosition("a3"));
        }
        [Test]
        public void ableToMoveOnlyVertically()
        {
            IPiece whiteKing = _pieceFact.CreatePiece(Name.King, Position.CreateNewPosition("e1"), Side.White);
            IPiece whiteRook = _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("e3"), Side.White);
            IPiece blackRook = _pieceFact.CreatePiece(Name.Rook, Position.CreateNewPosition("e6"), Side.Black);
            IChessboard chessboard = _chessboardFact.CreateTestCB(new List<IPiece>
            {
                whiteKing, whiteRook, blackRook
            });
            List<Position> listResult = new List<Position>
            {
                Position.CreateNewPosition("e2"),
                Position.CreateNewPosition("e4"),
                Position.CreateNewPosition("e5"),
                Position.CreateNewPosition("e6")
            };
            Assert.AreEqual(contr.ControlledMoves(chessboard, whiteRook), listResult);
        }
    }
}
