﻿using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ITransactionDal : IEntityRepository<Transaction>
    {
    }
}
