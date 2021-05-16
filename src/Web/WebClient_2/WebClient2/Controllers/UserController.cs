using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient2.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> SignOutAsync()
        {
            return new SignOutResult(new[] { "oidc", "Cookies" });

        }
    }
}
