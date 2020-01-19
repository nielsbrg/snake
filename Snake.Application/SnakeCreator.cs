namespace Snake.Application
{
    using Domain;
    using Engine;
    using Properties;
    using System.Drawing;

    public static class SnakeCreator
    {
        public static Snake CreateSnake(Board board)
        {
            var settings = new Settings();
            var snakePartSize = settings.SnakePartSize;
            var snakeInitialSpeed = settings.SnakeInitialSpeed;
            var startingPosition = GetSnakeStartingPosition(board.Transform);
            var snakeHead = new SnakePart(startingPosition, snakePartSize.Width, snakePartSize.Height);
            return new Snake(snakeHead, snakeInitialSpeed);
        }

        private static Vector2 GetSnakeStartingPosition(Transform board)
        {
            var x = board.Width / 2;
            var y = board.Height / 2;
            return new Vector2(x, y);
        }
    }
}
