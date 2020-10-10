using ForeverDigitalTaskTest.DB;
using ForeverDigitalTaskTest.Models;
using System.Linq;
using System.Web.Http;

namespace ForeverDigitalTaskTest.Controllers
{
    public class ProductsController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (ForeverDigitalEntities db = new ForeverDigitalEntities())
            {
                return Ok(db.Products.ToList().Select(x => new ProductDto(x)));
            }
        }
    }
}
