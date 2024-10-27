using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalR.DtoLayer.ContactDto;
using SignalRWepUI.DTOs.MessageDTOs;
using System.Text;

namespace SignalRWepUI.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
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

		[HttpGet]

		public async Task<PartialViewResult> SendMessage()
		{
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
            //ViewBag.location = values.Location;

            return PartialView();
		}

		[HttpPost]

		public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createMessageDto);
			StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7277/api/Message", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
				return RedirectToAction("Index","Default");
			}

			return View();
        }
	}
}
