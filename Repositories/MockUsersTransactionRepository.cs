using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCard_Transactions.Models;

namespace CreditCard_Transactions.Repositories
{
    public class MockUsersTransactionRepository : IUsersTransactionRepository
    {
        public async Task<IEnumerable<Transaction>> GetTransactionsByUserId(int userid)
        {
            await Task.Delay(1);
            var data = GetSampleDataByUserId();

            var selected = data.Where(t => t.UserId == userid);
            return selected;
        }

        private IEnumerable<Transaction> GetSampleDataByUserId()
        {
            Transaction t1 = new Transaction() { Id = 900, Description = "Air fare (um)", Amount = 1270.00m, UserId = 1 };
            Transaction t2 = new Transaction() { Id = 901, Description = "Business Meeting Exp (um)", Amount = 560.00m, UserId = 1 };
            Transaction t3 = new Transaction() { Id = 902, Description = "Taxi fare (um)", Amount = 50.00m, UserId = 2 };

            return new Transaction[] { t1, t2, t3 };
        }
    }
}
