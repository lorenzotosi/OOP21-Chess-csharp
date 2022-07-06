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
    /**
     * This interface is used to convert a move into a string.
     * 
     */
    public interface IMoveBuilder
    {

        IMoveBuilder Piece(IPiece piece);


        IMoveBuilder Destination(Position destination);

        IMoveBuilder Capture();


        IMoveBuilder KingSideCastling();

        IMoveBuilder QueenSideCastling();

        IMoveBuilder Promotion(Name piece);

        IMoveBuilder DrawOffer();
        IMoveBuilder Check();

        IMoveBuilder Checkmate();

        IMoveBuilder Row();

        IMoveBuilder Column();

        IMoveBuilder Build(IChessboard chessboard);
    }
}
