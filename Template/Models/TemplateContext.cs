using Microsoft.EntityFrameworkCore;

namespace Template.Models
{
  public class TemplateContext : DbContext
  {
    public DbSet<PlaceHolder> PlaceHolders { get; set; }
    public DbSet<PlaceHolder2> PlaceHolder2s { get; set; }
    public DbSet<PlaceHolderPlaceHolder2> PlaceHolderPlaceHolder2 { get; set; }

    public TemplateContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}