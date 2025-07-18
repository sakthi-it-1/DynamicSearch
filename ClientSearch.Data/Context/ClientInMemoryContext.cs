using ClientSearch.Data.Entities;
using Microsoft.EntityFrameworkCore;



namespace ClientSearch.Data.Context;

public class ClientInMemoryContext : DbContext
{
    public ClientInMemoryContext(DbContextOptions<ClientInMemoryContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }  // example DbSet



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>().HasData(
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000001"), ClientName = "TechNova Solutions", ClientSource = "A1", State = "KA", Country = "India", ClientDetails = "IT consulting firm", ServicingOffice = "Bangalore", ClientEmployeeSizeRange = "100-500" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000002"), ClientName = "GreenLeaf Corp", ClientSource = "A2", State = "MH", Country = "India", ClientDetails = "Eco product supplier", ServicingOffice = "Mumbai", ClientEmployeeSizeRange = "50-200" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000003"), ClientName = "BlueWave Global", ClientSource = "A1", State = "TX", Country = "USA", ClientDetails = "Marine tech company", ServicingOffice = "Dallas", ClientEmployeeSizeRange = "200-1000" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000004"), ClientName = "InnoSoft Pvt Ltd", ClientSource = "A2", State = "TN", Country = "India", ClientDetails = "Software development", ServicingOffice = "Chennai", ClientEmployeeSizeRange = "500-1500" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000005"), ClientName = "SilverLine Analytics", ClientSource = "A1", State = "NY", Country = "USA", ClientDetails = "Data analytics firm", ServicingOffice = "New York", ClientEmployeeSizeRange = "150-600" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000006"), ClientName = "Orbit Tech", ClientSource = "A2", State = "DL", Country = "India", ClientDetails = "Cloud services provider", ServicingOffice = "Delhi", ClientEmployeeSizeRange = "300-800" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000007"), ClientName = "Sunrise Ventures", ClientSource = "A1", State = "CA", Country = "USA", ClientDetails = "Startup incubator", ServicingOffice = "San Francisco", ClientEmployeeSizeRange = "20-100" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000008"), ClientName = "GlobalEdge Ltd", ClientSource = "A1", State = "SG", Country = "Singapore", ClientDetails = "FinTech innovator", ServicingOffice = "Singapore", ClientEmployeeSizeRange = "150-500" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000009"), ClientName = "DataNest Inc", ClientSource = "A2", State = "TX", Country = "USA", ClientDetails = "AI solutions", ServicingOffice = "Austin", ClientEmployeeSizeRange = "500-1000" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000010"), ClientName = "Peak Health", ClientSource = "A1", State = "AP", Country = "India", ClientDetails = "Healthcare analytics", ServicingOffice = "Hyderabad", ClientEmployeeSizeRange = "200-600" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000011"), ClientName = "SkyLine Media", ClientSource = "A2", State = "FL", Country = "USA", ClientDetails = "Digital marketing agency", ServicingOffice = "Miami", ClientEmployeeSizeRange = "100-400" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000012"), ClientName = "NeoGrid Systems", ClientSource = "A1", State = "NSW", Country = "Australia", ClientDetails = "Smart grid tech", ServicingOffice = "Sydney", ClientEmployeeSizeRange = "250-800" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000013"), ClientName = "EarthWorks Ltd", ClientSource = "A2", State = "KL", Country = "India", ClientDetails = "Green construction", ServicingOffice = "Kochi", ClientEmployeeSizeRange = "100-300" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000014"), ClientName = "BridgePoint Finance", ClientSource = "A1", State = "IL", Country = "USA", ClientDetails = "Investment services", ServicingOffice = "Chicago", ClientEmployeeSizeRange = "300-700" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000015"), ClientName = "NovaCare Plus", ClientSource = "A2", State = "WA", Country = "USA", ClientDetails = "Medical device firm", ServicingOffice = "Seattle", ClientEmployeeSizeRange = "150-450" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000016"), ClientName = "MindForge AI", ClientSource = "A1", State = "CA", Country = "USA", ClientDetails = "Artificial intelligence lab", ServicingOffice = "Palo Alto", ClientEmployeeSizeRange = "80-200" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000017"), ClientName = "AutoPilot Ltd", ClientSource = "A2", State = "TN", Country = "India", ClientDetails = "Autonomous vehicles R&D", ServicingOffice = "Coimbatore", ClientEmployeeSizeRange = "300-900" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000018"), ClientName = "Riverstone Textiles", ClientSource = "A1", State = "GA", Country = "USA", ClientDetails = "Sustainable fabric maker", ServicingOffice = "Atlanta", ClientEmployeeSizeRange = "400-1200" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000019"), ClientName = "Ignite Energy", ClientSource = "A2", State = "TX", Country = "USA", ClientDetails = "Renewable energy startup", ServicingOffice = "Houston", ClientEmployeeSizeRange = "200-600" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000020"), ClientName = "QuantumBuild", ClientSource = "A1", State = "BC", Country = "Canada", ClientDetails = "Construction AI tools", ServicingOffice = "Vancouver", ClientEmployeeSizeRange = "100-300" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000021"), ClientName = "FoodVerse Co", ClientSource = "A2", State = "UP", Country = "India", ClientDetails = "Online grocery service", ServicingOffice = "Lucknow", ClientEmployeeSizeRange = "50-250" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000022"), ClientName = "Wavelength Robotics", ClientSource = "A1", State = "MA", Country = "USA", ClientDetails = "Industrial robotics", ServicingOffice = "Boston", ClientEmployeeSizeRange = "300-1000" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000023"), ClientName = "EcoHarbor", ClientSource = "A2", State = "OR", Country = "USA", ClientDetails = "Marine ecology tech", ServicingOffice = "Portland", ClientEmployeeSizeRange = "100-600" },
            new Client { ClientID = Guid.Parse("c2010001-0000-0000-0000-000000000024"), ClientName = "BrightHive", ClientSource = "A1", State = "TN", Country = "India", ClientDetails = "EdTech solutions", ServicingOffice = "Madurai", ClientEmployeeSizeRange = "120-400" });
    }
}
