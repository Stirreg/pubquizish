using System;

namespace Pubquizish.Shared.Domain
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; protected set; }
    }
}
