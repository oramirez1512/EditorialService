using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Requests
{
    public class CreatePostRequest
    {
        public long AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
