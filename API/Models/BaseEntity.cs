﻿namespace API.Models;
public class GeneralModel
{
    [Key, Column("guid")]
    public Guid Guid { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    [Column("modified_date")]
    public DateTime ModifiedDate { get; set; }
}
