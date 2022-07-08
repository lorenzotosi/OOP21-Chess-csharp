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
        private IMoveBuilder _moveBuilder = new MoveBuilder();
        private IPieceFactory _pieceFactory = new PieceFactory();
        private IChessboardFactory _chessboardFactory = new ChessboardFactory();
        private IChessboard _chessboard;
        private static IList<IPiece> _list = new List<IPiece>();
        [Test]
        public void TestBishopMove()
        {
            _list.Add(_pieceFactory.CreatePiece(Name.Bishop, Position.CreateNewPosition("d4"), Side.White));
            _list.Add(_pieceFactory.CreatePiece(Name.Bishop, Position.CreateNewPosition("e5"), Side.Black));
            _list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("b7"), Side.Black));
            _list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("g2"), Side.White));
            _chessboard = _chessboardFactory.CreateTestCb(_list);
            WrapException(_moveBuilder
                .Piece(_pieceFactory.CreatePiece(Name.Bishop, Position.CreateNewPosition("d4"), Side.White))
                .Destination(Position.CreateNewPosition("f2")));
            Assert.AreEqual("Bf2", _moveBuilder.ToString());


        }
        [Test]
        public void TestAmbiguousMoveRow()
        {
            _list.Add(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("d4"), Side.White));
            _list.Add(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("f4"), Side.White));
            _list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("b7"), Side.Black));
            _list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("g2"), Side.White));

            _chessboard = _chessboardFactory.CreateTestCb(_list);
            WrapException(_moveBuilder
                .Piece(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("d4"), Side.White))
                .Destination(Position.CreateNewPosition("e4")));
            Assert.AreEqual("Rde4", _moveBuilder.ToString());
        }

        [Test]
        public void TestAmbiguousMoveSameRowAndCol()
        {
            _list.Add(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("d4"), Side.White));
            _list.Add(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("f4"), Side.White));
            _list.Add(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("d5"), Side.White));
            _list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("b7"), Side.Black));
            _list.Add(_pieceFactory.CreatePiece(Name.King, Position.CreateNewPosition("g2"), Side.White));

            _chessboard = _chessboardFactory.CreateTestCb(_list);
            WrapException(_moveBuilder
                .Piece(_pieceFactory.CreatePiece(Name.Rook, Position.CreateNewPosition("d4"), Side.White))
                .Destination(Position.CreateNewPosition("e4")));
            Assert.AreEqual("Rd4e4", _moveBuilder.ToString());
        }

        private void WrapException(IMoveBuilder move)
        {
            try
            {
                move.Build(_chessboard);
            }
            catch (IllegalMoveException e)
            {
                Assert.Fail();
            }
        }
    }
}
