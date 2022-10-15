using Microsoft.AspNetCore.Mvc;
using AWork.Contracts.Dto.PersonModule.Login;

namespace AWork.Web.Controllers.PersonModule.Login
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
