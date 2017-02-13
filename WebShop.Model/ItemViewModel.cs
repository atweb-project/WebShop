using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebShop.Infrastructure.EntityBase;

namespace WebShop.Model
{
    public class ItemViewModel : EntityBase<int>
    {
        public int IdItem { get; set; }
        public Nullable<decimal> ItemKg { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return null;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}