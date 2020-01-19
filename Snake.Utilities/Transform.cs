namespace Snake.Engine
{
    public class Transform
    {
        public Vector2 Position { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Transform(int x, int y, int width, int height)
        {
            this.Position = new Vector2(x, y);
            Width = width;
            Height = height;
        }

        public Transform(Vector2 position, int width, int height)
        {
            this.Position = position;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Moves the transform in the direction of translation
        /// </summary>
        /// <param name="translation">Direction vector to move the transform by</param>
        public void Translate(Vector2 translation)
        {
            this.Position.X += translation.X;
            this.Position.Y += translation.Y;
        }

        public override string ToString()
        {
            return $"X: {Position.X}\n Y: {Position.Y}\n";
        }
    }
}
