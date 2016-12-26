using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
