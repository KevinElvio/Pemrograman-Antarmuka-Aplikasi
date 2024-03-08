using Microsoft.AspNetCore.Mvc;
using PercobaanApi1.Models;

namespace PercobaanAPI1.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("api/person")]
        public ActionResult<Person> ListPerson()
        {
            PersonContext context = new PersonContext();
            List<Person> ListPerson = context.ListPerson(); return Ok(ListPerson);
        }

        [HttpGet("api/person/{id}")]
        public IActionResult GetPerson(int id)
        {
            PersonContext context = new PersonContext();
            Person idPerson = context.GetPerson(id);

            if (idPerson != null)
            {
                return Ok(idPerson);
            }
            else
            {
                return NotFound();
            }

        }


    }
}
