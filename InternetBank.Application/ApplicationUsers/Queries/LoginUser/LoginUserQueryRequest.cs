using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Application.ApplicationUsers.Exceptions;
using InternetBank.Application.ExternalServices.Jwt;


namespace InternetBank.Application.ApplicationUsers.Queries.LoginUser;

public record LoginUserQueryRequest(string UserName, string Email) : IRequest<JwtTokensResponse>;


