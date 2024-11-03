using JODDB_task.Models;
using Microsoft.EntityFrameworkCore;


namespace JODDB_task.DAL
{
        public class UserContext :DbContext
        {
        
        public UserContext(DbContextOptions<UserContext> options)
                : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        }
}
