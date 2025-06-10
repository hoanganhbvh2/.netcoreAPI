using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Elfie.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using SE1811.DAO;
using SE1811.model;

namespace SE1811.Controllers
{
    //[Produces("application/xml")]
    [Route("api/[controller]")]
    [EnableQuery]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Products
        //[Route("a")]

        [HttpGet("about")]
        [EnableQuery]
        public String About()
        {
            return ("day la about");
        }
        //[Produces("application/xml")]
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //public IQueryable get()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p =>
                new DtoProductcs
                {
                    ProductID = p.ProductID,
                    NameProduct = p.NameProduct,
                    DescriptionProduct = p.DescriptionProduct,
                    Price = p.Price,
                    CategoryID = p.CategoryID,
                    CategoryName = p.Category.CategoryName,
                    Cate_Description = p.Category.Description
                }).ToListAsync();
            //return _context.Products;
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var exit = await _context.Categories.FindAsync(product.CategoryID);
            if (exit == null)
            {
                return BadRequest("khong thay id");
            }
            else
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
