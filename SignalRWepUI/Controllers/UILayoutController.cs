using Microsoft.AspNetCore.Mvc;

namespace SignalRWepUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
