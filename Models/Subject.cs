using System;
using System.Collections.Generic;

namespace Trial_SubjectManager.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
