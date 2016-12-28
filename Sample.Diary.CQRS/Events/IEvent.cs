using System;

namespace Sample.Diary.CQRS.Events
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}