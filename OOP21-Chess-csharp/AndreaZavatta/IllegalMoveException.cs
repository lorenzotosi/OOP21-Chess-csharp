using System;
using System.Runtime.Serialization;

namespace OOP21_Chess_csharp.AndreaZavatta
{
    [Serializable]
    internal class IllegalMoveException : Exception
    {
        public IllegalMoveException()
        {
        }

        public IllegalMoveException(string message) : base(message)
        {
        }

        public IllegalMoveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalMoveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}