using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Transaction :IEntity
    {
        public Guid Id { get; set; }
        public Guid SenderAccountNumber {get; set; }
        public Guid RecieverAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
