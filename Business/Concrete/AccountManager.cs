using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using Entities.Models.Response;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IMapper _mapper;
        private readonly IValidator<Account> _accountValidator;

        public AccountManager(IAccountDal accountdal,IMapper mapper,IValidator<Account> validator)
        {
            _accountDal = accountdal;
            _mapper = mapper;
            _accountValidator = validator;
        }

        public ResponseDataModel<List<Account>> GetAll()
        {
            var result = _accountDal.GetAll();
            int referenceNumber = Guid.NewGuid().GetHashCode();
            return new ResponseDataModel<List<Account>>(result,referenceNumber, false);
        }
        public ResponseDataModel<Account> Get(int id)
        {
            var result =_accountDal.Get(b => b.Id == id);
            return new ResponseDataModel<Account>(result, false);

        }
        public ResponseModel Add(CreateAccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            var validateResult = _accountValidator.Validate(account);
            int referenceNumber = Guid.NewGuid().GetHashCode();
            if (validateResult.IsValid)
            {
                account.Id = Guid.NewGuid().GetHashCode();
                _accountDal.Add(account);
                
                return new ResponseModel(referenceNumber, false,Messages.AccountCreated);
            }
            else
            {
                return new ResponseModel(referenceNumber, true,validateResult.Errors[0].ToString());
            }

           
        }
    }
}
