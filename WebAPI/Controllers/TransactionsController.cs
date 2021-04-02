using Business.Abstract;
using Entities.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transaction;

        public TransactionsController(ITransactionService transaction)
        {
            _transaction = transaction;
        }

        [HttpPost("createtransaction")]
        public IActionResult CreateMoneyTransaction(TransactionDto transaction)
        {
            var result = _transaction.Add(transaction);
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _transaction.GetAll();
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
