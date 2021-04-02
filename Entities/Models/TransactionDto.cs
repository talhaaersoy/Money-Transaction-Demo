using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class TransactionDto
    {
        public int SenderAccountNumber { get; set; }
        public int ReceiverAccountNumber { get; set; }
        public decimal Amount { get; set; }

    }
}
