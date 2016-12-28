using Sample.Diary.CQRS.Domain;
using System;

namespace Sample.Diary.CQRS.Storage
{
    public interface IRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);

        T GetById(Guid id);
    }
}