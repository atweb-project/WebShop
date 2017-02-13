using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Infrastructure.EntityBase;

namespace WebShop.Model
{
    public class OrderViewModel : EntityBase<int> , IAggregateRoot
    {
        public CustomerViewModel Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Comments { get; set; }
        public List<ItemViewModel> ListOfItemViewModels { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderDate < DateTime.Now)
            {
                yield return new ValidationResult("Order Date is not valid", new []{" Please enter valid date"});
            }
        }

        public override bool IsValid()
        {
            return true;
        }

        public OrderViewModel()
        {
            this.ListOfItemViewModels = new List<ItemViewModel>();

            this.Customer = new CustomerViewModel();
        }
    }
}
