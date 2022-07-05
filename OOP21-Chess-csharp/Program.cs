using System;
using System.Collections.Generic;
using OOP21_Chess_csharp.MarcoRaggini;
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
            var l = new List<IPiece>
            {
                factory.CreatePiece(Name.Knight, Position.CreateNewPosition("a2"), Side.White),
                factory.CreatePiece(Name.Knight, Position.CreateNewPosition("b2"), Side.White),
                factory.CreatePiece(Name.Knight, Position.CreateNewPosition("b1"), Side.Black)
            };
            var board = new Chessboard(l, 7, 7);
            var queen = factory.CreatePiece(Name.Queen, Position.CreateNewPosition("a1"), Side.Black);
            foreach (var position in queen.GetAllPossiblePositions(board))
            {
                Console.WriteLine(position);
            }
            Console.WriteLine(ControlUtils.CheckEnemyOnPosition(Position.CreateNewPosition("a3"), board, queen));
            Console.WriteLine(ControlUtils.CheckPieceOnPosition(Position.CreateNewPosition("a1"), board));
        }
    }
}