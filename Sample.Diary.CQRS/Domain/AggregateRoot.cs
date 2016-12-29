using Sample.Diary.CQRS.Events;
using Sample.Diary.CQRS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Diary.CQRS.Domain
{
    public class AggregateRoot : IEventProvider
    {
        private readonly List<Event> _changes;

        public Guid Id { get; set; }

        public int Version { get; set; }

        public int EventVersion { get; set; }

        protected AggregateRoot()
        {
            _changes = new List<Event>();
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history)
            {
                ApplyChange(e, false);
            }

            Version = history.Last().Version;
            EventVersion = Version;
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event, true);
        }

        protected void ApplyChange(Event @event, bool isNew)
        {
            dynamic d = this;

            //this指DiayItem对象，Handle方法为DiayItem对象定义的Handle方法
            d.Handle(Converter.ChangeTo(@event, @event.GetType()));
            if (isNew)
            {
                _changes.Add(@event);
            }
        }

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }
    }
}