using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.DTOs.BookingDTOs;
using System.Text;

namespace SignalRWepUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7277/api/Contact");
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.location = value;

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            HttpClient client2 = new HttpClient();
            HttpResponseMessage responseMessage2 = await client2.GetAsync("https://localhost:7277/api/Contact");
            responseMessage2.EnsureSuccessStatusCode();
            string responseBody = await responseMessage2.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.location = value;


            createBookingDto.Description = "Boş Geçildi!";

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createBookingDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8,
                "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7277/api/Booking",stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View();

            }

            

        }
    }
}
