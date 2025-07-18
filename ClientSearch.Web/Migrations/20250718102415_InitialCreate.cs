using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClientSearch.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", nullable: false),
                    ClientSource = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ClientDetails = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ServicingOffice = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ClientEmployeeSizeRange = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "ClientDetails", "ClientEmployeeSizeRange", "ClientName", "ClientSource", "Country", "ServicingOffice", "State" },
                values: new object[,]
                {
                    { new Guid("c2010001-0000-0000-0000-000000000001"), "IT consulting firm", "100-500", "TechNova Solutions", "A1", "India", "Bangalore", "KA" },
                    { new Guid("c2010001-0000-0000-0000-000000000002"), "Eco product supplier", "50-200", "GreenLeaf Corp", "A2", "India", "Mumbai", "MH" },
                    { new Guid("c2010001-0000-0000-0000-000000000003"), "Marine tech company", "200-1000", "BlueWave Global", "A1", "USA", "Dallas", "TX" },
                    { new Guid("c2010001-0000-0000-0000-000000000004"), "Software development", "500-1500", "InnoSoft Pvt Ltd", "A2", "India", "Chennai", "TN" },
                    { new Guid("c2010001-0000-0000-0000-000000000005"), "Data analytics firm", "150-600", "SilverLine Analytics", "A1", "USA", "New York", "NY" },
                    { new Guid("c2010001-0000-0000-0000-000000000006"), "Cloud services provider", "300-800", "Orbit Tech", "A2", "India", "Delhi", "DL" },
                    { new Guid("c2010001-0000-0000-0000-000000000007"), "Startup incubator", "20-100", "Sunrise Ventures", "A1", "USA", "San Francisco", "CA" },
                    { new Guid("c2010001-0000-0000-0000-000000000008"), "FinTech innovator", "150-500", "GlobalEdge Ltd", "A1", "Singapore", "Singapore", "SG" },
                    { new Guid("c2010001-0000-0000-0000-000000000009"), "AI solutions", "500-1000", "DataNest Inc", "A2", "USA", "Austin", "TX" },
                    { new Guid("c2010001-0000-0000-0000-000000000010"), "Healthcare analytics", "200-600", "Peak Health", "A1", "India", "Hyderabad", "AP" },
                    { new Guid("c2010001-0000-0000-0000-000000000011"), "Digital marketing agency", "100-400", "SkyLine Media", "A2", "USA", "Miami", "FL" },
                    { new Guid("c2010001-0000-0000-0000-000000000012"), "Smart grid tech", "250-800", "NeoGrid Systems", "A1", "Australia", "Sydney", "NSW" },
                    { new Guid("c2010001-0000-0000-0000-000000000013"), "Green construction", "100-300", "EarthWorks Ltd", "A2", "India", "Kochi", "KL" },
                    { new Guid("c2010001-0000-0000-0000-000000000014"), "Investment services", "300-700", "BridgePoint Finance", "A1", "USA", "Chicago", "IL" },
                    { new Guid("c2010001-0000-0000-0000-000000000015"), "Medical device firm", "150-450", "NovaCare Plus", "A2", "USA", "Seattle", "WA" },
                    { new Guid("c2010001-0000-0000-0000-000000000016"), "Artificial intelligence lab", "80-200", "MindForge AI", "A1", "USA", "Palo Alto", "CA" },
                    { new Guid("c2010001-0000-0000-0000-000000000017"), "Autonomous vehicles R&D", "300-900", "AutoPilot Ltd", "A2", "India", "Coimbatore", "TN" },
                    { new Guid("c2010001-0000-0000-0000-000000000018"), "Sustainable fabric maker", "400-1200", "Riverstone Textiles", "A1", "USA", "Atlanta", "GA" },
                    { new Guid("c2010001-0000-0000-0000-000000000019"), "Renewable energy startup", "200-600", "Ignite Energy", "A2", "USA", "Houston", "TX" },
                    { new Guid("c2010001-0000-0000-0000-000000000020"), "Construction AI tools", "100-300", "QuantumBuild", "A1", "Canada", "Vancouver", "BC" },
                    { new Guid("c2010001-0000-0000-0000-000000000021"), "Online grocery service", "50-250", "FoodVerse Co", "A2", "India", "Lucknow", "UP" },
                    { new Guid("c2010001-0000-0000-0000-000000000022"), "Industrial robotics", "300-1000", "Wavelength Robotics", "A1", "USA", "Boston", "MA" },
                    { new Guid("c2010001-0000-0000-0000-000000000023"), "Marine ecology tech", "100-600", "EcoHarbor", "A2", "USA", "Portland", "OR" },
                    { new Guid("c2010001-0000-0000-0000-000000000024"), "EdTech solutions", "120-400", "BrightHive", "A1", "India", "Madurai", "TN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
