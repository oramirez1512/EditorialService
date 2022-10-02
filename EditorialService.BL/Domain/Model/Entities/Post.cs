using EditorialService.BL.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Model.Entities
{
    public class Post 
    {
        public long PostId { get; set; }
        public long AuthorId { get; set; }
        
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsApproved { get; set; }

        public long? ApprovedBy { get; set; }

        public bool Submited { get; set; }
    }
}
