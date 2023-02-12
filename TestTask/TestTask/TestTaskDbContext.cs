using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TestTask.Models;

namespace TestTask
{
    public class TestTaskDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options) { }
    }
}
