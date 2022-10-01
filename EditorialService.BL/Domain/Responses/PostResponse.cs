using EditorialService.BL.Domain.Model.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Domain.Responses
{
    public class PostResponse
    {
        public List<PostDTO> posts { get; set; }
    }
}
