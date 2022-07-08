using System;
using System.Collections.Generic;
using System.Linq;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.AndreaZavatta
{
    public class ControlCheck : IControlCheck
    {
        private readonly IChessboardFactory _chessboardFact = new ChessboardFactory();
        public List<Position> ControlledMoves(IChessboard chessboard, IPiece piece)
        {
            List<Position> availableMoves = new List<Position>(piece.GetAllPossiblePositions(chessboard));
            availableMoves.RemoveAll(x => IsMoveInCheck(chessboard, piece, x));
            return availableMoves;
        }
        private bool IsMoveInCheck(IChessboard chessboard, IPiece piece, Position pos)
        {
            return IsInCheck(SimulateMove(chessboard, piece, pos), piece.Side);
        }
        private IChessboard SimulateMove(IChessboard chessboard, IPiece piece, Position destPos)
        {
            IChessboard chessboardCopy = CopyChessboard(chessboard);
            MoveIfPresent(piece, destPos, (Chessboard)chessboardCopy);
            return chessboardCopy;
        }
        private void MoveIfPresent(IPiece piece, Position destPos, Chessboard chessboardCopy)
        {
            IPiece pieceToMove = chessboardCopy.PiecesList.FirstOrDefault(x => x.Position.Equals(piece.Position));
            if (pieceToMove != null)
            {
                chessboardCopy.MoveWithoutChecks(pieceToMove, destPos);
            }
        }
        private IChessboard CopyChessboard(IChessboard chessboard)
        {
            return _chessboardFact.CreateTestCb(chessboard.PiecesList);
        }
        private bool IsInCheckSupport(IChessboard chessboard, Side color, Func<IPiece, bool> func)
        {
            return chessboard.PiecesList.Where(IsOppositeColor(color))
                .Where(func)
                .Any(x => CanEatKing(chessboard, x));
        }
        private Func<IPiece, bool> IsOppositeColor(Side color)
        {
            return x => !x.Side.Equals(color);
        }

        public bool IsInCheckWithoutKing(IChessboard chessboard, Side color)
        {
            return IsInCheckSupport(chessboard, color, x => !IsPieceKing(x));
        }

        public bool IsInCheck(IChessboard chessboard, Side color)
        {
            return IsInCheckSupport(chessboard, color, x => true);
        }

        private bool CanEatKing(IChessboard chessboard, IPiece piece)
        {
            return piece.GetAllPossiblePositions(chessboard)
                .Contains(GetEnemyKingPosition(chessboard, piece));
        }

        private Position GetEnemyKingPosition(IChessboard chessboard, IPiece piece)
        {
            return chessboard.PiecesList
                .Where(IsPieceOppositeColor(piece))
                .Where(IsPieceKing)
                .FirstOrDefault()
                ?.Position;
        }
        private Func<IPiece, bool> IsPieceOppositeColor(IPiece piece)
        {
            return x => !x.Side.Equals(piece.Side);
        }
        private bool IsPieceKing(IPiece piece)
        {
            return piece.Name == Name.King;
        }
    }
}
