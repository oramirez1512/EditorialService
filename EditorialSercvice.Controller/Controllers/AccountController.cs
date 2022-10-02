using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EditorialService.Controller.Controllers
{
    [Authorize]
    public class AccountController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost(Name ="Login")]
        public ActionResult Login()
        {
            return null;
        }

        [HttpPost(Name = "Logout")]
        public ActionResult Logout()
        {
            return null;
        }
    }
}
