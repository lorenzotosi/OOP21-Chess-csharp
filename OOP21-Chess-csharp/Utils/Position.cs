namespace OOP21_Chess_csharp.Utils
{
    public class Position
    {

        private readonly int _x;
        private readonly int _y;

        private Position(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public static Position CreateNumericPosition(int x, int y)
        {
            return new Position(x, y);
        }

        public static Position CreateNewPosition(string position)
        {
            return new Position(FromCharToInt(position[0]),
                                -int.Parse(position[1].ToString()) + 8);
        }

        public int X => _x;
        public int Y => _y;

        public char GetCharX()
        {
            return this.ConvertFromNumberToLetter();
        }

        private char ConvertFromNumberToLetter()
        {
            var a = 'a';
            return (char)(a + X);
        }

        private static int FromCharToInt(char firstLetter)
        {
            return firstLetter - 'a';
        }

        public override string ToString()
        {
            return ConvertFromNumberToLetter() + (8 - Y).ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   _x == position._x &&
                   _y == position._y;
        }

        public override int GetHashCode()
        {
            int hashCode = 979593255;
            hashCode = hashCode * -1521134295 + _x.GetHashCode();
            hashCode = hashCode * -1521134295 + _y.GetHashCode();
            return hashCode;
        }
    }
}
