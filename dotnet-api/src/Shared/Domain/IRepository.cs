using System;

namespace Pubquizish.Shared.Domain
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        void Add(TAggregateRoot aggregateRoot);
        void Update(TAggregateRoot aggregateRoot);
        TAggregateRoot Find(Guid Id);
        void Remove(TAggregateRoot aggregateRoot);
    }
}
