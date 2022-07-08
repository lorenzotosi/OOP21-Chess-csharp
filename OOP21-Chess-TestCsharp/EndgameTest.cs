using System.Collections.Generic;
using NUnit.Framework;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Speranza.EndGame;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_TestCsharp
{
    public class EndgameTest
    {
        private readonly IPieceFactory _factory = new PieceFactory();
        private readonly IEndGame _endGame = new EndGame();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var l = new List<IPiece>
            {

            };
            var king = _factory.CreatePiece(Name.King, Position.CreateNewPosition("h8"), Side.Black);
            var rook = _factory.CreatePiece(Name.Rook, Position.CreateNewPosition("g1"), Side.White);
            var queen = _factory.CreatePiece(Name.Queen, Position.CreateNewPosition("h6"), Side.White);

            l.Add(king);
            l.Add(rook);
            l.Add(queen);
            var board = new Chessboard(l, 7, 7);

            Assert.True(_endGame.IsCheckmate(board, king.Side));
        }
        
        [Test]
        public void Test2()
        {
            var l = new List<IPiece>
            {

            };
            var king = _factory.CreatePiece(Name.King, Position.CreateNewPosition("a8"), Side.Black);
            var queen = _factory.CreatePiece(Name.Queen, Position.CreateNewPosition("c7"), Side.White);

            l.Add(king);
            l.Add(queen);
            var board = new Chessboard(l, 7, 7);

            Assert.True(_endGame.IsStalemate(board, king.Side));
        }
    }
}