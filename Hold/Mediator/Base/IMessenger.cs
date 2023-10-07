using Hold.Messages.Base;
using System;

namespace Hold.Mediator.Base;

public interface IMessenger
{
    void Subscribe<T>(Action<IMessage> action) where T : IMessage;
    void Send<T>(T message) where T : IMessage;
}
