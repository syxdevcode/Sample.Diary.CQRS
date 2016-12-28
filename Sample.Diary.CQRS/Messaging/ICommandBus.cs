using Sample.Diary.CQRS.Commands;

namespace Sample.Diary.CQRS.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;
    }
}