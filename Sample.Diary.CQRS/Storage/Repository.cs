using Sample.Diary.CQRS.Domain;
using Sample.Diary.CQRS.Domain.Mementos;
using Sample.Diary.CQRS.Events;
using Sample.Diary.CQRS.Storage.Memento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Diary.CQRS.Storage
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot, new()
    {
        private readonly IEventStorage _eventStorage;

        private static object _lock = new object();

        public Repository(IEventStorage eventStorage)
        {
            _eventStorage = eventStorage;
        }

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            if (aggregate.GetUncommittedChanges().Any())
            {
                lock (_lock)
                {
                    var item = new T();
                    if (expectedVersion != -1)
                    {
                        item = GetById(aggregate.Id);
                        if (item.Version != expectedVersion)
                        {
                            throw new DBConcurrencyException(string.Format("Aggregate {0} has been previously modified",
                                                                        item.Id));
                        }
                    }
                    _eventStorage.Save(aggregate);
                }
            }
        }

        public T GetById(Guid id)
        {
            IEnumerable<Event> events;
            var memento = _eventStorage.GetMemento<BaseMemento>(id);
            if (memento != null)
            {
                events = _eventStorage.GetEvents(id).Where(e => e.Version >= memento.Version);
            }
            else
            {
                events = _eventStorage.GetEvents(id);
            }

            var obj = new T();
            if (memento != null)
            {
                ((IOriginator)obj).SetMemento(memento);
            }
            obj.LoadsFromHistory(events);
            return obj;
        }
    }
}
