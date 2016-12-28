using System;

namespace Sample.Diary.CQRS.Domain.Mementos
{
    public class BaseMemento
    {
        public Guid Id { get; set; }

        public int Version { get; set; }
    }
}