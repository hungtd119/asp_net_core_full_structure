using webapi.Dtos.Common;
using webapi.Dtos.Product;

namespace webapi.Services.Interfaces
{
    public interface IProductService {
        void CreateProduct(CreateProductDto input);
        void UpdateProduct(UpdateProductDto input);
        void DeleteProduct(int id);
        PageResultDto<ProductDto> GetAll(ProductFilterDto input);
    }
}
