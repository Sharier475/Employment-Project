using EmploymentProjectTeam02.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HttpClient _httpClient;

        public DepartmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EmployeeApi");
        }

        public async Task<List<Department>> GetAllDepartment()
        {
            var data = await _httpClient.GetFromJsonAsync<List<Department>>("Department");
            return data is not null ? data : new List<Department>();
        }
        public async Task<IActionResult> Index()
        {
           var data= await GetAllDepartment();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> AddorEdit(int id)
        {
            if (id == 0)
            {
                return View(new Department());
            }
            else
            {
                var response = await _httpClient.GetAsync($"Department/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var departments = await response.Content.ReadFromJsonAsync<Department>();
                    return View(departments);
                }
                else
                {
                    return NotFound();
                }
            }
           
        }


        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit( Department department,int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    //save//
                    var data = await _httpClient.PostAsJsonAsync("Department", department);
                    if (data.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error While Saving Data");
                    }
                }
                else
                {
                    //update//
                    if (id != department.Id)
                    {
                        return BadRequest();
                    }
                    if (ModelState.IsValid)
                    {
                        var response = await _httpClient.PutAsJsonAsync($"Department/{id}", department);

                        if (response.IsSuccessStatusCode)
                        {

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Failed to update the Department.");
                            return View(department);
                        }
                    }
                    return View(department);
                }
            }

            return View(new Department());
        }
       
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Department/{id}");
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
