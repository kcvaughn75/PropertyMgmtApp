using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PropertyMgmtApp.Api.Models;

public partial class Property
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Address { get; set; }

    [InverseProperty("Property")]
    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
