using Microsoft.AspNetCore.Mvc;
using NZWalksUI.Models.DTO;
using System.Text;
using System.Text.Json;

namespace NZWalksUI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            //Surround try Catch we use CTRL+K+S
            try
            {
                //Get All Regions From The Web API
                var client = httpClientFactory.CreateClient();
                var httpResponseMeassage = await client.GetAsync("https://localhost:7236/api/Region");
                httpResponseMeassage.EnsureSuccessStatusCode();
                response.AddRange(await httpResponseMeassage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());
            }
            catch (Exception ex)
            {
                //Log the Exception
               
            }
            return View(response);
        }

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		} 
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMeassage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7236/api/regions"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };
            var httpResponseMeassage = await client.SendAsync(httpRequestMeassage);
            httpResponseMeassage.EnsureSuccessStatusCode();

             var response=await httpResponseMeassage.Content.ReadFromJsonAsync<RegionDto>();
            if (response is not null)
            {
                return RedirectToAction("Index", "Regions");
            }
            return View();
        }
    }
}
