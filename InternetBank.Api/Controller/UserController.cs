using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Application.ApplicationUsers.Commands.SignUp;
using InternetBank.Application.ApplicationUsers.Facade;
using InternetBank.Application.ApplicationUsers.Queries.LoginUser;
using InternetBank.Domain.ApplicationUser.Users.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Internet_Bank_Clean.Controller.Users
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController (ISender sender): ControllerBase
    {
        private readonly ISender _sender = sender;


        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] SignUpCommand request)
        {
            var result = await _sender.Send(request);
            if (result.Succeeded)
            {
                return Ok("ثبت نام شما با موفقیت انجام شد!");
            }
            return BadRequest(result.Errors.Select(x => x.Description));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserQueryRequest request)
        {
            var result = await _sender.Send(request);

            return Ok(result);
        }
    }
}