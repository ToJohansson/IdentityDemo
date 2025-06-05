using EmpoyeesApp.Web.Models;
using EmpoyeesApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmpoyeesApp.Web.Controllers;
public class EmployeesController : Controller
{
    public static EmployeeService service = new EmployeeService();
    [HttpGet("")]
    public IActionResult Index()
    {
        var model = service.GetAllEmployees();
        return View(model);
    }
    [HttpGet("/add")]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost("/add")]
    public IActionResult Add(Employee employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }

        var success = service.AddEmployee(employee);
        if (!success)
        {
            TempData["ErrorMessage"] = "Email already exists!";
            return View(employee);
        }
        service.AddEmployee(employee);
        TempData["SuccessMessage"] = "Employee added successfully!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("/delete/{id:int}")]
    public IActionResult Delete(int id)
    {
        service.DeleteEmployee(id);
        return RedirectToAction(nameof(Index));
    }
}
