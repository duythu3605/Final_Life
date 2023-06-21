using System.Collections.Generic;

public class Observable<T>
{
    private List<IObserver<T>> _observers = new List<IObserver<T>>();
    public void AddObserver(IObserver<T> observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IObserver<T> observer)
    {
        _observers.Remove(observer);
    }
    public void NotifyObservers(T data)
    {
        foreach(IObserver<T> observer in _observers)
        {
            observer.OnNotify(data);
        }
    }
}
