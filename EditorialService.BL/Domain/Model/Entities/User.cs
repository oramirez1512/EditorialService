using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Model.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public long PersonId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
