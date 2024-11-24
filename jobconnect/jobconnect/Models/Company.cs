using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobconnect.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? EmailCompanies { get; set; }

    public string? Website { get; set; }

    public string? AvartarCompanies { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public int? FieldId { get; set; }

    public virtual Field? Field { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
