using System;

namespace Sample.Diary.CQRS.Commands
{
    public class Command : ICommand
    {
        public Guid Id { get; private set; }

        public int Version { get; set; }

        public Command(Guid id, int version)
        {
            Id = id;
            Version = version;
        }
    }
}