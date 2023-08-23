using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PicoYPlaca.Infraestructure;

public class PicoYPlacaDbContextFactory : IDesignTimeDbContextFactory<PicoYPlacaDbContext>
{
    public PicoYPlacaDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Server=myServerName;Database=myDatabaseName;Integrated Security=True;TrustServerCertificate=True;";
        var optionsBuilder = new DbContextOptionsBuilder<PicoYPlacaDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new PicoYPlacaDbContext(optionsBuilder.Options);
    }
}

