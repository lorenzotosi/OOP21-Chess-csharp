using NUnit.Framework;
using OOP21_Chess_csharp.Tosi.Piece;

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
            Assert.Pass();
        }
    }
}