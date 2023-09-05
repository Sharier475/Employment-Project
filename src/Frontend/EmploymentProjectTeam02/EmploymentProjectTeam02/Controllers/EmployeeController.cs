using EmploymentProjectTeam02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Controllers;

public class EmployeeController : Controller
{
   private readonly HttpClient _httpClient;

    public EmployeeController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    }
    public async Task<List<Employee>> GetAllEmployee()
    {
        var data = await _httpClient.GetFromJsonAsync<List<Employee>>("Employee");
        return data is not null ? data : new List<Employee>();
    }
    public async Task<IActionResult> Index()
    {
        var employee = await GetAllEmployee();
        return View(employee);
    }

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        var response = await _httpClient.GetAsync("State");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<State>>(content);
            ViewData["StateId"] = new SelectList(stateList, "Id", "StateName");


        }
        var countryresponse = await _httpClient.GetAsync("Country");
        if (countryresponse.IsSuccessStatusCode)
        {
            var content = await countryresponse.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
            ViewData["countryId"] = new SelectList(stateList, "Id", "CountryName");
        }

        var deptresponse = await _httpClient.GetAsync("Department");

        if (deptresponse.IsSuccessStatusCode)
        {
            var content = await deptresponse.Content.ReadAsStringAsync();
            var departments = JsonConvert.DeserializeObject<List<Department>>(content);
            ViewData["DeptId"] = new SelectList(departments, "Id", "DepartmentName");

        }
        var cityresponse = await _httpClient.GetAsync("City");
        if (cityresponse.IsSuccessStatusCode)
        {
            var content = await cityresponse.Content.ReadAsStringAsync();
            var citylist = JsonConvert.DeserializeObject<List<City>>(content);
            ViewData["CityId"] = new SelectList(citylist, "Id", "CityName");

        }
        if (id == 0)
        {
            


            return View(new Employee());
        }

        else
        {
            //var stateResponse = await _httpClient.GetAsync("State");

            //if (stateResponse.IsSuccessStatusCode)
            //{
            //    var content = await stateResponse.Content.ReadAsStringAsync();
            //    var stateList = JsonConvert.DeserializeObject<List<State>>(content);
            //    ViewData["StateId"] = new SelectList(stateList, "Id", "StateName");
            //}
            //var countryresponse = await _httpClient.GetAsync("Country");
            //if (countryresponse.IsSuccessStatusCode)
            //{
            //    var content = await countryresponse.Content.ReadAsStringAsync();
            //    var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
            //    ViewData["countryId"] = new SelectList(stateList, "Id", "CountryName");
            //}

            //var deptresponse = await _httpClient.GetAsync("Department");

            //if (deptresponse.IsSuccessStatusCode)
            //{
            //    var content = await deptresponse.Content.ReadAsStringAsync();
            //    var departments = JsonConvert.DeserializeObject<List<Department>>(content);
            //    ViewData["DeptId"] = new SelectList(departments, "Id", "DepartmentName");

            //}
            //var cityresponse = await _httpClient.GetAsync("City");
            //if (cityresponse.IsSuccessStatusCode)
            //{
            //    var content = await cityresponse.Content.ReadAsStringAsync();
            //    var citylist = JsonConvert.DeserializeObject<List<City>>(content);
            //    ViewData["CityId"] = new SelectList(citylist, "Id", "CityName");

            //}


            var Cityresponse = await _httpClient.GetAsync($"Employee/{id}");
            if (Cityresponse.IsSuccessStatusCode)
            {
                
                var content = await Cityresponse.Content.ReadAsStringAsync();
                var citylist = JsonConvert.DeserializeObject<Employee>(content);
                return View(citylist);
            }
            else
            {
                return NotFound();
            }
        }
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, Employee employee, IFormFile pictureFile)
    {
        if (ModelState.IsValid)
        {
            //Save
            if (id == 0)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    employee.Picture = $"{pictureFile.FileName}";
                }
                var response = await _httpClient.PostAsJsonAsync("Employee", employee);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the country.");
                    return View(employee);
                }
            }
            //update Data
            else
            {

                if (id != employee.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employee.Picture = $"{pictureFile.FileName}";
                    }
                    var response = await _httpClient.PutAsJsonAsync($"Employee/{id}", employee);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the Employee.");
                        return View(employee);
                    }
                }
                return View(employee);
            }
        }

        return View(new Employee());
    }

    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"Employee/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
    public async Task<ActionResult> StateDropdownData(int countryId)
    {
        var response = await _httpClient.GetAsync("State");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<State>>(content);
            List<State> filteredStates = stateList.Where(state => state.CountryId == countryId).ToList();
            return Json(filteredStates);
        }
        return NotFound();
    }


    public async Task<ActionResult> CityDropdownData(int stateId)
    {
        var response = await _httpClient.GetAsync("City");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var CityList = JsonConvert.DeserializeObject<List<City>>(content);
            List<City> filteredStates = CityList.Where(state => state.StateId == stateId).ToList();
            return Json(filteredStates);
        }
        return NotFound();
    }


}
