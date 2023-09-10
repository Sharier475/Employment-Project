using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Controllers;

public class DepartmentController : Controller
{
    private IDepartmentRepository  _departmentRepository;
    public DepartmentController(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;
    public async Task<IActionResult> Index()=> View(await _departmentRepository.GetAll());
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0) return View(new Department());
        else
        {
            var data = await _departmentRepository.GetById(id);
            return View(data);
        }
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(Department department , int id)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                await _departmentRepository.Insert(department);
                return RedirectToAction("Index");
            }
            else
            {      
                if (ModelState.IsValid)
                {
                    await _departmentRepository.Update(id, department);
                    return RedirectToAction("Index");
                }
                return View(department);
            }
        }
        return View(new Department());
    }
    public async Task<ActionResult> Delete(int id)
    {
        await _departmentRepository.Delete(id);
        return RedirectToAction("Index");
    }
}
