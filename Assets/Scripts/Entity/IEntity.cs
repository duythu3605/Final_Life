using System;
using UnityEngine;

public interface IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public bool IsOwn { get; }

    public bool IsActivated { get; }

    public void Own();

    public void DeOwn();

    public void Activated();

    public void DeActivated();

}
