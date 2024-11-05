namespace DiceCream.DCorp.Infrastructure;

public class DCorpDbContextFactory : IDesignTimeDbContextFactory<DCorpDbContext>
{
    public DCorpDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DCorpDbContext>();

        // Charger la configuration depuis le fichier appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DbConnection");
        optionsBuilder.UseSqlServer(connectionString);

        return new DCorpDbContext(optionsBuilder.Options);
    }
}
