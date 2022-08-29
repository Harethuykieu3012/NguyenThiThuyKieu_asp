using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenThiThuyKieu_1.Models
{
	public class UserMasterData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    }
}