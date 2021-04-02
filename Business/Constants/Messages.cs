using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AccountCreated = "Account Created";
        public static string SucceedTransaction = "Money Transaction Succeed";
        public static string BalanceError = "İnsufficient Balance";
        public static string CurrencyCodeError = "Both sender and receiver accounts should have the same currency code.";
    }
}
