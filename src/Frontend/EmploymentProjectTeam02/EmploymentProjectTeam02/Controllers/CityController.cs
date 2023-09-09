using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using Microsoft.AspNetCore.Mvc;
namespace EmploymentProjectTeam02.Controllers;

public class CityController : Controller
{

    private readonly ICityRepository _cityRepository;
    private readonly IStateRepository _stateRepository;
    public CityController(ICityRepository cityRepository, IStateRepository stateRepository)
    {
        _cityRepository = cityRepository;
        _stateRepository = stateRepository;
    }
    public async Task<IActionResult> Index()=>View(await _cityRepository.GetAll());
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        ViewData["stateId"] = await _stateRepository.Dropdown();
        if (id == 0) return View(new City());
        else
        {
            var response = await _cityRepository.GetById(id);
            if (response != null) return View(response);
        }
        return View(new State());
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
                if (ModelState.IsValid)
                {
                    await _cityRepository.Insert(city);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                //UPDATE//
                if (ModelState.IsValid)
                {
                    await _cityRepository.Update(id, city);
                    return RedirectToAction(nameof(Index));
                }
                return View(city);
            }
        }
        return View(new City());
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _cityRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
