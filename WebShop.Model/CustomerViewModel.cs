using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebShop.Infrastructure.EntityBase;

namespace WebShop.Model
{
    public class CustomerViewModel : EntityBase<int>
    {
        public string LName { get; set; }
        public string FName { get; set; }
        public string Address { get; set; }
        public string LandPhone { get; set; }
        public string CellPhone { get; set; }

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