namespace Snake.Application.Events
{
    using Domain;

    public sealed class DirectionChangedEvent
    {
        public DirectionChangedEvent(MoveDirection direction)
        {
            Direction = direction;
        }

        public MoveDirection Direction { get; set; }
    }
}
