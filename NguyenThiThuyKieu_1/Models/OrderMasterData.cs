using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenThiThuyKieu_1.Models
{
    public class OrderMasterData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
    }
}