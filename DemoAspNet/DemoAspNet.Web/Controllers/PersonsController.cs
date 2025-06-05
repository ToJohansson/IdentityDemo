using DemoAspNet.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoAspNet.Web.Controllers;
public class PersonsController : Controller
{
    PersonService personService = new PersonService();

    [Route("")]
    public IActionResult Index()
    {
        var model = personService.GetAllPeople();
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult Delete(int id)
    {
        try
        {
            personService.DeletePersonByID(id);
            return RedirectToAction("/");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return RedirectToAction("/");
        }
    }
}

