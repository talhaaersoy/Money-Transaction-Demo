using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class TransactionDto
    {
        public Guid SenderAccountNumber { get; set; }
        public Guid ReceiverAccountNumber { get; set; }
        public decimal Amount { get; set; }

    }
}
