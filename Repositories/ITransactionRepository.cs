using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditCard_Transactions.Models;

namespace CreditCard_Transactions.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAll();
        Task<Transaction> GetById(int id);
        Task<string> Save(Transaction transaction);
    }
}
