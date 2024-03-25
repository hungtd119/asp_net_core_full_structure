using webapi.DbContexts;
using webapi.Dtos.Common;
using webapi.Dtos.Product;
using webapi.Entities;
using webapi.Services.Interfaces;

namespace webapi.Services.Implements
{
    public class ProductService : IProductService
    {
        private ApplicationContext _applicationContext;
        public ProductService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void CreateProduct(CreateProductDto input)
        {
            _applicationContext.Add(new Product
            {
                Name = "Iphone 15 pro max",
                Description = "Blue Saphia",
                Price = 15.9f
            });
            _applicationContext.SaveChanges();
        }

        public void UpdateProduct(UpdateProductDto input)
        {
            var product = _applicationContext.Products.FirstOrDefault(p => p.Id == input.Id);
            if (product == null)
            {
                throw new Exception("Không tìm thấy sản phẩm");
            }
            product.Name = input.Name;
            product.Description = input.Description;
            product.Price = input.Price;
            _applicationContext.SaveChanges();
        }
        public void DeleteProduct(int Id)
        {
            var product = _applicationContext.Products.FirstOrDefault(p => p.Id == Id);
            if (product == null)
            {
                throw new Exception("Không tìm thấy sản phẩm");
            }
            _applicationContext.Products.Remove(product);
            _applicationContext.SaveChanges();
        }

        public PageResultDto<ProductDto> GetAll(ProductFilterDto input)
        {
            var result = new PageResultDto<ProductDto>();
            var query = _applicationContext.Products
                .Where(p => p.Name.Contains(input.Keyword))
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                });
            /*
            var query2 = from user in _dbContext.Users
                         where user.Username.Contains(input.Keyword)
                            && (input.StartDate == null || user.CreatedDate >= input.StartDate)
                            && (input.EndDate == null || user.CreatedDate <= input.EndDate)
                         select new UserDto
                         {
                             Id = user.Id,
                             UserName = user.Username,
                             Email = user.Email,
                             CreatedDate = user.CreatedDate
                         };
            */
            result.TotalItem = query.Count();
            query = query
                .OrderByDescending(u => u.Id)
                .Skip(input.Skip())
                .Take(input.PageSize);
            result.Items = query.ToList();
            return result;
        }
    }
}
