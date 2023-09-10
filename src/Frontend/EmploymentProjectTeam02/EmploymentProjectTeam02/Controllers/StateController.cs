using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using Microsoft.AspNetCore.Mvc;
namespace EmploymentProjectTeam02.Controllers;

public class StateController : Controller
{
  
   private readonly IStateRepository _stateRepository;
    private readonly ICountryRepository _countryRepository;
    public StateController(IStateRepository stateRepository, ICountryRepository countryRepository)
    {
        _stateRepository = stateRepository;
        _countryRepository = countryRepository;
    }

    public async Task<IActionResult> Index()=>View(await _stateRepository.GetAll());
   
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        ViewData["CountryId"] = await _countryRepository.Dropdown();
        if (id == 0) return View(new State());
        else
        {
            var response = await _stateRepository.GetById(id);
            if (response != null) return View(response);
        }
        return View(new State());
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
                if (ModelState.IsValid)
                {
                    await _stateRepository.Insert(state);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                //UPDATE//
                if (ModelState.IsValid)
                {
                    await _stateRepository.Update(id, state);
                    return RedirectToAction(nameof(Index));
                }
                return View(state);
            }
        }

        return View(new State());
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _stateRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
