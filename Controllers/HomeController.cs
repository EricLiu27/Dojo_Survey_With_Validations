using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey_With_Validations.Models;

namespace Dojo_Survey_With_Validations.Controllers;

public class HomeController : Controller
{

    public static Survey survey = new();

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("submit")]
    public IActionResult Submit(Survey submits)
    {
        if (ModelState.IsValid)
        {
            survey.Name = submits.Name;
            survey.Location = submits.Location;
            survey.Language = submits.Language;
            survey.Comment = submits.Comment;
            return RedirectToAction("Display");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("display")]
    public IActionResult Display()
    {
        return View("Display", survey);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
