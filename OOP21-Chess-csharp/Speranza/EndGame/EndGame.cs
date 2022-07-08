using System.Collections.Generic;
using System.Linq;
using OOP21_Chess_csharp.AndreaZavatta;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Speranza.EndGame
{
    public class EndGame : IEndGame
    {
        private readonly IControlCheck _controls = new ControlCheck();
        public bool IsCheckmate(Chessboard chessboard, Side side)
        {
            var attackedColor = GetAttackedSide(chessboard, side);

            if (ControlCheck(chessboard, side, _controls))
            {
                foreach (var shield in attackedColor)
                {
                    if (CanShield(chessboard, _controls, shield))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool IsStalemate(IChessboard chessboard, Side side)
        {
            var attackedColor = GetAttackedSide(chessboard, side);

            foreach (var piece in attackedColor)
            {
                if (CanShield(chessboard, _controls, piece))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsDrawByInsufficientMaterial(IChessboard chessboard)
        {
            return CheckIfRemainingPiecesCauseStalemate(chessboard, Side.Black) && CheckIfRemainingPiecesCauseStalemate(chessboard, Side.White);   
        }

        public bool IsDraw(IChessboard chessboard, Side side)
        {
            return IsDrawByInsufficientMaterial(chessboard) || IsStalemate(chessboard, side);  
        }
        
        private List<IPiece> GetAttackedSide(IChessboard chessboard, Side side) {
            return chessboard.PiecesList.Where(x => x.Side.Equals(side)).ToList();
        }
        
        private bool CheckIfRemainingPiecesCauseStalemate(IChessboard chessboard, Side side)
        {
            List<IPiece> alive = chessboard.PiecesList.Where(x => x.Side == side).ToList();
            if (alive.Count > 2)
            {
                return false;
            }
            if (alive.Count == 1 && alive.First().Name == Name.King)
            {
                return true;
            }
            return alive.Any(x => x.Name == Name.Knight || x.Name == Name.Bishop);
        }
        
        private bool CanShield(IChessboard chessboard, IControlCheck controls, IPiece shield) {
            return !controls.ControlledMoves(chessboard, shield).Any();
        }
        private bool ControlCheck(IChessboard chessboard, Side side, IControlCheck controls) {
            return controls.IsInCheckWithoutKing(chessboard, side);
        }
    }
}