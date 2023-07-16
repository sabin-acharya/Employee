using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class UsersContext : DbContext

    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
            
        }
        public DbSet <Users> Employees{ get; set; }
    }
}
