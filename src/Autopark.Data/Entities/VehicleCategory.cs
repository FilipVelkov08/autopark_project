using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>Номенклатура: категория автомобил (лек, товарен, ван...). Управлява се от администратора.</summary>
[Index(nameof(Name), IsUnique = true)]
public class VehicleCategory
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    /// <summary>Нужна категория шофьорска книжка, напр. "B".</summary>
    [Required]
    [MaxLength(5)]
    public string RequiredLicenseCategory { get; set; } = null!;

    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
