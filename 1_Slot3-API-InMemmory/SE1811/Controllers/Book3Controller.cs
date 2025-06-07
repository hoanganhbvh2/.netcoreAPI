using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using SE1811.DAO;
using SE1811.model;

namespace SE1811.Controllers
{
    //[Route("odata/[controller]")]
    [Route("odata/Book3")]
    //[ApiController]
    public class Book3Controller :ODataController
    {
        private readonly ProductContext _context;

        public Book3Controller(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        //public IActionResult get()
        //public IActionResult get()
        public IActionResult Get(ODataQueryOptions<Book> options)
        {
            //Console.WriteLine("get method");
            //return Ok(_context.Book.AsQueryable());
            IQueryable<Book> entities = _context.Book;

            // Apply filtering, sorting, etc.
            IQueryable<Book> queryResult = options.ApplyTo(entities) as IQueryable<Book>;

            // To get the total count *before* pagination (skip/top)
            long totalCount = queryResult.LongCount(); // Or entities.LongCount() if count is desired before any filtering/sorting.
                                                       // Be careful here: if you want the count of filtered items, use queryResult.LongCount().

            // If you need to apply $top/$skip after getting the total count for paging
            var pagedResult = options.ApplyTo(entities, new ODataQuerySettings()) as IQueryable<Book>;

            // You might need to construct a custom response or use PageResult
            return Ok(new PageResult<Book>(pagedResult, null, totalCount));


        }
    }
}
