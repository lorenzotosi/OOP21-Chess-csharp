using NUnit.Framework;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_TestCsharp.MarcoRagginiTest
{
    public class ChessboardTest
    {
        private readonly IChessboardFactory _cbFactory = new ChessboardFactory();
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TryMove()
        {
            IChessboard chessboard = _cbFactory.CreateNormalCb();
            chessboard.Move(Position.CreateNewPosition("a1")
                        , Position.CreateNewPosition("a3"));
            Assert.True(chessboard.GetPieceOnPosition(Position.CreateNewPosition("a1"))is null);
            Assert.True(chessboard.GetPieceOnPosition(Position.CreateNewPosition("a3"))is not null);
        }

        [Test]
        public void TryCanKill()
        {
            IChessboard chessboard = _cbFactory.CreateNormalCb();
            Assert.True(chessboard.GetPieceOnPosition(Position.CreateNewPosition("a8"))
                                    ?.Side
                                    .Equals(Side.Black));
            
            chessboard.Move(Position.CreateNewPosition("a1"), 
                            Position.CreateNewPosition("a8"));
            
            Assert.True(chessboard.GetPieceOnPosition(Position.CreateNewPosition("a8"))
                                    ?.Side
                                    .Equals(Side.White));
        }
    }
}