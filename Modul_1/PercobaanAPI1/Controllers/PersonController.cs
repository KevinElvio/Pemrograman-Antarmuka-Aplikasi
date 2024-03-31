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

        [HttpGet("api/murid")]

        public ActionResult<Murid> ListPerson()
        {
            PersonContext context = new PersonContext(this.__constr);
            List<Murid> ListPerson = context.ListPerson();
            return Ok(ListPerson);
        }


        [HttpPost("api/murid/create")]
        public ActionResult AddMurid(Murid person)
        {
            try
            {
                PersonContext context = new PersonContext(__constr);
                context.AddMurid(person);
                return Ok("Berhasil menambahkan data");
            }
            catch (Exception ex)
            {
                return BadRequest("Gagal menambahkan data: " + ex.Message);
            }
        }



        [HttpPatch("api/murid/update/{id_murid}")]
        public ActionResult UpdateMurid(int id_murid, Murid person)
        {
            try
            {
                PersonContext context = new PersonContext(__constr);
                context.UpdateMurid(id_murid, person);
                return Ok("Berhasil Mengubah Data {id_murid}");
            }
            catch
            {
                return BadRequest("Gagal Mengubah Data");
            }
        }


        [HttpDelete("api/murid/delete/{id_murid}")]   
        public ActionResult DeleteMurid(int id_murid)
        {
            try
            {
                PersonContext context = new PersonContext(__constr);
                context.DeleteMurid(id_murid);
                return Ok("Data Berhasil Dihapus");
            }
            catch
            {
                return BadRequest();
            }
        }




    }
}
