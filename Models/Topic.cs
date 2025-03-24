using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trial_SubjectManager.Models;

public class Topic
{
    public int Id { get; set; }  // Auto-incremented Primary Key
    public string Name { get; set; }
    public string Description { get; set; }

    public int SubjectId { get; set; } // Foreign Key
    public Subject Subject { get; set; } // Navigation Property
    public List<SubTopic> SubTopics { get; set; } // Navigation Property
}
