using System;
using System.Collections.Generic;
using System.Linq;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.MarcoRaggini
{
    public class Chessboard:IChessboard
    {
        public List<IPiece> PiecesList { get; }
        public int XBorder { get; }
        public int YBorder { get; }

        public Chessboard(List<IPiece> piecesList, int xborder, int yborder)
        {
            this.PiecesList = piecesList;
            this.XBorder = xborder;
            this.YBorder = yborder;
        }

        public void Move(Position actualPos, Position finalPos)
        {
            var attacker = (GetPieceOnPosition(actualPos));
            if (CanKill(finalPos))
            {
                PiecesList.Remove(GetPieceOnPosition(finalPos));
            }
            attacker?.SetPosition(finalPos);
        }
        public IPiece GetPieceOnPosition(Position selectedPos)
        {
            return PiecesList.FirstOrDefault(t => t.Position.Equals(selectedPos));
        }

        private bool CanKill(Position targetPos)
        {
            return GetPieceOnPosition(targetPos) is not null;
        }

        public override string ToString()
        {
            return $"Chessboard = {PiecesList.Select(x => x.ToString())}";
        }
    }
}