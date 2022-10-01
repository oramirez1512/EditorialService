using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Requests
{
    public class EditPostRequest:CreatePostRequest
    {
        public long PostId { get; set; }
    }
}
