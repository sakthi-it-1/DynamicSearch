namespace ClientSearch.Models.Search;

public record ClientSearchParams
{

    public required int PageNumber { get; set; }
    public required int PageSize { get; set; }
    public IEnumerable<Guid> ClientIDList { get; set; }
    public string? ClientName { get; set; }
    public string? ClientNameContains { get; set; }
    public string? ClientNameBeginsWith { get; set; }
    public IEnumerable<Filter>? Filters { get; set; }

}
