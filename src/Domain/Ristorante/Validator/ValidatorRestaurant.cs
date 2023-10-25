using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ristorante.Validation
{
    internal class ValidatorRestaurant : AbstractValidator<Restaurant>
    {
        public ValidatorRestaurant() { 
              RuleFor(x=>x.Name).MaximumLength(10).MinimumLength(3);
              RuleFor(x=>x.Address!.Via).MinimumLength(3);
              RuleFor(x => x.Address!.AddressNumber).GreaterThan(0);

        }
    }
}
