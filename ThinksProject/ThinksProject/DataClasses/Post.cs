using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinksProject.DataClasses
{
    public class Post
    {
        public int Id { get; set; }
        public PostInformation PostInformation { get; set; }
        public string Text { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
