namespace Snake.Engine
{
    public class Vector2
    {
        public static Vector2 Zero => new Vector2(0, 0);

        public int X { get; set; }

        public int Y { get; set; }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Subtracts vector B from vector A and returns the resulting vector.
        /// </summary>
        /// <param name="a">The original vector</param>
        /// <param name="b">The vector to subtract</param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        /// <summary>
        /// Adds vector B to vector A and returns the resulting vector.
        /// </summary>
        /// <param name="a">The original vector</param>
        /// <param name="b">The vector to add</param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator *(Vector2 a, int scaleFactor)
        {
            return new Vector2(a.X * scaleFactor, a.Y * scaleFactor);
        }
    }
}
