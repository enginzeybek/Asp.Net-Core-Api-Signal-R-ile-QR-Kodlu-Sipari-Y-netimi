using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWepUI.DTOs.RapidApiDTOs;

namespace SignalRWepUI.Controllers
{
    public class FoodRapidApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=40&tags=under_30_minutes"),
                Headers =
    {
        { "x-rapidapi-key", "b03ad38c4amsh6b9416dc2d5b146p19871bjsn5af45ae4b52c" },
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
                var values = root.Results;
                return View(values.ToList());
                //var values = JsonConvert.DeserializeObject<List<ResultTastyApi>>(body);
                //return View(values);
                // Console.WriteLine(body);
            }

           
        }
    }
}
