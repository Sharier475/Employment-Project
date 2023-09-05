using EmploymentProjectTeam02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Controllers;

public class CityController : Controller
{
    private readonly HttpClient _httpClient;

    public CityController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    }

    public async Task<List<City>> GetCityAll()
    {

        var data = await _httpClient.GetFromJsonAsync<List<City>>("City");
        return data is not null ? data : new List<City>();
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var listCity = await GetCityAll();
        return View(listCity);
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
                var stateList = JsonConvert.DeserializeObject<List<State>>(content);
                ViewData["StateId"] = new SelectList(stateList, "Id", "StateName");
            }
            return View(new City());
        }

        else
        {

            var response = await _httpClient.GetAsync("State");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var stateList = JsonConvert.DeserializeObject<List<State>>(content);
                ViewData["StateId"] = new SelectList(stateList, "Id", "StateName");
            }

            var Cityresponse = await _httpClient.GetAsync($"City/{id}");
            if (Cityresponse.IsSuccessStatusCode)
            {
                var departments = await Cityresponse.Content.ReadFromJsonAsync<City>();
                return View(departments);
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
                if (id != city.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"City/{id}", city);

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
