using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.MarcoRaggini
{
    public class Turn : ITurn
    {
        public int TurnNumber { get; private set; }
        public KeyValuePair<User, Side> Player1 { get; }
        public KeyValuePair<User, Side> Player2 { get; }

        public Turn(int turnNumber, KeyValuePair<User, Side> player1, KeyValuePair<User, Side> player2)
        {
            TurnNumber = turnNumber;
            Player1 = player1;
            Player2 = player2;
        }

        public void TurnIncrement()
        {
            TurnNumber++;
        }

        public Side GetUserTurn()
        {
            return Math.Abs(TurnNumber % 2) == 1
                ? Side.White
                : Side.Black;
        }

        public KeyValuePair<User, Side> GetPairByColor(Side color)
        {
            return Player1.Value.Equals(color) 
                ? Player1 
                : Player2;
        }

        public Side GetOppositeColor(Side color)
        {
            return color.Equals(Side.White) 
                ? Side.White 
                : Side.Black;
        }

        public KeyValuePair<User, User> GetUsers()
        {
            return new KeyValuePair<User, User>(Player1.Key, Player2.Key);
        }
    }
}