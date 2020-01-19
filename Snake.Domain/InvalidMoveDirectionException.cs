namespace Snake.Domain
{
    using System;

    public class InvalidMoveDirectionException : Exception
    {
        public InvalidMoveDirectionException(string message) : base(message)
        {
        }
    }
}
