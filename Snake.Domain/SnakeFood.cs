namespace Snake.Domain
{
    using Engine;

    public class SnakeFood : Transform
    {
        public SnakeFood(Vector2 position, int width, int height) : base(position, width, height)
        {
        }

        public SnakeFood(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }
    }
}
