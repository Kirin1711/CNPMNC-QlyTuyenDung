using System;
using System.Collections.Generic;

namespace jobconnect.Models;

public partial class Field
{
    public int FieldId { get; set; }

    public string FieldName { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
