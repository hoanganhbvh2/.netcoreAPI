using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SE1811.DAO;
using SE1811.model;

namespace SE1811.Controllers
{
    [Route("api/[controller]")]
    //[Produces("application/json")]
    [ApiController]
    public class Book2Controller : Controller
    {
        private readonly ProductContext _context;

        public Book2Controller(ProductContext context)
        {
            _context = context;
        }
        [HttpGet]
        [EnableQuery]
        public IQueryable<Book> get()
        {
            return _context.Book;
        }
    }
}
