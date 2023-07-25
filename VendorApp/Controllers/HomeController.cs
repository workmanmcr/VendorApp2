using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VendorApp.Models;

namespace VendorApp.Controllers;

public class HomeController : Controller
{
     [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
    