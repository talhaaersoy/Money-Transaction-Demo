using Entities.Concrete;
using Entities.Models;
using Entities.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITransactionService
    {
        ResponseDataModel<List<Transaction>> GetAll();
        IResponse Add(TransactionDto transaction);

    }
}
