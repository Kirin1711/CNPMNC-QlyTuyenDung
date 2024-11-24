using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobconnect.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? IsActive { get; set; }

    public string? AvatarUrl { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public int? CompanyId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Company? Company { get; set; }

    public virtual Role? Role { get; set; }
}
