using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PropertyMgmtApp.Api.Models;

public partial class Unit
{
    [Key]
    public int Id { get; set; }

    public int PropertyId { get; set; }

    [StringLength(50)]
    public string Number { get; set; } = null!;

    public int? Bedrooms { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Rent { get; set; }

    [InverseProperty("Unit")]
    public virtual ICollection<Lease> Leases { get; set; } = new List<Lease>();

    [ForeignKey("PropertyId")]
    [InverseProperty("Units")]
    public virtual Property Property { get; set; } = null!;
}
