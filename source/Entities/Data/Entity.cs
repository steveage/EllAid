using System;

namespace EllAid.Entities.Data
{
    public abstract class Entity
    {
        public Entity() => Id = Guid.NewGuid();
        public Guid Id { get; set; }
    }
}