using Microsoft.AspNetCore.Mvc;

namespace SignalRWepUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
