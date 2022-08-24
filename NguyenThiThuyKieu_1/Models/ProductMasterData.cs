using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NguyenThiThuyKieu_1.Models
{
    public partial class ProductMasterData
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Danh mục sản phẩm")]
        [Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Mô tả ngắn")]
        [Required(ErrorMessage = "Mô tả ngắn không được để trống")]
        public string ShortDes { get; set; }
        [Display(Name = "Mô tả đầy đủ")]
        [Required(ErrorMessage = "Mô tả đầy đủ không được để trống")]
        public string FullDescription { get; set; }
        [Display(Name = "Giá ")]
        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Sản phẩm giảm giá")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Loại danh mục sản phẩm")]
        [Required(ErrorMessage = "Loại danh mục sản phẩm không được để trống")]
        public Nullable<int> TypeId { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Tên thương hiệu")]
        [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
        public Nullable<int> BrandId { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Ngày tạo sản phẩm")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày chỉnh sửa" +
            "" +
            " sản phẩm")]
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }

    }
}