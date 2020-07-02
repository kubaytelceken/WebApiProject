using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DAL.Context;
using WebApiProject.DAL.Entities;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            using var context = new WebApiContext();
            return Ok(context.Categories.ToList());
        }
    }
}
