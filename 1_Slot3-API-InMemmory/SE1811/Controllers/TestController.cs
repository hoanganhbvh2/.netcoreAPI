using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SE1811.DAO;
using SE1811.model;

namespace SE1811.Controllers
{
    public class TestController : Controller
    {

        ProductContext _context;


        public TestController(ProductContext context)
            {
                _context = context;
            }

            [HttpGet]
            [EnableQuery]
            public IQueryable<Product> Get()
            {
                return _context.Products;
            }

    }
}
