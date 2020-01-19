namespace Snake.Domain
{
    using Engine;

    public class SnakePart : Transform
    {
        public SnakePart(Vector2 position, int width, int height) : base(position, width, height)
        {
        }

        public SnakePart(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }
    }
}
