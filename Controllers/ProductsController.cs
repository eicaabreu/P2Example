using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2Example.Data;

namespace P2Example.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly P2DbContext _p2DbContext;

        public ProductsController(P2DbContext p2DbContext)
        {
            _p2DbContext = p2DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            var result = await _p2DbContext.products.ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProductById(long id)
        {
            var result = _p2DbContext.products.FindAsync(id);
            return Ok(result.Result);
        }

        [HttpPost ]
        public async Task<ActionResult<Products>>  InsertProduct(Products products)
        {
            _p2DbContext.products.Add(products);
            await _p2DbContext.SaveChangesAsync();

            return Ok("Datos Guardados Correctamente");
        }
    }
}
