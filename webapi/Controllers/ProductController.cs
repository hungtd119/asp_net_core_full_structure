using Microsoft.AspNetCore.Mvc;
using webapi.Dtos.Common;
using webapi.Dtos.Product;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("get-product-by-params")]
        public IActionResult GetProductByParams([FromQuery] ProductFilterDto input)
        {
            try
            {
                return Ok(_productService.GetAll(input));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] CreateProductDto input)
        {
            try
            {
                _productService.CreateProduct(input);
                return Ok(new
                {
                    message = "Tạo sản phẩm thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("update-product")]
        public IActionResult updateProduct([FromBody] UpdateProductDto input)
        {
            try
            {
                _productService.UpdateProduct(input);
                return Ok(new
                {
                    message = "Cập nhật sản phẩm thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok(new
                {
                    message = "Xóa sản phẩm thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                });
            }
        }
    }
}
