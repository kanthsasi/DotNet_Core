using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    //http://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET: http://localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudets()
        {
            string[] studentsNames = new string[] {"John","Jane","Mark","Emily","David" };
            return Ok(studentsNames);
        }
    }
}
