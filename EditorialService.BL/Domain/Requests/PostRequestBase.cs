using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Requests
{
    public class PostRequestBase
    {
        public long editorId { get; set; }
        public long PostId { get; set; }
    }
}
