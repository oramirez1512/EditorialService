using EditorialService.BL.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Common
{
    public class EditorialDbContext:DbContext
    {
        public EditorialDbContext(DbContextOptions<EditorialDbContext> options) : base(options) 
        {

        }
        public DbSet<Person> people { get; set; }
        public DbSet<Role> roles { get; set; }

        public DbSet<Permissions> permissions { get; set; }

        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Comment> comments { get; set; }
    }
}
