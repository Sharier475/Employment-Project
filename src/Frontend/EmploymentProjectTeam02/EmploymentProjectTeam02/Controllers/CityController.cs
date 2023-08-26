using EmploymentProjectTeam02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Controllers
{
    public class CityController : Controller
    {
        private readonly HttpClient _httpClient;
        public CityController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7100/api/");
        }

        public async Task<List<City>> GetAllCity()
        {
            var data = await _httpClient.GetAsync("City");
            if (data.IsSuccessStatusCode)
            {
                var newData = await data.Content.ReadAsStringAsync();
                var listCity= JsonConvert.DeserializeObject<List<City>>(newData);
                return listCity;
            }
            return new List<City>();
        }
        public async Task<IActionResult> Index()
        {
            var data = await GetAllCity();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> AddorEdit(int id)
        {
            if (id == 0)
            {
                var response = await _httpClient.GetAsync("State");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var citylist = JsonConvert.DeserializeObject<List<State>>(content);
                    ViewData["stateId"] = new SelectList(citylist, "id", "stateName");
                }
                return View(new State());
            }
            else
            {
                var data = await _httpClient.GetAsync("State");
                if (data.IsSuccessStatusCode)
                {
                    var content = await data.Content.ReadAsStringAsync();
                    var citylist = JsonConvert.DeserializeObject<List<State>>(content);
                    ViewData["stateId"] = new SelectList(citylist, "id", "stateName");
                }
                var response = await _httpClient.GetAsync($"City/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var newData = await response.Content.ReadFromJsonAsync<City>();
                    return View(newData);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit(int id, City city)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    //save data
                    var response = await _httpClient.PostAsJsonAsync("City", city);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to create the City.");
                        return View(city);
                    }
                }
                else
                {
                    //update Data
                    if (id != city.id)
                    {
                        return BadRequest();
                    }
                    if (ModelState.IsValid)
                    {
                        var response = await _httpClient.PutAsJsonAsync($"State/{id}", city);

                        if (response.IsSuccessStatusCode)
                        {

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Failed to update the City.");
                            return View(city);
                        }
                    }
                    return View(city);
                }
            }

            return View(new City());
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"City/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
