namespace Snake.Application.Events
{
    public interface IObservable<TEvent>
        where TEvent : class
    {
        void AddObserver(IObserver<TEvent> obs);

        void RemoveObserver(IObserver<TEvent> obs);

        void NotifyObservers(TEvent e);
    }
}
