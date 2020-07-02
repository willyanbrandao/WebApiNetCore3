using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;
using System.Linq;

namespace testeef.collection
{
    [ApiController]
    [Route("v1/products")]

    public class ProductController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var product = await context.Products.Include(x => x.Catergory).ToListAsync();
            return product;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id) 
        {
             var product = await context.Products.Include(x => x.Catergory).AsNoTracking().FirstOrDefaultAsync(x=>x.id == id);
            return product;    
        }

        [HttpGet]
        [Route("category/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id) 
        {
             var products = await context.Products
             .Include(x => x.Catergory)
             .AsNoTracking()
             .Where(x => x.CategoryId == id)
             .ToListAsync();
             
            return products;    
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody]Product model)
        {
                if (ModelState.IsValid){
                    context.Products.Add(model);
                    await context.SaveChangesAsync();
                    return model;

                }else{
                    return BadRequest(ModelState);
                }
        }
        
    }
}