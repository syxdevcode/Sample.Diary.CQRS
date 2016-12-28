using Sample.Diary.CQRS.Events;
using System.Collections.Generic;

namespace Sample.Diary.CQRS.Domain
{
    public interface IEventProvider
    {
        void LoadsFromHistory(IEnumerable<Event> history);

        IEnumerable<Event> GetUncommittedChanges();
    }
}