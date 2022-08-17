using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NguyenThiThuyKieu_1.Context;
namespace NguyenThiThuyKieu_1.Models
{
    public class HomeModel
    {
        public List<Product> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }
    }
}