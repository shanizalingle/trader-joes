using Microsoft.EntityFrameworkCore;

namespace TraderJoes.Models
{
  public class TraderJoesContext : DbContext
  {
    public DbSet<Department> Departments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<DepartmentProduct> DepartmentProduct { get; set; }

    public TraderJoesContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}