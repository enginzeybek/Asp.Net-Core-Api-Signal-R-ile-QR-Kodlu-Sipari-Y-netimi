using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWepUI.DTOs.ProductDTOs;
using SignalRWepUI.DTOs.SliderDTOs;
using System.Net.Http;

namespace SignalRWepUI.ViewComponents.DefaultCompenents
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Product/GetLast9Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
            return View(values);
        }

    }
}
