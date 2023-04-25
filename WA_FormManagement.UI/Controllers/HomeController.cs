using Microsoft.AspNetCore.Mvc;

namespace WA_FormManagement.UI.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
