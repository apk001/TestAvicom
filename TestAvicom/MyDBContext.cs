using System.Data.Entity;

namespace TestAvicom
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("TestAvicom")
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
