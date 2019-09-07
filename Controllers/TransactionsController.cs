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
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<IEnumerable<Transaction>> Get()
        {
            return await _transactionRepository.GetAll();
        }

        // GET: api/Transactions/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Transaction>> Get(int id)
        {
            Transaction tran = await _transactionRepository.GetById(id);
            if (tran == null)
            {
                return NotFound("Transaction not found for the provided id.");
            }
            return tran;
        }

        // POST: api/Transactions
        [HttpPost]
        public ActionResult Post([FromBody] Transaction transaction)
        {
            if (transaction.UserId == 0 || transaction.TransType == null || transaction.Description == null || transaction.Amount == 0)
            {
                return StatusCode(400, "Error: Missing required field(s)");
            }

            try
            {
                var result = _transactionRepository.Save(transaction);
                return StatusCode(201, "Created");
                // return CreatedAtAction("Save", new { Status = "Success" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error Saving recored. " + ex.Message);
            }

        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
