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

        public abstract override int GetHashCode();
        public abstract override bool Equals(object obj);

        protected bool EqualsType<T>(object @object) where T : Entity
        {
            if(@object is T == false)
            {
                return false;
            }

            var instance = @object as T;

            if(instance == this)
            {
                return false;
            }

            return true;
        }
    }
}