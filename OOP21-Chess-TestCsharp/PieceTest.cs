using System.Collections.Generic;
using NUnit.Framework;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_TestCsharp
{
    public class Tests
    {
        private readonly IPieceFactory _factory = new PieceFactory();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var l = new List<IPiece>
            {
                _factory.CreatePiece(Name.Knight, Position.CreateNewPosition("a2"), Side.White),
                _factory.CreatePiece(Name.Knight, Position.CreateNewPosition("b2"), Side.White),
                _factory.CreatePiece(Name.Knight, Position.CreateNewPosition("b1"), Side.Black)
            };
            var availablePositions = new List<Position>
            {
                Position.CreateNewPosition("b2"),
                Position.CreateNewPosition("a2")
            };
            var board = new Chessboard(l, 7, 7);
            var queen = _factory.CreatePiece(Name.Queen, Position.CreateNewPosition("a1"), Side.Black);
            Assert.AreEqual(queen.GetAllPossiblePositions(board), availablePositions);
        }
        
        [Test]
        public void Test2()
        {
            var l = new List<IPiece>
            {
                _factory.CreatePiece(Name.Knight, Position.CreateNewPosition("a2"), Side.White),
                _factory.CreatePiece(Name.Knight, Position.CreateNewPosition("b2"), Side.White),
                _factory.CreatePiece(Name.Knight, Position.CreateNewPosition("b1"), Side.White)
            };
            var availablePositions = new List<Position>
            {
                Position.CreateNewPosition("b2"),
                Position.CreateNewPosition("b1"),
                Position.CreateNewPosition("a2")
            };
            var board = new Chessboard(l, 7, 7);
            var queen = _factory.CreatePiece(Name.Queen, Position.CreateNewPosition("a1"), Side.Black);
            Assert.AreEqual(queen.GetAllPossiblePositions(board), availablePositions);
        }
        
        [Test]
        public void Test3()
        {
            var l = new List<IPiece>
            {
                _factory.CreatePiece(Name.Knight, Position.CreateNewPosition("a3"), Side.White),
                _factory.CreatePiece(Name.Knight, Position.CreateNewPosition("c3"), Side.White),
            };
            var availablePositions = new List<Position>
            {
                Position.CreateNewPosition("a3"),
                Position.CreateNewPosition("c3"),
                Position.CreateNewPosition("d2")
            };
            var board = new Chessboard(l, 7, 7);
            var knight = _factory.CreatePiece(Name.Knight, Position.CreateNewPosition("b1"), Side.Black);
            Assert.AreEqual(knight.GetAllPossiblePositions(board), availablePositions);
        }
    }
}