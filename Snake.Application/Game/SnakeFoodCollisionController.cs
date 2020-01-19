namespace Snake.Application.Game
{
    using Engine;
    using Snake.Domain;
    using Events;
    using System.Linq;

    public class SnakeFoodCollisionController : Observable<FoodEatenEvent>, IBehaviour
    {
        private readonly Board board;

        private readonly Snake snake;

        public SnakeFoodCollisionController(Board board, Snake snake)
        {
            this.board = board;
            this.snake = snake;
        }

        public void Update()
        {
            var headBoardSpace = board.GetBoardSpaceFromPosition(snake.Head.Position);

            if (headBoardSpace.OccupyingEntities.SingleOrDefault(x => x is SnakeFood) is SnakeFood food)
            {
                NotifyObservers(new FoodEatenEvent(headBoardSpace, food));
            }
        }
    }
}
