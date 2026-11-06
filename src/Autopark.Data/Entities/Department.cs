using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>Отдел във фирмата. Служи за групиране на служители и автомобили и за отчети по отдел.</summary>
[Index(nameof(Name), IsUnique = true)]
public class Department
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(500)]
    public string? Description { get; set; }

    public ICollection<ApplicationUser> Employees { get; set; } = new List<ApplicationUser>();

    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
