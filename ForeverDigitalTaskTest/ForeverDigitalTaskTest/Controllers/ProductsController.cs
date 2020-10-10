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
                try
                {
                    return Ok(db.Products.ToList().Select(x => new ProductDto(x)));
                }
                catch (System.Exception)
                {
                    return Ok(new HttpError("Something went wrong"));
                }
            }
        }

        [HttpPost]
        public IHttpActionResult CreateOrder(OrderRequestDto orderRequest)
        {
            bool orderIsValid = false;
            if (orderRequest.quantity > 0)
                using (ForeverDigitalEntities db = new ForeverDigitalEntities())
                {
                    try
                    {
                        orderIsValid = db.Products.Any(x => x.product_id == orderRequest.product_id && x.stock_available >= orderRequest.quantity);
                    }
                    catch (System.Exception)
                    {
                        return Ok(new HttpError("Something went wrong"));
                    }
                }
            return Ok(new { IsOrderValid = orderIsValid });
        }
    }
}
