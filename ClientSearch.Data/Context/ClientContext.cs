using ClientSearch.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientSearch.Data.Context;

public class ClientContext: DbContext
{
    public ClientContext(DbContextOptions<ClientContext> options) : base(options)
    {
    }

    DbSet<Client> Clients { get; set; }
}
