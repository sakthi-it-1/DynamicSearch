using System.ComponentModel.DataAnnotations;

namespace ClientSearch.Models.Models
{
    public record ClientSearch
    {

        public required int PageNumber { get; set; }
        public required int PageSize { get; set; }
        public required IEnumerable<string> ClientIDList { get; set; }
        public string? ClientName { get; set; }
        public string? ClientNameContains { get; set; }
        public string? ClientNameBeginsWith { get; set; }
        public IEnumerable<Filter>? Filters { get; set; }

    }
}
