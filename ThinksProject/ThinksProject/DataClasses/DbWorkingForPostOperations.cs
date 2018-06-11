using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinksProject.Data;

namespace ThinksProject.DataClasses
{
    public class DbWorkingForPostOperations
    {
        private readonly DataDbContext _context;
        public DbWorkingForPostOperations(DataDbContext context)
        {
            _context = context;
        }
        public void EditPost(string id, string text)
        {
            int Id = int.Parse(id.Split('_')[2]);
            _context.Posts.First(x => x.Id == Id).Text = text;
            _context.SaveChanges();
        }

        public void DeletePost(string id)
        {
            int Id = int.Parse(id);
            var post = _context.Posts.First(x => x.Id == Id);
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
