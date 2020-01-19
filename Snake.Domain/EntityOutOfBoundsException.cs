namespace Snake.Domain
{
    using System;

    /// <summary>
    /// For use when an entity's position is outside of the game's boundaries
    /// </summary>
    public class EntityOutOfBoundsException : Exception
    {
        public EntityOutOfBoundsException()
        {
        }

        public EntityOutOfBoundsException(string message) : base(message)
        {
        }
    }
}
