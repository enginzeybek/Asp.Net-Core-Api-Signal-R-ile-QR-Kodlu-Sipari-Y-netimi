using Microsoft.AspNetCore.Mvc;

namespace SignalRWepUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
