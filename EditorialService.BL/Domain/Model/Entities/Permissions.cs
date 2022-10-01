using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Model.Entities
{
    public class Permissions
    {
        public int PermissionsId { get; set; }
        public int RoleId { get; set; }
        public bool CanApproveReject { get; set; }
        public bool CanCreateEditPost { get; set; }
    }
}
