using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class AccountRepository : IAccountDal 
    {
        private DbContextOptions<BankContext> _options;

        public AccountRepository()
        {
            _options = new DbContextOptionsBuilder<BankContext>().UseInMemoryDatabase(databaseName: "Test").Options;
        }

        public List<Account> GetAll(Expression<Func<Account, bool>> filter = null)
        {
            using (BankContext context = new BankContext(_options))
            {
                return filter == null
                    ? context.Set<Account>().ToList()
                    : context.Set<Account>().Where(filter).ToList();
            }
        }

        public Account Get(Expression<Func<Account, bool>> filter)
        {
            using (BankContext context = new BankContext(_options))
            {
                return context.Set<Account>().SingleOrDefault(filter);
            }
        }

        public void Add(Account entity)
        {
            using (BankContext context = new BankContext(_options))
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Account entity)
        {
            using (BankContext context = new BankContext(_options))
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Account entity)
        {
            using (BankContext context = new BankContext(_options))
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
