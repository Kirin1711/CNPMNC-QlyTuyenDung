using System;
using System.Collections.Generic;

namespace jobconnect.Models;

public partial class JobType
{
    public int JobTypeId { get; set; }

    public string JobTypeName { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
