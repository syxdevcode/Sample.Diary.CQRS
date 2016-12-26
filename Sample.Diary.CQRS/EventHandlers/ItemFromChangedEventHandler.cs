﻿using Sample.Diary.CQRS.Events;
using Sample.Diary.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Diary.CQRS.EventHandlers
{
    public class ItemFromChangedEventHandler : IEventHandler<ItemFromChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemFromChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemFromChangedEvent e)
        {
            var item = _reportDatabase.GetById(e.AggregateId);
            item.From = e.From;
            item.Version = e.Version;
        }
    }
}
