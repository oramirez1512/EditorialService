using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Requests
{
    public class CommentRequest:PostRequestBase
    {
        public string Comment { get; set; }
    }
}
