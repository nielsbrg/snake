namespace Snake.Application.Events
{
    using System.Collections.Generic;

    public class Observable<TEvent> : IObservable<TEvent>
        where TEvent : class
    {
        private readonly List<IObserver<TEvent>> observers = new List<IObserver<TEvent>>();

        public void AddObserver(IObserver<TEvent> obs)
        {
            this.observers.Add(obs);
        }

        public void RemoveObserver(IObserver<TEvent> obs)
        {
            this.observers.Remove(obs);
        }

        public void NotifyObservers(TEvent e)
        {
            observers.ForEach(x => x.HandleEvent(e));
        }
    }
}
