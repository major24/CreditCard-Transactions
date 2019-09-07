using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CreditCard_Transactions.Models;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace CreditCard_Transactions.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IHelper _helper;

        public TransactionRepository(IHelper helper)
        {
            _helper = helper;
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            using (var conn = _helper.Connection)
            {
                string sql = @"select Id, user_id as userid, trans_type as transtype, description, amount, tax, trans_date as transdate, status 
                                    from transactions";
                conn.Open();
                var result = await conn.QueryAsync<Transaction>(sql);
                return result;
            }
        }



        public async Task<Transaction> GetById(int id)
        {
            using (var conn = _helper.Connection)
            {
                string sql = @"select Id, user_id as userid, trans_type, description, amount, tax, trans_date, status 
                                    from transactions
                                    where id = @id";
                DynamicParameters dp = new DynamicParameters();
                dp.Add("id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input, 100);

                conn.Open();
                var result = await conn.QueryFirstOrDefaultAsync<Transaction>(sql, dp);
                return result;
            }
        }

        public Task<string> Save(Transaction transaction)
        {
            try
            {
                using (var conn = _helper.Connection)
                {
                    string sql = @"insert into transactions (user_id, trans_type, description, amount)
                                values (@userid, @transtype, @description, @amount)";
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("userid", transaction.UserId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                    dp.Add("transtype", transaction.TransType, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                    dp.Add("description", transaction.Description, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                    dp.Add("amount", transaction.Amount, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);

                    conn.Open();
                    var result = conn.Execute(sql, dp, commandType: System.Data.CommandType.Text);
                    return Task.FromResult(result.ToString());
                }
            }
            catch(Exception ex)
            {
                // Log error
                throw new Exception("Error inserting the data: " + ex.Message);
            }

        }
    }
}
