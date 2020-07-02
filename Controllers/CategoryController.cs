using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;

namespace testeef.collection
{
    [ApiController]
    [Route("v1/category")]

    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Category.ToListAsync();
            return categories;
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById([FromServices] DataContext context, int id) 
        {
             var Category = await context.Category
             .AsNoTracking().FirstOrDefaultAsync(x=>x.id == id);
            return Category;    
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
                if (ModelState.IsValid){
                    context.Category.Add(model);
                    await context.SaveChangesAsync();
                    return model;

                }else{
                    return BadRequest(ModelState);
                }
        }
        
    }
}
