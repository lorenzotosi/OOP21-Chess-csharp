using System.Collections.Generic;
using NUnit.Framework;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Speranza.Castling;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_TestCsharp
{
    public class CastlingTest
    {
        private readonly IPieceFactory _factory = new PieceFactory();
        private readonly ICastling _castling = new Castling();
        
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
            var king = _factory.CreatePiece(Name.King, Position.CreateNewPosition("e1"), Side.White);
            var rook = _factory.CreatePiece(Name.Rook, Position.CreateNewPosition("h1"), Side.White);
            var bishop = _factory.CreatePiece(Name.Bishop, Position.CreateNewPosition("c4"), Side.Black);
   
            l.Add(king);
            l.Add(rook);
            l.Add(bishop);
            var board = new Chessboard(l, 7, 7);
            
           Assert.True(_castling.CanCastle(board, king, rook.Position.X)); 
        }
    }
}