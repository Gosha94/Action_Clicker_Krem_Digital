using System;
using System.Collections.Generic;

public class BuildingPartDestroyedEvent
{
    private readonly List<Action<PartOfBuilding>> _callbacks = new List<Action<PartOfBuilding>>();

    public void Subscribe(Action<PartOfBuilding> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(PartOfBuilding partBuilding)
    {
        foreach (var callback in _callbacks)
        {
            callback(partBuilding);
        }
    }

}
