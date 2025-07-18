namespace ClientSearch.Models.Search;

public record Filter
{
    public required string Field { get; set; }
    public required string Operation { get; set; }
    public required string Value { get; set; }
}

