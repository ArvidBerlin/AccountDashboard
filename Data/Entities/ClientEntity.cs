﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

[Index(nameof(ClientName), IsUnique = true)]
public class ClientEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Image { get; set; }
    public string ClientName { get; set; } = null!;

    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}
