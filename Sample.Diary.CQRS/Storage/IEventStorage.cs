using Sample.Diary.CQRS.Domain;
using Sample.Diary.CQRS.Domain.Mementos;
using Sample.Diary.CQRS.Events;
using System;
using System.Collections.Generic;

namespace Sample.Diary.CQRS.Storage
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(Guid aggregateId);

        void Save(AggregateRoot aggregate);

        T GetMemento<T>(Guid aggregateId) where T : BaseMemento;

        void SaveMemento(BaseMemento memento);
    }
}