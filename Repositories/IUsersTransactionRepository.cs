using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCard_Transactions.Models;

namespace CreditCard_Transactions.Repositories
{
    public interface IUsersTransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsByUserId(int userid);
    }
}
