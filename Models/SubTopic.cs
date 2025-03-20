using System;
using System.Collections.Generic;

namespace Trial_SubjectManager.Models;

public partial class SubTopic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int TopicId { get; set; }

    public virtual Topic Topic { get; set; } = null!;
}
