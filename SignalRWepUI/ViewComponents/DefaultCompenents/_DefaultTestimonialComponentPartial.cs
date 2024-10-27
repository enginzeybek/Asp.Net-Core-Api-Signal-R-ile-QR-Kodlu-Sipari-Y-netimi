using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWepUI.DTOs.SliderDTOs;
using SignalRWepUI.DTOs.TestimonialDTOs;
using System.Net.Http;

namespace SignalRWepUI.ViewComponents.DefaultCompenents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Testimonial");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
    }
}
