using Sample.Diary.CQRS.CommandHandlers;
using Sample.Diary.CQRS.Commands;

namespace Sample.Diary.CQRS.Utils
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}