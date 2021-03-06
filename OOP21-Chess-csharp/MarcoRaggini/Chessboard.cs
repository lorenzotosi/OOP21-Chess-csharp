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
            PiecesList = piecesList;
            XBorder = xborder;
            YBorder = yborder;
        }

        public void Move(Position actualPos, Position finalPos)
        {
            var attacker = (GetPieceOnPosition(actualPos));
            MoveWithoutChecks(attacker, finalPos);
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
        
        public override bool Equals(object obj)
        {
            return obj is Chessboard cb &&
                   XBorder == cb.XBorder &&
                   YBorder == cb.YBorder &&
                   PiecesList == cb.PiecesList;
        }

        public override int GetHashCode()
        {
            var hashCode = -1530612366;
            hashCode = hashCode * -1521134295 + XBorder.GetHashCode();
            hashCode = hashCode * -1521134295 + YBorder.GetHashCode();
            hashCode = hashCode * -1521134295 + PiecesList.GetHashCode();
            return hashCode;
        }

        public void MoveWithoutChecks(IPiece piece, Position destPos)
        {
            if (CanKill(destPos))
            {
                PiecesList.Remove(GetPieceOnPosition(destPos));
            }
            piece?.SetPosition(destPos);
        }
    }
}