using Sample.Diary.CQRS.Events;
using Sample.Diary.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Diary.CQRS.EventHandlers
{
    public class ItemRenamedEventHandler : IEventHandler<ItemRenamedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemRenamedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemRenamedEvent e)
        {
            var item = _reportDatabase.GetById(e.AggregateId);
            item.Title = e.Title;
            item.Version = e.Version;
        }
    }
}
