using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EmploymentProjectTeam02.Controllers;

public class EmployeeController : Controller
{
    private readonly ICityRepository _cityRepository;
    private readonly IStateRepository _stateRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly HttpClient _httpClient;

    public EmployeeController(IHttpClientFactory httpClientFactory, ICityRepository cityRepository, IStateRepository stateRepository, IEmployeeRepository employeeRepository, ICountryRepository countryRepository, IDepartmentRepository departmentRepository)
    {
        _cityRepository = cityRepository;
        _stateRepository = stateRepository;
        _employeeRepository = employeeRepository;
        _countryRepository = countryRepository;
        _departmentRepository = departmentRepository;
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    }

    public async Task<IActionResult> Index()=>View(await _employeeRepository.GetAll());
    
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        ViewData["stateId"] = await _stateRepository.Dropdown();
        ViewData["cityId"] = await _cityRepository.Dropdown();
        ViewData["countryId"] = await _countryRepository.Dropdown();
        ViewData["departmentId"] = await _departmentRepository.Dropdown();
        if (id == 0) return View(new Employee());
        else
        {
            var response = await _employeeRepository.GetById(id);
            if (response != null) return View(response);
        }
        return View(new Employee());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, [FromForm] Employee employee )
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                

                //save data
                if (ModelState.IsValid)
                {
                    _employeeRepository.Create(employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                //UPDATE//
                if (ModelState.IsValid)
                {
                    await _employeeRepository.Update(id, employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
        }
        return View(new Employee());
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _employeeRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
