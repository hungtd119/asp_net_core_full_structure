using webapi.Dtos.Common;

namespace webapi.Dtos.Product
{
    public class ProductFilterDto : FilterDto
    {
        public float? Price { get; set; }
    }
}
