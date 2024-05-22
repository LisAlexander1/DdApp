using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DdApp.Entities;

public partial class Specialty
{
    public long Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
