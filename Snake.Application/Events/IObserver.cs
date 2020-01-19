namespace Snake.Application.Events
{
    public interface IObserver<TEvent>
        where TEvent : class
    {
        void HandleEvent(TEvent e);
    }
}
