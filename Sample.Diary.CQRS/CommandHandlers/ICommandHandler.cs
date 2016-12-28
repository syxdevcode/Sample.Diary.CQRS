using Sample.Diary.CQRS.Commands;

namespace Sample.Diary.CQRS.CommandHandlers
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}