using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCard_Transactions.Models;

namespace CreditCard_Transactions.Repositories
{
    public class UsersTransactionRepository : IUsersTransactionRepository
    {
        private readonly IHelper _helper;

        public UsersTransactionRepository(IHelper helper)
        {
            _helper = helper;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByUserId(int userid)
        {
            using (var conn = _helper.Connection)
            {
                string sql = @"select Id, user_id as userid, trans_type as transtype, description, amount, tax, trans_date as transdate, status 
                                    from transactions
                                    where user_id = @userid";
                DynamicParameters dp = new DynamicParameters();
                dp.Add("userid", userid, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, 100);

                conn.Open();
                var result = await conn.QueryAsync<Transaction>(sql, dp);
                return result;
            }
        }
    }
}
