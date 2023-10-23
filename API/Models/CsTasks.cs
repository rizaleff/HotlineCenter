﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_cs_tasks")]
public class CsTasks : BaseEntity
{
    [Column("cs_guid")]
    public Guid CsGuid { get; set; }

    [Column("task_guid")]
    public Guid TaskGuid { get; set; }

    //Cardinality
    public Employees? Employee { get; set; }
    public Tasks? Task { get; set; }
}