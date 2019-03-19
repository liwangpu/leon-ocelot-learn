using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App_Micro_A.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var name = User.Identity.Name;
            string authorizationStr = Request.Headers["Authorization"];


            return new string[] { "value1", "value2" };
        }
    }
}
