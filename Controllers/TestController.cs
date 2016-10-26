using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InterviewApplication.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            return View("~/Views/Index.html");
        }
        
    }
}
