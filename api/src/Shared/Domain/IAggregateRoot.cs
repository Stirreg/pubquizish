using System;

namespace Pubquizish.Shared.Domain
{
    public interface IAggregateRoot
    {
        public Guid Id { get; }
    }
}
