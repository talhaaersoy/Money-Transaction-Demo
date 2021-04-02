using Entities.Concrete;
using Entities.Models;
using Entities.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAccountService
    {
        ResponseDataModel<List<Account>> GetAll();
        ResponseDataModel<Account> Get(int id);
        ResponseModel Add(CreateAccountDto account);
    }
}
