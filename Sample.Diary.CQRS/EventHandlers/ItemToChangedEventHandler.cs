using Sample.Diary.CQRS.Events;
using Sample.Diary.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Diary.CQRS.EventHandlers
{
    public class ItemToChangedEventHandler : IEventHandler<ItemToChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemToChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemToChangedEvent e)
        {
            var item = _reportDatabase.GetById(e.AggregateId);
            item.To = e.To;
            item.Version = e.Version;
        }

    }
}
