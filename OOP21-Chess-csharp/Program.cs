using System;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var factory = new PieceFactory();
            var queen = factory.CreatePiece(Name.Queen, Position.CreateNewPosition("a1"), Side.Black);
            foreach (var position in queen.GetAllPossiblePositions)
            {
                Console.WriteLine(position);
            }
        }
    }
}