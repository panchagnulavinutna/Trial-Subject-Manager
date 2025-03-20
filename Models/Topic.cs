using System;
using System.Collections.Generic;

namespace Trial_SubjectManager.Models;

public partial class Topic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int SubjectId { get; set; }

    public virtual ICollection<SubTopic> SubTopics { get; set; } = new List<SubTopic>();

    public virtual Subject Subject { get; set; } = null!;
}
