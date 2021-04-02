using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using Entities.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Concrete
{
    public class TransactionManager : ITransactionService
    {
        private readonly ITransactionDal _transaction;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IAccountDal _accountDal;
        public TransactionManager(ITransactionDal transaction,IMapper mapper,IAccountService accountService,IAccountDal accountDal)
        {
            _transaction = transaction;
            _mapper = mapper;
            _accountService = accountService;
            _accountDal = accountDal;
        }

        public IResponse Add(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);
            transaction.Id = Guid.NewGuid().GetHashCode();
            IResponse result = BusinessRules.BusinessRules.Run(CheckCurrencyCode(transaction), CheckBalance(transaction));
            if (result != null)
            {
                return result;
            }
            else
            {
                UpdateBalance(transaction);
                _transaction.Add(transaction);
                return new ResponseModel(transaction.Id, false,Messages.SucceedTransaction);
            }
        }
        public ResponseDataModel<List<Transaction>> GetAll()
        {
            var result = _transaction.GetAll();
            return new ResponseDataModel<List<Transaction>>(result, true);
        }
        public IResponse CheckBalance(Transaction transaction)
        {
            var senderBalance=_accountService.Get(transaction.SenderAccountNumber).Data.Balance;
            var amount = transaction.Amount;
            if (senderBalance<amount)
            {
                return new ResponseModel(transaction.Id, true,Messages.BalanceError);
            }
            return new ResponseModel(transaction.Id, false);
        }
        public IResponse CheckCurrencyCode(Transaction transaction)
        {
            string senderCurrencyCode = _accountDal.Get(a => a.Id == transaction.SenderAccountNumber).CurrencyCode;
            var receiverCurrencyCode = _accountDal.Get(b => b.Id == transaction.ReceiverAccountNumber).CurrencyCode;
            if (senderCurrencyCode == receiverCurrencyCode)
            {
                return new ResponseModel(transaction.Id, false);
            }
            return new ResponseModel(transaction.Id, true,Messages.CurrencyCodeError);
        }

        public void UpdateBalance(Transaction transaction)
        {
            var senderAccount = _accountDal.Get(b => b.Id == transaction.SenderAccountNumber);
            var receiverAccount = _accountDal.Get(b => b.Id == transaction.ReceiverAccountNumber);
            senderAccount.Balance -= transaction.Amount;
            receiverAccount.Balance += transaction.Amount;
            _accountDal.Update(senderAccount);
            _accountDal.Update(receiverAccount);
        }

    }

}
