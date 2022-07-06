using System;
using System.Collections.Generic;
using System.Linq;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Piece;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.AndreaZavatta
{
    class MoveBuilder : IMoveBuilder
    {
        private readonly IControlCheck _controls = new ControlCheck();
        private IPiece _piece;
        private Position _destination;
        private Name? _promotion;
        private bool _drawOffer;
        private bool _check;
        private bool _checkmate;
        private bool _capture;
        private bool _kingSideCastling;
        private bool _queenSideCastling;
        private bool _column;
        private bool _row;
        public IMoveBuilder Piece(IPiece piece)
        {
            this._piece = piece;
            return this;
        }

        public IMoveBuilder Destination(Position destination)
        {
            this._destination = destination;
            return this;
        }

        public IMoveBuilder Capture()
        {
            this._capture = true;
            return this;
        }

        public IMoveBuilder KingSideCastling()
        {
            this._kingSideCastling = true;
            return this;
        }

        public IMoveBuilder QueenSideCastling()
        {
            this._queenSideCastling = true;
            return this;
        }

        public IMoveBuilder Promotion(Name piece)
        {
            this._promotion = piece;
            return this;
        }

        public IMoveBuilder DrawOffer()
        {
            this._drawOffer = true;
            return this;
        }

        public IMoveBuilder Check()
        {
            this._check = true;
            return this;
        }

        public IMoveBuilder Checkmate()
        {
            this._checkmate = true;
            return this;
        }

        public IMoveBuilder Row()
        {
            this._row = true;
            return this;
        }

        public IMoveBuilder Column()
        {
            this._column = true;
            return this;
        }
        private bool IsCastling()
        {
            return _kingSideCastling || _queenSideCastling;
        }

        public IMoveBuilder Build(IChessboard chessboard)
        {
            if (!_drawOffer && IsCastling() && (_piece == null || _destination == null))
            {
                throw new IllegalMoveException();
            }
            var pieces = VerifyDualityOnDestPos(chessboard);
            if (FindPiecesSameRow(pieces) != null)
            {
                Column();
            }
            if (FindPiecesSameColumn(pieces) != null)
            {
                Row();
            }
            return this;
        }
        private IPiece FindPiecesSameRow(IList<IPiece> pieces)
        {
            return FindPiecesFunction(pieces, x=>x.Position.Y);
        }

        private IPiece FindPiecesSameColumn(IList<IPiece> pieces)
        {
            return FindPiecesFunction(pieces, x=>x.Position.X);
        }

        private IPiece FindPiecesFunction(IList<IPiece> pieces, Func<IPiece, int> func)
        {
            return pieces.FirstOrDefault(x => func.Invoke(x) == func.Invoke(_piece));
        }
        private IList<IPiece> VerifyDualityOnDestPos(IChessboard chessboard)
        {
            return GetPiecesSameType(chessboard)
                .Where(x => _controls.ControlledMoves(chessboard, x).Contains(_destination))
                .ToList();
        }

        private IList<IPiece> GetPiecesSameType(IChessboard chessboard)
        {
            return chessboard.PiecesList.Where(y => !y.Equals(_piece)).Where(y => y.Name.Equals(_piece.Name))
                .Where(y => !y.Equals(_piece))
                .ToList();

        }
        public override string ToString()
        {
            string str;
            if (_drawOffer)
            {
                str = "(=)";
            }
            else if (_kingSideCastling)
            {
                str = "0-0";
            }
            else if (_queenSideCastling)
            {
                str = "0-0-0";
            }
            else
            {
                str = GetMove();
            }
            return str;
        }

        private String GetMove()
        {
            return GetPieceNotation()
                   + GetDepartureX()
                   + GetDepartureY()
                   + GetCapture()
                   + _destination
                   + GetPromotion()
                   + GetCheckConditions();
        }
        private string GetDepartureY()
        {
            return _row ? _piece.Position.Y.ToString() : "";
        }
        private string GetDepartureX()
        {
            return _column || IsPawnCapture() ? _piece.Position.X.ToString() : "";
        }
        private bool IsPawnCapture()
        {
            return _piece.Name == Name.Pawn && _capture;
        }
        private string GetPieceNotation()
        {
 
            return ChessNotations.GetChessNotation(_piece.Name) != 'P' ? ChessNotations.GetChessNotation(_piece.Name).ToString() : "";
        }

        private string GetPromotion()
        {
            return (_promotion != null) ? "=" + ChessNotations.GetChessNotation(_promotion) : "";
        }
        private string GetCheckConditions()
        {
            if (_check)
            {
                return "+";
            }
            else if (_checkmate)
            {
                return "#";
            }
            else
            {
                return "";
            }
        }
        private string GetCapture()
        {
            return _capture ? "x" : "";
        }
    }
}
