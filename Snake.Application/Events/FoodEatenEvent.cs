namespace Snake.Application.Events
{
    using Domain;

    public sealed class FoodEatenEvent
    {
        public SnakeFood EatenFood { get; }

        public BoardSpace BoardSpace { get; }

        public FoodEatenEvent(BoardSpace boardSpace, SnakeFood snakeFood)
        {
            this.BoardSpace = boardSpace;
            this.EatenFood = snakeFood;
        }
    }
}
