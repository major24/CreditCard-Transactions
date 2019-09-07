using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCard_Transactions.Models;

namespace CreditCard_Transactions.Repositories
{
    public class MockTransactionRepository : ITransactionRepository
    {
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            await Task.Delay(1);
            Transaction t1 = new Transaction() { Id = 900, Description = "Air fare (m)", Amount = 1270.00m, UserId = 1 };
            Transaction t2 = new Transaction() { Id = 901, Description = "Business Meeting Exp (m)", Amount = 560.00m, UserId = 1 };

            return new Transaction[] { t1, t2 };
        }

        public Task<Transaction> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetTransactionsByUserId(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<string> Save(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
