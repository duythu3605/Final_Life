using System;

public interface IObserver<T>
{
    public abstract void OnNotify(T data);
}
