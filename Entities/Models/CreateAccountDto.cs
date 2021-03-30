using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class CreateAccountDto
    {
        public string CurrencyCode { get; set; }
        public decimal Balance { get; set; }

    }
}
