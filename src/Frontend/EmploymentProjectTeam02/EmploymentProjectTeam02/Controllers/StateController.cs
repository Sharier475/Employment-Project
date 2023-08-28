using EmploymentProjectTeam02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Controllers;

public class StateController : Controller
{
   private readonly HttpClient _httpClient;
    public StateController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    }

    public async Task<List<State>> GetAllState()
    {

        var data = await _httpClient.GetFromJsonAsync<List<State>>("State");
        return data is not null ? data : new List<State>();
    }
    public async Task<IActionResult> Index()
    {
        var data = await GetAllState();
        return View(data);
    }

    

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
        {
            var countryresponse = await _httpClient.GetAsync("Country");
            if (countryresponse.IsSuccessStatusCode)
            {
                var content = await countryresponse.Content.ReadAsStringAsync();
                var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["countryId"] = new SelectList(stateList, "Id", "CountryName");
            }

            return View( new State());
        }
        else
        {
            var countryresponse = await _httpClient.GetAsync("Country");
            if (countryresponse.IsSuccessStatusCode)
            {
                var content = await countryresponse.Content.ReadAsStringAsync();
                var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["countryId"] = new SelectList(stateList, "Id", "CountryName");
            }

            var response = await _httpClient.GetAsync($"State/{id}");
            if (response.IsSuccessStatusCode)
            {
                var newData = await response.Content.ReadFromJsonAsync<State>();
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
    public async Task<IActionResult> AddorEdit(int id, State state)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save data
                var response = await _httpClient.PostAsJsonAsync("State", state);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the State.");
                    return View(state);
                }
            }
            else
            {
                //update Data
                if (id != state.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"State/{id}", state);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the State.");
                        return View(state);
                    }
                }
                return View(state);
            }
        }

        return View(new State());
    }

    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"State/{id}");
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
