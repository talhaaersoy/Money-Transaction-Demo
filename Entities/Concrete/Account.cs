using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Account : IEntity
    {
        
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Balance { get; set; }
    }
}
