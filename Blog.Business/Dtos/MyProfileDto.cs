using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Dtos
{
    public class MyProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string InstagramUrl { get; set; }

        public string GithubUrl { get; set; }

        public string LinkedInUrl { get; set; }

        public string Description { get; set; }
    }
}
