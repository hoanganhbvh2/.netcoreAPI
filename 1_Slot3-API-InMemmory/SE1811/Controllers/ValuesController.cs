using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace SE1811.Controllers
{
    [Route("api/[controller]")]
    [EnableQuery]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("/get")]

        public String get()
        {
            return "method GET";
        }
        [HttpGet]
        [Route("index")]
        [Route("index2")]
        public String index()
        {
            return "method GET2";
        }


    }
}
