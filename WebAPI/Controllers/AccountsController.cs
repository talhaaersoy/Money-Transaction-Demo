using Business.Abstract;
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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("createaccount")]
        public IActionResult CreateAccount(CreateAccountDto account)
        {
            var result = _accountService.Add(account);
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _accountService.GetAll();
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
