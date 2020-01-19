namespace Snake.Domain
{
    using Engine;
    using System.Collections.Generic;

    public class BoardSpace : Transform
    {
        public BoardSpace(Vector2 position, int width, int height) : base(position, width, height)
        {
        }

        public BoardSpace(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public List<Transform> OccupyingEntities { get; } = new List<Transform>();
    }
}
