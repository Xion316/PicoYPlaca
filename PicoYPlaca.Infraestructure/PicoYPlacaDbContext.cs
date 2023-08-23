using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PicoYPlaca.Domain;


namespace PicoYPlaca.Infraestructure;

public class PicoYPlacaDbContext : DbContext
{
    public DbSet<CirculationResult> CirculationResults { get; set; }

    public PicoYPlacaDbContext(DbSet<CirculationResult> circulationResults)
    {
        CirculationResults = circulationResults;
    }


    public PicoYPlacaDbContext(DbContextOptions<PicoYPlacaDbContext> options)
        : base(options)
    {
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = "Server=DESKTOP-2O3RA4T\\SQLDEV;Initial Catalog=PicoYPlacaDb;Integrated Security=True;TrustServerCertificate=True;";
        services.AddDbContext<PicoYPlacaDbContext>(options =>
         options.UseSqlServer(connectionString));

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CirculationResult>();
    }
}
