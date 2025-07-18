using ClientSearch.Data.Entities;
using ClientSearch.Data.Repository;
using ClientSearch.Models.Search;
using ClientSearch.Service.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ClientSearch.Service.Service;

public class ClientService: IClientService
{
    private IClient<Client> _clientRepo;

    public ClientService(IClient<Client> client)
    {
            _clientRepo = client;
    }

    public async Task<IEnumerable<Client>> GetFilteredDataAsync(ClientSearchParams clientSearch)
    {
        var query =  _clientRepo.GetBaseQuery()
                      .WithSearchIds(clientSearch.ClientIDList)
                      .WithDynamicFields(clientSearch.Filters)
                      .AddClientNameWithEquals(clientSearch.ClientName, clientSearch.Filters)
                      .AddClientNameWithContains(clientSearch.ClientNameContains, clientSearch.Filters)
                      .AddClientNameWithWildCard(clientSearch.ClientNameBeginsWith, clientSearch.Filters)
                      .OrderBy(x=>x.ClientName)
                      .WithSkipAndTake(clientSearch.PageSize, clientSearch.PageNumber);

        var que = query.ToQueryString();

        var result = await _clientRepo.SearchClientAsync(query).ConfigureAwait(false); 

        return  result;
    }
}
