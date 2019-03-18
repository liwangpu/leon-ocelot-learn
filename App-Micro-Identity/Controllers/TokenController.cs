using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_Micro_Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Micro_Identity.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        [HttpPost]
        public IActionResult Request(TokenRequestModel model)
        {

            return Ok();
        }
    }
}