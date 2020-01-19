namespace Snake.Application.Game
{
    using Domain;
    using Engine;
    using Events;
    using System.Collections.Generic;
    using System.Linq;

    public class SnakeController : Observable<SnakeDyingEvent>, IObserver<DirectionChangedEvent>, IObserver<FoodEatenEvent>, IBehaviour
    {
        public Snake Snake { get; }

        public Board Board { get; }

        public SnakeController(Board board, Snake snake)
        {
            Board = board;
            this.Snake = snake;
        }

        public void Update()
        {
            var nextMovements = Snake.GetNextMovements();

            foreach (var movement in nextMovements)
            {
                if (!Board.IsValidPosition(movement.GetDestination()))
                {
                    NotifyObservers(new SnakeDyingEvent());
                    return;
                }
            }

            UpdateBoardPositions(nextMovements);

            var collidingSnakeParts = GetCollidingSnakeParts(nextMovements);

            if (collidingSnakeParts.Count > 1)
            {
                NotifyObservers(new SnakeDyingEvent());
                return;
            }

            Snake.ApplyMovements(nextMovements);
        }

        private void UpdateBoardPositions(SnakeMovement[] movements)
        {
            foreach(var movement in movements)
            {
                Board.UpdateBoardPosition(movement.SnakePart, movement.SnakePart.Position, movement.GetDestination());
            }
        }

        private List<SnakePart> GetCollidingSnakeParts(SnakeMovement[] nextMovements)
        {
            var nextHeadSpace = Board.GetBoardSpaceFromPosition(nextMovements[0].GetDestination());

            return nextHeadSpace.OccupyingEntities
                .Where(x => x is SnakePart)
                .Select(x => x as SnakePart)
                .ToList();
        }

        public void HandleEvent(FoodEatenEvent e)
        {
            Snake.Extend();

            if (Board.IsEntityOutOfBounds(Snake.Parts[Snake.Parts.Count - 1]))
            {
                NotifyObservers(new SnakeDyingEvent());
            }
        }

        public void HandleEvent(DirectionChangedEvent e)
        {
            Snake.SetDirection(e.Direction);
        }
    }
}
