using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PercobaanApi1.Models;

namespace PercobaanAPI1.Controllers
{
    public class PersonController : Controller
    {
        private string __constr;

        public PersonController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("webApiDatabase");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/person"), Authorize]

        public ActionResult<Person> ListPerson()
        {
            PersonContext contex = new PersonContext (this.__constr);
            List<Person> ListPerson = contex.ListPerson();
            return Ok(ListPerson);
        }



        [HttpPost("api/person/create"), Authorize]
        public ActionResult AddPerson(Person person)
        {
            try
            {
                PersonContext context = new PersonContext(__constr);
                context.AddPerson(person);
                return Ok("Berhasil menambahkan data");
            }
            catch (Exception ex)
            {
                return BadRequest("Gagal menambahkan data: " + ex.Message);
            }
        }


        [HttpPatch("api/person/update/{id_person}"), Authorize]
        public ActionResult UpdatePerson(int id_person, Person person)
        {
            try
            {
                PersonContext context = new PersonContext(__constr);
                context.UpdatePerson(id_person, person);
                return Ok("Berhasil Mengubah Data {id_person}");
            }
            catch
            {
                return BadRequest("Gagal Mengubah Data");
            }
        }


        [HttpDelete("api/person/delete/{id_person}"), Authorize]
        public ActionResult DeletePerson(int id_person)
        {
            try
            {
                PersonContext context = new PersonContext(__constr);
                context.DeletePerson(id_person);
                return Ok("Data Berhasil Dihapus");
            }
            catch
            {
                return BadRequest();
            }
        }




    }
}
