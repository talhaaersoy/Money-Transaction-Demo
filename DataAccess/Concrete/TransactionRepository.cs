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
    public class TransactionRepository : ITransactionDal
    {
        private DbContextOptions<BankContext> _options;

        public TransactionRepository()
        {
            _options = new DbContextOptionsBuilder<BankContext>().UseInMemoryDatabase(databaseName: "Test").Options;
        }

        public List<Transaction> GetAll(Expression<Func<Transaction, bool>> filter = null)
        {
            using (BankContext context = new BankContext(_options))
            {
                return filter == null
                    ? context.Set<Transaction>().ToList()
                    : context.Set<Transaction>().Where(filter).ToList();
            }
        }

        public Transaction Get(Expression<Func<Transaction, bool>> filter)
        {
            using (BankContext context = new BankContext(_options))
            {
                return context.Set<Transaction>().SingleOrDefault(filter);
            }
        }

        public void Add(Transaction entity)
        {
            using (BankContext context = new BankContext(_options))
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Transaction entity)
        {
            using (BankContext context = new BankContext(_options))
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Transaction entity)
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
