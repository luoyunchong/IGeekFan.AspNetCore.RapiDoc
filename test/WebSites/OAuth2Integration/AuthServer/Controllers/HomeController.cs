using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth2Integration.AuthServer.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService identity;
        public HomeController(IIdentityServerInteractionService identity)
        {
            this.identity = identity;
        }

        [HttpGet("error")]
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await identity.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
            }
            ViewBag.VM = vm;
            return View("/AuthServer/Views/Error.cshtml", vm);
        }
    }

    public class ErrorViewModel
    {
        public ErrorMessage Error { get; set; }
    }
}
