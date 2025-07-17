using ClientSearch.Data.Entities;
using Microsoft.EntityFrameworkCore;



namespace ClientSearch.Data.Context;

public class ClientInMemoryContext: DbContext
{
    DbSet<Client> Clients { get; set; }
}
