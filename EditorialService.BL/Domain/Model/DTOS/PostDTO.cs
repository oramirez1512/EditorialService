using EditorialService.BL.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Model.DTOS
{
    public class PostDTO: Post
    {
        public List<Comment> Comments { get; set; }
    }
}
