﻿using Sample.Diary.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Diary.CQRS.Domain
{
    public interface IEventProvider
    {
        void LoadsFromHistory(IEnumerable<Event> history);

        IEnumerable<Event> GetUncommittedChanges();
    }
}
