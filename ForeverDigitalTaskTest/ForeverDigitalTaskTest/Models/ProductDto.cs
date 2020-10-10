using ForeverDigitalTaskTest.DB;

namespace ForeverDigitalTaskTest.Models
{
    public class ProductDto
    {
        public int id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }

        public ProductDto(Product product)
        {
            id = product.id;
            product_id = product.product_id;
            product_name = product.product_name;
        }
    }
}