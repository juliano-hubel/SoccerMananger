using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SoccerManager.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]        
        [Authorize(Roles = "User")]
        public string Get()
        {
            return "Hello World";
        }
    }
}