using Microsoft.AspNetCore.Mvc;
using PercobaanApi1.Models;

namespace PercobaanAPI1.Controllers
{
    public class AddController : Controller
    {
        private string __constr;

        public AddController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("webApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
