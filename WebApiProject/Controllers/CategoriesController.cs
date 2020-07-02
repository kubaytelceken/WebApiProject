using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using var context = new WebApiContext();
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound(); //404 not found
            }
            else
            {
                return Ok(category); //200 ok
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            using var context = new WebApiContext();
            var updatedCategory = context.Categories.Find(category.Id);
            if(updatedCategory == null)
            {
                return NotFound();
            }
            else
            {
                updatedCategory.Name = category.Name;
                context.Update(updatedCategory);
                context.SaveChanges();
                return NoContent();// update işlemi için kullanılan statuc code(204)
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var context = new WebApiContext();
            var deletedCategory = context.Categories.Find(id);
            if (deletedCategory == null)
            {
                return NotFound(); //404 not found
            }
            else
            {
                context.Remove(deletedCategory);
                context.SaveChanges();
                return NoContent();
            }
        }


        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            using var context = new WebApiContext();
            context.Categories.Add(category);
            context.SaveChanges();
            return Created("",category);
        }

        [HttpGet("{id}/blogs")]
        public IActionResult GetWithBlogsById(int id)
        {
            using var context = new WebApiContext();
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                var categoryWithBlogs = context.Categories.Where(I => I.Id == id).Include(I => I.Blogs).ToList();
                return Ok(categoryWithBlogs);
            }
        }

    }
}
