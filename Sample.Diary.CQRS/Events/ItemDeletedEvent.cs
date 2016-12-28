using System;

namespace Sample.Diary.CQRS.Events
{
    public class ItemDeletedEvent : Event
    {
        public ItemDeletedEvent(Guid aggreageteId)
        {
            AggregateId = aggreageteId;
        }
    }
}