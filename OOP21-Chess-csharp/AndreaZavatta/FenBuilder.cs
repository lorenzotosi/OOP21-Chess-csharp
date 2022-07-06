using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.AndreaZavatta
{
    class FenBuilder : IFenBuilder
    {
        private Side _side;
        private bool _blackCastlingQueenSide = true;
        private bool _blackCastlingKingSide = true;
        private bool _whiteCastlingQueenSide = true;
        private bool _whiteCastlingKingSide = true;
        private string _enPassant = "-";
        private int _halfMoveClock;
        private int _fullMoveNumber = 1;

        public IFenBuilder ActiveColor(Side side)
        {
            this._side = side;
            return this;
        }

        public IFenBuilder BlackCastlingKingSide()
        {
            _blackCastlingKingSide = false;
            return this;
        }

        public IFenBuilder BlackCastlingQueenSide()
        {
            _blackCastlingQueenSide = false;
            return this;
        }

        public IFenBuilder WhiteCastlingQueenSide()
        {
            _whiteCastlingQueenSide = false;
            return this;
        }

        public IFenBuilder WhiteCastlingKingSide()
        {
            _whiteCastlingKingSide = false;
            return this;
        }

        public IFenBuilder EnPassant(string pos)
        {
            _enPassant = pos;
            return this;
        }

        public IFenBuilder HalfMoveClock(int halfMove)
        {
            _halfMoveClock = halfMove;
            return this;
        }

        public IFenBuilder FullMoveNumber(int fullMove)
        {
            _fullMoveNumber = fullMove;
            return this;
        }

        private string FromRowToString(int row, IChessboard chessboard)
        {
            StringBuilder res = new StringBuilder();
            IList<IPiece> rowPiece = GetPiecesByRow(row, chessboard);
            int previousPiece = 0;
            foreach (IPiece piece in rowPiece)
            {
                res.Append(DiffPosX(previousPiece, piece));
                res.Append(GetNotation(piece));
                previousPiece = piece.Position.X + 1;
            }
            if (previousPiece < chessboard.XBorder + 1)
            {
                res.Append(chessboard.XBorder + 1 - previousPiece);
            }

            return res.ToString();
        }

        private String GetNotation(IPiece piece)
        {
            return ChessNotations.GetChessNotation(piece.Name);
        }

        private string DiffPosX(int previousPiece, IPiece piece)
        {
            int diff = piece.Position.X - previousPiece;
            return diff > 0 ? diff.ToString() : "";
        }
        private IList<IPiece> GetPiecesByRow(int row, IChessboard chessboard)
        {
            return chessboard.PiecesList.Where(x => x.Position.Y == row)
                .OrderBy(x => x.Position.X)
                .ToList();
        }

        private string FenPiece(IChessboard chessboard)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < chessboard.YBorder + 1; i++)
            {
                str.Append(FromRowToString(i, chessboard));
                str.Append('/');
            }
            str.Remove(str.Length - 1, 1);
            return str.ToString();
        }
        private char GetActiveColor()
        {
            return _side == Side.Black ? 'b' : 'w';
        }
        private string GetCastling()
        {
            if (!_blackCastlingQueenSide && !_blackCastlingKingSide && !_whiteCastlingQueenSide && !_whiteCastlingKingSide)
            {
                return "-";
            }
            return GetCastlingSupport();
        }
        private string GetCastlingSupport()
        {
            return (_whiteCastlingKingSide ? ChessNotations.GetChessNotation(Name.King) : "") + 
                   (_whiteCastlingQueenSide ? ChessNotations.GetChessNotation(Name.Queen) : "") + 
                   (_blackCastlingKingSide ? ChessNotations.GetChessNotation(Name.Queen).ToLowerInvariant() : "") + 
                   (_blackCastlingQueenSide ? ChessNotations.GetChessNotation(Name.Queen).ToLowerInvariant() : "");
        }

        public string Build(Chessboard chessboard)
        {
            return $"{FenPiece(chessboard)} {GetActiveColor()} {GetCastling()} {_enPassant} {_halfMoveClock} {_fullMoveNumber}";
        }
    }
}
