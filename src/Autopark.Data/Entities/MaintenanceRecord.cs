using System.ComponentModel.DataAnnotations;
using Autopark.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>Обслужване или ремонт на автомобил. Последното планово обслужване определя следващото по време и пробег.</summary>
[Index(nameof(VehicleId), nameof(Date))]
public class MaintenanceRecord
{
    public int Id { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public MaintenanceType Type { get; set; }

    public DateTime Date { get; set; }

    public int Mileage { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [Precision(10, 2)]
    public decimal Cost { get; set; }

    [MaxLength(100)]
    public string? ServiceProvider { get; set; } // сервиз

    public ICollection<Damage> RepairedDamages { get; set; } = new List<Damage>();
}
