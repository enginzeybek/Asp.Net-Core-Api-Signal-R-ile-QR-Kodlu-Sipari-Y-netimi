using Microsoft.AspNetCore.Mvc;

namespace SignalRWepUI.ViewComponents.DefaultCompenents
{
    public class _DefaultBookATableComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
