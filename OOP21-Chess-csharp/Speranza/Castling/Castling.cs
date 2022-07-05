using System;
using System.Collections.Generic;
using System.Linq;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Speranza.Castling
{
    public class Castling : ICastling
    {
        public bool CanCastle(IChessboard chessboard, IPiece king, int xRook)
        {
            /* return chessboard.GetPieceOnPosition(Position.CreateNumericPosition(xRook, king.Position.Y)
                .Select(r => IsCastlePossible(chessboard, king, r))
                .DefaultIfEmpty(false)
                .First(); */
            return true;
        }
        
        private bool IsPositionUnderAttack(IChessboard chessboard, Position position, Side attackedSide)
        {
            return chessboard.PiecesList.Where(x => !x.Side.Equals(attackedSide))
                .Where(x => !x.Name.Equals(Name.King))
                .Any(p => p.GetAllPossiblePositions(chessboard).Contains(position));
        }
        
        private bool IsCastlePossible(IChessboard chessboard, IPiece king, IPiece rook)
        {
            // we're working with the correct pieces;
            if (!king.Name.Equals(Name.King) || !rook.Name.Equals(Name.Rook))
            {
                return false;
            }
            // the pieces must not have been moved;
            if (king.IsMoved() || rook.IsMoved())
            {
                return false;
            }
            if (KingInCheck.isInCheckWithoutKing(chessboard, king.Side))
            {
                return false;
            }

            var positions = HorizontalPositionsBetweenPieces(rook, king);

            // the list must contain only non-occupied positions;
            if (positions.Any(p => chessboard.PiecesList.Select(x => x.Position).Contains(p)))
            {
                return false;
            }
            
            // filter the previous list and get the positions the king has to go through.
            return positions.Where(p => Math.Abs(king.Position.X - p.X) <= 2)
                .All(p => !IsPositionUnderAttack(chessboard, p, king.Side));
        }
        private List<Position> HorizontalPositionsBetweenPieces(IPiece piece1, IPiece piece2)
        {
            var y = piece1.Position.Y;
            var x1 = piece1.Position.X;
            var x2 = piece2.Position.X;
            int maxX, minX;

            if (x1 > x2)
            {
                maxX = x1;
                minX = x2;
            }
            else
            {
                minX = x1;
                maxX = x2;
            }
            return Enumerable.Range(minX + 1, maxX)
                .Select(x => Position.CreateNumericPosition(x, y))
                .ToList();
        }
    }
}