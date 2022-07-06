using System.Collections.Generic;
using OOP21_Chess_csharp.Speranza.User;
using OOP21_Chess_csharp.Tosi.Utils;

namespace OOP21_Chess_csharp.MarcoRaggini
{
    public interface ITurn
    {
        public int TurnNumber { get; }
        public KeyValuePair<User, Side> Player1 { get; }
        public KeyValuePair<User, Side> Player2 { get; }

        public void TurnIncrement();
        public Side GetUserTurn();
        public KeyValuePair<User, Side> GetPairByColor(Side color);
        public Side GetOppositeColor(Side color);
        public KeyValuePair<User, User> GetUsers();
    }
}