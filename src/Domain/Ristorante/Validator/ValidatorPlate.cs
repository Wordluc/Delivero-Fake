using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ristorante.Validator
{
    internal class ValidatorPlate:AbstractValidator<Plate>
    {
        public ValidatorPlate() {
            RuleFor(x => x.Cost).GreaterThan(0);
            RuleFor(x => x.NamePlate).NotEmpty();
        }
    }
}
