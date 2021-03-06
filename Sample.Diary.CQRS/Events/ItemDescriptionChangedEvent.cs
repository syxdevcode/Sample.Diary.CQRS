﻿using System;

namespace Sample.Diary.CQRS.Events
{
    public class ItemDescriptionChangedEvent : Event
    {
        public string Description { get; set; }

        public ItemDescriptionChangedEvent(Guid aggregateId, string description)
        {
            AggregateId = aggregateId;
            Description = description;
        }
    }
}