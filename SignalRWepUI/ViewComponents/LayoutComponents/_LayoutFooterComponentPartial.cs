using Microsoft.AspNetCore.Mvc;

namespace SignalRWepUI.ViewComponents.LayoutComponents
{
	public class _LayoutFooterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
