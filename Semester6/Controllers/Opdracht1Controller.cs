using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Semester6.Controllers
{
    public partial class Opdracht1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
