using Microsoft.EntityFrameworkCore;

namespace HarikaWebApplication1.Models
{
    public class EmployeeDBContext:DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options) 
        { 

        }
        public DbSet<EmployeeModel> employees { get; set; }
    }
}
