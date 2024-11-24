using System;
using System.Collections.Generic;

namespace jobconnect.Models;

public partial class Interview
{
    public int InterviewId { get; set; }

    public DateTime? InterviewDate { get; set; }

    public string? InterviewLocation { get; set; }

    public string? InterviewType { get; set; }

    public int? ApplicationId { get; set; }

    public virtual Application? Application { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
