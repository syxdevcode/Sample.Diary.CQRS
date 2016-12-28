using System;

namespace Sample.Diary.CQRS.Commands
{
    public class DeleteItemCommand : Command
    {
        public DeleteItemCommand(Guid id, int version)
            : base(id, version)
        {
        }
    }
}