namespace OOP21_Chess_csharp.Speranza.User
{
    public interface IUser
    { 
        string Name { get; }
        void HaveWon();
        bool IsGameWinner { get; }
    }
}