using System;
using System.Collections.Generic;

namespace jobconnect.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string? Comment { get; set; }

    public int? Rating { get; set; }

    public DateTime? FeedbackDate { get; set; }

    public int? InterviewId { get; set; }

    public virtual Interview? Interview { get; set; } = null!;
}
