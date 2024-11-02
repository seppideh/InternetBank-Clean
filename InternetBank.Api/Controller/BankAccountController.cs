using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InternetBank.Application.BankAccounts.Commands.OpenAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Internet_Bank_Clean.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class BankAccountController (ISender sender): ControllerBase
    {
        private readonly ISender _sender = sender;

        public int UserId
        {
            get
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdString))
                {
                    throw new UnauthorizedAccessException("User ID not found in token.");
                }

                return int.Parse(userIdString);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OpenAccount([FromBody] OpenAccountCommandRequest request)
        {
            request.UserId=UserId;
            var account=await _sender.Send(request);
            return Ok(account);
        }


    }
}