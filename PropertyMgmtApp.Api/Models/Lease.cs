using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PropertyMgmtApp.Api.Models;

public partial class Lease
{
    [Key]
    public int Id { get; set; }

    public int UnitId { get; set; }

    public int TenantId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MonthlyRent { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SecurityDeposit { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("Leases")]
    public virtual Tenant? Tenant { get; set; } = null!;

    [ForeignKey("UnitId")]
    [InverseProperty("Leases")]
    public virtual Unit? Unit { get; set; } = null!;
}
