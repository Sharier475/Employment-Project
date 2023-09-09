using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Controllers;

public class CountryController : Controller
{
    private ICountryRepository _countryRepository;
    public CountryController(ICountryRepository countryRepository) => _countryRepository = countryRepository;
    public async Task<IActionResult> Index()=> View(await _countryRepository.GetAll());
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0) return View(new Country());
        else
        {
            var data = await _countryRepository.GetById(id);
            return View(data);
        }
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(Country country, int id)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //Save//
                await _countryRepository.Insert(country);
                return RedirectToAction(nameof(Index));
            }
            else
            {         //Update
                if (ModelState.IsValid)
                {
                    await _countryRepository.Update(id, country);
                    return RedirectToAction(nameof(Index));
                }
                return View(country);
            }
        }
        return View(new Country());
    }
    public async Task<ActionResult> Delete(int id)
    {
        await _countryRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
