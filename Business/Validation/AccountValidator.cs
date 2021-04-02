using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation
{

    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            List<string> currencyCodes = new List<string>() { "try", "usd", "eur" };
            RuleFor(x => x.CurrencyCode)
              .Must(x => currencyCodes.Contains(x)).WithMessage("Please only use those currency codes: " + String.Join(",", currencyCodes));
            RuleFor(x => x.Balance).ScalePrecision(2,10).WithMessage("Must be a precison of 2");
        }
    }
}
