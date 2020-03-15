using System;

namespace Common
{
    public abstract class Entity
    {
        public Guid Id { get; }
        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}