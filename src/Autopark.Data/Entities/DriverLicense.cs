using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>Шофьорска книжка на служител. Без валидна книжка служителят не може да получи автомобил.</summary>
[Index(nameof(LicenseNumber), IsUnique = true)]
public class DriverLicense
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    public string LicenseNumber { get; set; } = null!;

    /// <summary>Категории, напр. "B" или "B, C".</summary>
    [Required]
    [MaxLength(30)]
    public string Categories { get; set; } = null!;

    public DateTime IssueDate { get; set; }

    public DateTime ExpiryDate { get; set; }
}
