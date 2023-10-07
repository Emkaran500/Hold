using Hold.Messages.Base;
using System;
using System.Collections.Generic;

namespace Hold.Mediator;

public class MediatorMVVM
{
    private Dictionary<Type, List<Action<IMessage>>> actions;

    public MediatorMVVM()
    {
        this.actions = new Dictionary<Type, List<Action<IMessage>>>();
    }

    public void Subscribe<T>(Action<IMessage> action) where T : IMessage
    {
        var type = typeof(T);

        if (this.actions.ContainsKey(type) == false)
            this.actions.Add(type, new List<Action<IMessage>>());

        this.actions[type].Add(action);
    }

    public void Send<T>(T message) where T : IMessage
    {
        var type = typeof(T);

        if (this.actions.ContainsKey(type) == false)
            return;

        foreach (var action in this.actions[type])
        {
            action.Invoke(message);
        }
    }
}
