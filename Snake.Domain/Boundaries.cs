namespace Snake.Domain
{
    using Engine;

    public class Boundaries
    {
        public int Left { get; private set; }
        public int Top { get; private set; }
        public int Right { get; private set; }
        public int Bottom { get; private set; }

        public Boundaries(int left, int top, int right, int bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        /// <summary>
        /// Checks whether the transform is within the boundaries
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public bool IsOutOfBounds(Transform transform)
        {
            var isOutOfBounds = IsOutOfBoundsHorizontally(transform) || IsOutOfBoundsVertically(transform);
            return isOutOfBounds;
        }

        /// <summary>
        /// Checks whether the transform is out of bounds on the vertical axis
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public bool IsOutOfBoundsVertically(Transform transform)
        {
            return transform.Position.Y < Top || (transform.Position.Y + transform.Height) > Bottom;
        }

        /// <summary>
        /// Checks whether the transform is out of bounds on the horizontal axis
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public bool IsOutOfBoundsHorizontally(Transform transform)
        {
            return transform.Position.X < Left || (transform.Position.X + transform.Width) > Right;
        }
    }
}
