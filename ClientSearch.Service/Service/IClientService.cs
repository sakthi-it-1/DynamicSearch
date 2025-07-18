using ClientSearch.Data.Entities;
using ClientSearch.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSearch.Service.Service
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetFilteredDataAsync(ClientSearchParams clientSearch);
    }
}
