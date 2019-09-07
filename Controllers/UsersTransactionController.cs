using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCard_Transactions.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreditCard_Transactions.Models;

namespace CreditCard_Transactions.Controllers
{
    [Route("api/users/{userid}/transactions")]
    [ApiController]
    public class UsersTransactionController : ControllerBase
    {
        private readonly IUsersTransactionRepository _usersTransactionRepository;

        public UsersTransactionController(IUsersTransactionRepository usersTransactionRepository)
        {
            _usersTransactionRepository = usersTransactionRepository;
        }

        // GET api/users/5/transactions
        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetTransactionsByUserId(int userid)
        {
            return await _usersTransactionRepository.GetTransactionsByUserId(userid);
        }

    }
}
