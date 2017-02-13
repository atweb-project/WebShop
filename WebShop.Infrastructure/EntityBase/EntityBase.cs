using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Infrastructure.EntityBase
{
    public abstract class EntityBase<TId> : IValidatableObject
    {
        public TId Id { get; set; }
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
        public abstract bool IsValid();
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object entity)
        {
            return entity != null && entity is EntityBase<TId> && this == (EntityBase<TId>)entity;
        }
        public static bool operator ==(EntityBase<TId> entity1,EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
                return true;

            if ((object)entity1 == null || (object)entity2 == null)
                return false;

            if (entity1.Id.ToString() == entity2.Id.ToString())
                return true;

            return false;
        }
        public static bool operator !=(EntityBase<TId> entity1,EntityBase<TId> entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}
