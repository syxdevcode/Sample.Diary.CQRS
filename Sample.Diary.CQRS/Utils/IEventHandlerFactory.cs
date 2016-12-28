using Sample.Diary.CQRS.EventHandlers;
using Sample.Diary.CQRS.Events;
using System.Collections.Generic;

namespace Sample.Diary.CQRS.Utils
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event;
    }
}