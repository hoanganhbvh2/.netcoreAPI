using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SE1811.DAO;

namespace SE1811.Controllers
{
    public class CountController: ControllerBase
    {
        private readonly ProductContext _context;

        public CountController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult get()
        {
            Console.WriteLine("get method");
            return Ok(_context.Book.AsQueryable());
        }

    }
}
