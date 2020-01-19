namespace Snake.Domain
{
    using Engine;

    public class SnakeMovement
    {
        public SnakePart SnakePart { get; private set; }

        public Vector2 Movement { get; private set; }

        public SnakeMovement(SnakePart snakePart, Vector2 movement)
        {
            SnakePart = snakePart;
            Movement = movement;
        }

        public Vector2 GetDestination()
        {
            return SnakePart.Position + Movement;
        }
    }
}
