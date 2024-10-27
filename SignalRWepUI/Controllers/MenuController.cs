using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWepUI.DTOs.BasketDTOs;
using SignalRWepUI.DTOs.ProductDTOs;
using System.Net.Http;

namespace SignalRWepUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            // id = int.Parse(TempData["customerSelectedTable"].ToString());

            ViewBag.v = id; // Burada MenuTableId değerini ayarlıyoruz.
            // TempData["x"] = id; // Eğer bunu kullanırsakda alternatif.


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7277/api/Product/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id,int menuTableId)
        {
            if (menuTableId == 0)
            {
                return BadRequest("MenuTableId 0(sıfır) geliyor.");
            }

            CreateBasketDTO createBasketDTO = new CreateBasketDTO
            {
                ProductID = id,
                MenuTableID = menuTableId // Gelen menuTableId burada kullanılıyor.
            };


            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createBasketDTO);

            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7277/api/Basket", stringContent);



            var client2 = _httpClientFactory.CreateClient();

            await client2.GetAsync("https://localhost:7277/api/MenuTables/ChangeMenuTableStatusToTrue?id=" + menuTableId);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Json(createBasketDTO);
        }




    }
}
