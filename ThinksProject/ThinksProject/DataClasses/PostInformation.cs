using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinksProject.DataClasses
{
    public class PostInformation
    {
		public int Id { get; set; }
		public User User { get; set; }
		public Post Posts { get; set; }
        public int? PostsId { get; set; }

    }
}
