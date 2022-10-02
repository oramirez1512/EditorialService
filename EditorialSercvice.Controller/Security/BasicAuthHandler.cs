using EditorialService.BL.Domain.Model.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace EditorialService.Controller.Security
{
    public class BasicAuthHandler: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> optionsMonitor ,
                                ILoggerFactory logger, UrlEncoder urlEncoder,
                                ISystemClock systemClock,
                                IUserService userService): base(optionsMonitor, logger, urlEncoder, systemClock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization")) 
            {
                return AuthenticateResult.Fail("Please add Authorization header");
            }
            User result;
            try 
            {
                AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                byte[] credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                string[] credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                string username= credentials[0];
                string password= credentials[1];
                result = _userService.isUser(username,password);
            }
            catch 
            {
                return AuthenticateResult.Fail("Auth error, please try later");
            }
            if (result==null) 
            {
                return AuthenticateResult.Fail("User or password not found or incorrect");
            }
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,result.UserId.ToString()),
                new Claim(ClaimTypes.Name,result.UserName),
                new Claim("RoleId", result.RoleId.ToString())
            };
            var identity = new ClaimsIdentity(claims,Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
