﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Diary.CQRS.Events
{
   public interface IHandle<TEvent>where TEvent:Event
    {
        void Handle(TEvent e);
    }
}
