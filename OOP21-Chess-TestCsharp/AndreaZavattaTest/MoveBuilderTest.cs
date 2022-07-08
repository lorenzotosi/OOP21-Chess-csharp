using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OOP21_Chess_csharp.AndreaZavatta;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_TestCsharp
{
    class MoveBuilderTest
    {

        private IPieceFactory _pieceFactory = new PieceFactory();
        private IChessboardFactory _chessboardFactory = new ChessboardFactory();

        [Test]
        public void TestBishopMove()
        { 
            IMoveBuilder moveBuilder = new MoveBuilder();
            IList<IPiece> list = new List<IPiece>();
            list.Add(_pieceFactory.CreatePiece(Name.Bishop, Position.CreateNewPosition("d4"), Side.White));
            list.Add(_pieceFactory.CreatePiece(Name.Bishop, Position.CreateNewPosition("e5"), Side.Black));
            list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("b7"), Side.Black));
            list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("g2"), Side.White));
            IChessboard chessboard = _chessboardFactory.CreateTestCb(list);
            WrapException(moveBuilder
                .Piece(_pieceFactory.CreatePiece(Name.Bishop, Position.CreateNewPosition("d4"), Side.White))
                .Destination(Position.CreateNewPosition("f2")), chessboard);
            Assert.AreEqual("Bf2", moveBuilder.ToString());


        }
        [Test]
        public void TestAmbiguousMoveRow()
        {
            IMoveBuilder moveBuilder = new MoveBuilder();
            IList<IPiece> list = new List<IPiece>();
            list.Add(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("d4"), Side.White));
            list.Add(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("f4"), Side.White));
            list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("b7"), Side.Black));
            list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("g2"), Side.White));

            IChessboard chessboard = _chessboardFactory.CreateTestCb(list);
            WrapException(moveBuilder
                .Piece(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("d4"), Side.White))
                .Destination(Position.CreateNewPosition("e4")), chessboard);
            Assert.AreEqual("Rde4", moveBuilder.ToString());
        }

        [Test]
        public void TestAmbiguousMoveSameRowAndCol()
        {
            IMoveBuilder moveBuilder = new MoveBuilder();
            IList<IPiece> list = new List<IPiece>();
            list.Add(_pieceFactory.CreatePiece(Name.Queen, Position.CreateNewPosition("d6"), Side.White));
            list.Add(_pieceFactory.CreatePiece(Name.Queen, Position.CreateNewPosition("d4"), Side.White));
            list.Add(_pieceFactory.CreatePiece(Name.Queen, Position.CreateNewPosition("f4"), Side.White));
            list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("b7"), Side.Black));
            list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("g2"), Side.White));

            IChessboard chessboard = _chessboardFactory.CreateTestCb(list);
            WrapException(moveBuilder
                .Piece(_pieceFactory.CreatePiece(Name.Queen, Position.CreateNewPosition("d4"), Side.White))
                .Destination(Position.CreateNewPosition("e5")), chessboard);
            Assert.AreEqual("Qd4e5", moveBuilder.ToString());
        }

        private void WrapException(IMoveBuilder move, IChessboard chessboard)
        {
            try
            {
                move.Build(chessboard);
            }
            catch (IllegalMoveException e)
            {
                Assert.Fail();
            }
        }
    }
}
