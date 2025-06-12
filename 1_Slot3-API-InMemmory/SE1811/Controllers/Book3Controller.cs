using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SE1811.DAO;
using SE1811.model;

namespace SE1811.Controllers
{
    //[Route("odata/[controller]")]
    //[Route("odata/book3")]
    [Route("api/[controller]")]
    [ApiController]
    public class Book3Controller :ODataController
    {
        private readonly ProductContext _context;

        public Book3Controller(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        //public IQueryable<Book> GetAll()
        //{

        //    return _context.Book;
        //}
        public IActionResult Get()
        {

            return Ok(_context.Book);
        }

    }
}
