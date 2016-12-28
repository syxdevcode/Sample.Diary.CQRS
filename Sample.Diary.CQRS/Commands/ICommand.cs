using System;

namespace Sample.Diary.CQRS.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}