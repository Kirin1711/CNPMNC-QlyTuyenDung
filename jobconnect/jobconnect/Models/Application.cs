using System;
using System.Collections.Generic;

namespace jobconnect.Models;

public partial class Application
{
    public int ApplicationId { get; set; }

    public string? Cv { get; set; }

    public string? CoverLetter { get; set; }

    public DateTime? ApplicationDate { get; set; }

    public int? JobId { get; set; }

    public int? UserId { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual Job? Job { get; set; }

    public virtual ApplicationStatus? Status { get; set; }

    public virtual User? User { get; set; }
}
