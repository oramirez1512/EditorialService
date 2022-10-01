using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Model.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public long CommentAuthorId { get; set; }
        public long PostId { get; set; }
        public string Content { get; set; }
        public bool beforeApproved { get; set; }
    }
}
