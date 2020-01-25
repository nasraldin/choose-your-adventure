using System.Collections.Generic;

namespace ChooseYourAdventure.SharedKernel
{
    /// <summary>
    /// An entity can inherit this class of directly implement to IEntity interface.
    /// This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

        // you can add audited info in this class
    }
}