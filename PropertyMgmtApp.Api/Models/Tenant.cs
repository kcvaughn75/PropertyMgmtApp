using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PropertyMgmtApp.Api.Models;

public partial class Tenant
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [StringLength(20)]
    public string? Phone { get; set; }

    [StringLength(255)]
    public string? Email { get; set; }

    [InverseProperty("Tenant")]
    public virtual ICollection<Lease> Leases { get; set; } = new List<Lease>();
}
