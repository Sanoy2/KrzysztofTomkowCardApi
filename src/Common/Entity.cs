using System;

namespace Common
{
    public abstract class Entity
    {
        // Maybe it should be private set and a method Save(long id) that can override only "0" id ??
        // Then id would be assigned by repository
        public long Id { get; }
        public Entity(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must have positive value!", nameof(id));
            }

            this.Id = id;
        }
    }
}