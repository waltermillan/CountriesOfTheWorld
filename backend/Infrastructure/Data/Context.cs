using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data;

public class Context : DbContext
{
    private readonly IConfiguration _configuration;

    public Context(DbContextOptions<Context> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<Continent> Continents { get; set; }
    public virtual DbSet<Goverment> Goverments { get; set; }
    public virtual DbSet<Anthem> Anthems { get; set; }
    public virtual DbSet<Symbol> Symbols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>()
            .HasKey(c => c.Id);  // Define Id (Country) as the primary key

        modelBuilder.Entity<Language>()
            .HasKey(c => c.Id);  // Define Id (Language) as the primary key

        modelBuilder.Entity<Continent>()
            .HasKey(c => c.Id);  // Define Id (Continent) as the primary key

        modelBuilder.Entity<Goverment>()
            .HasKey(c => c.Id);  // Define Id (Goverment) as the primary key

        modelBuilder.Entity<Symbol>()
            .HasKey(c => c.Id);  // Define Id (Symbol) as the primary key
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Utiliza IConfiguration para obtener la cadena de conexión
        var connectionString = _configuration.GetConnectionString("DbConnection");
        optionsBuilder.UseNpgsql(connectionString);
    }
}
