using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NguyenThiThuyKieu_1.Models
{
    public class BrandMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]

        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]

        public string Avatar { get; set; }

        public string Slug { get; set; }
        [Display(Name = "Hiện thị trên trang người dùng")]

        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedUtc { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}
