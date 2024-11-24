using System;
using System.Collections.Generic;

namespace jobconnect.Models;

public partial class ApplicationStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
