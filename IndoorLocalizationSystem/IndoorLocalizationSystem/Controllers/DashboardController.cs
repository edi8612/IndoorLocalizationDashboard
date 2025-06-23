using IndoorLocalizationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace IndoorLocalizationSystem.Controllers
{
    public class DashboardController : Controller
    {
      private readonly HttpClient _httpClient;

      public DashboardController(IHttpClientFactory httpClientFactory)
      {
            _httpClient = httpClientFactory.CreateClient("api");
      }


      public async Task<IActionResult> Students()
      {
            var students = await _httpClient.GetFromJsonAsync<List<Student>>("api/student");
            return View(students);
      }


    }
}
