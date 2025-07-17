using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientSearch.Data.Entities;

public class Client
{
    [Key]
    public Guid ClientID { get; set; }


    [Required]
    [Length(2,50)]
    public string ClientName { get; set; }

    [MaxLength(2)]
    public string ClientSource { get; set; }

    [MaxLength(10)]
    public string State { get; set; }

    [MaxLength(50)]
    public string Country { get; set; }

    [MaxLength(50)]
    public string ClientDetails { get; set; }

    [MaxLength(50)]
    public string ServicingOffice { get; set; }

    [MaxLength(50)]
    public string ClientEmployeeSizeRange { get; set; }
}
