using AutoMapper;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Mapping
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<TransactionDto, Transaction>().ReverseMap();
            CreateMap<CreateAccountDto, Account>().ReverseMap();
        }

    }
}
