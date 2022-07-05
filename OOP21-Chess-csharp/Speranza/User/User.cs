namespace OOP21_Chess_csharp.Speranza.User
{
    public class User : IUser
    {
        public User(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void HaveWon()
        {
            IsGameWinner = true;
        }

        public bool IsGameWinner { get; private set; }
        
        public override string ToString() {
            return Name;
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((User)obj);
        }
    }
}