using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiThuyKieu_1.Context;

namespace NguyenThiThuyKieu_1.Models
{
public class CartModel
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}
}
