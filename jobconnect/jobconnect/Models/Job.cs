using System;
using System.Collections.Generic;

namespace jobconnect.Models;

public partial class Job
{
    public int JobId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? SalaryRange { get; set; }

    public DateTime? PostedDate { get; set; }

    public string? ExperienceLevel { get; set; }

    public int? JobTypeId { get; set; }

    public int? CompanyId { get; set; }

    public int? ProfessionId { get; set; }

    public int? LocationId { get; set; }

    public string Status { get; set; } = "Pending";

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Company? Company { get; set; }

    public virtual JobType? JobType { get; set; }

    public virtual Location? Location { get; set; }

    public virtual Profession? Profession { get; set; }
}
