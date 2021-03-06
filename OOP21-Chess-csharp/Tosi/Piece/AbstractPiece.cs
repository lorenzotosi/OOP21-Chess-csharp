using System;
using System.Collections.Generic;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.Tosi.Piece
{
    public abstract class AbstractPiece : IPiece
    {
        private readonly bool _isMoved;
        protected Directions Directions { get; }
        public Name Name { get; }
        public Side Side { get; }
        public Position Position { get; private set; }
        protected AbstractPiece(Name name, Position position, Side side)
        {
            Name = name;
            Position = position;
            Side = side;
            _isMoved = false;
            Directions = new Directions();
        }

        public void SetPosition(Position position) => Position = position;

        public bool IsMoved() => _isMoved;

        public abstract List<Position> GetAllPossiblePositions(IChessboard chessboard);



        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Side);
        }

        public override bool Equals(object obj)
        {
            return obj is AbstractPiece piece &&
                   Name == piece.Name &&
                   Side == piece.Side &&
                   EqualityComparer<Position>.Default.Equals(Position, piece.Position);
        }

        public abstract int Value { get; }


    }
}
