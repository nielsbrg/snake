namespace Snake.Application.Game
{
    using Engine;
    using System.Collections.Generic;
    using Domain;
    using System;
    using Events;

    public class SnakeFoodController : Events.IObserver<FoodEatenEvent>, IBehaviour
    {
        public List<SnakeFood> ActiveFoods { get; } = new List<SnakeFood>();

        public Board Board { get; private set; }

        public SnakeFoodController(Board board)
        {
            this.Board = board;
        }

        public void Update()
        {
            if(ActiveFoods.Count == default)
            {
                SpawnFood();
            }
        }

        private void SpawnFood()
        {
            var boardSpace = GetFoodBoardSpace();
            var snakeFood = new SnakeFood(boardSpace.Position, boardSpace.Width, boardSpace.Height);
            ActiveFoods.Add(snakeFood);
            boardSpace.OccupyingEntities.Add(snakeFood);
        }

        private BoardSpace GetFoodBoardSpace()
        {
            var freeBoardSpaces = Board.GetFreeBoardSpaces();
            var randomIndex = new Random().Next(0, freeBoardSpaces.Count);
            return freeBoardSpaces[randomIndex];
        }

        public void HandleEvent(FoodEatenEvent e)
        {
            ActiveFoods.Remove(e.EatenFood);
            e.BoardSpace.OccupyingEntities.Remove(e.EatenFood);
        }
    }
}
