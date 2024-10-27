using Microsoft.AspNetCore.Mvc;

namespace SignalRWepUI.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult NotFound404Page()
		{
			return View();
		}
	}
}
