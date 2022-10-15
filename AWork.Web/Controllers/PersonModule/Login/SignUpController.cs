using Microsoft.AspNetCore.Mvc;

namespace AWork.Web.Controllers.PersonModule.Login
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
