using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Transaction :IEntity
    {
        public int Id { get; set; }
        public int SenderAccountNumber {get; set; }
        public int ReceiverAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
