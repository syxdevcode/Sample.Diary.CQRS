using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Diary.CQRS.Events
{
    public class Event : IEvent
    {
        public int Version;

        public Guid AggregateId { get; set; }

        public Guid Id { get; private set; }
    }
}
