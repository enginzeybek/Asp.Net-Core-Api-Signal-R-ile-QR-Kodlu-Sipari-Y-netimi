using Microsoft.AspNetCore.Mvc;

namespace SignalRWepUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
