using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
