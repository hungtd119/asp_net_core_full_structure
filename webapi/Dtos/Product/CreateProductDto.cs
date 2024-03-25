using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos.Product
{
    public class CreateProductDto
    {
        private string _name;
        [Required(AllowEmptyStrings = false,ErrorMessage = "Tên không được bỏ trống")]
        [MaxLength(50,ErrorMessage = "Tên sản phẩm dài tối đa 50 ký tự")]
        [MinLength(4,ErrorMessage = "Tên sản phẩm tối thiểu 4 ký tự")]
        public string Name { get { return _name; } set { _name = value; } }

        private string _description;
        public string Description { get { return _description; } set { _description = value; } }
        private float _price;
        [Required(AllowEmptyStrings = false,ErrorMessage = "Không được để trống giá sản phẩm")]
        public float Price { get { return _price; } set { _price = value; } }
    }
}
