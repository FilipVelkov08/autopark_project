using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>
/// Зареждане с гориво. Разходът се смята между две последователни ПЪЛНИ зареждания:
/// литрите, заредени до второто пълно, делено на изминатите км между тях, по 100.
/// </summary>
[Index(nameof(VehicleId), nameof(Date))]
public class FuelRecord
{
    public int Id { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!; // кой е заредил
    public ApplicationUser User { get; set; } = null!;

    public int? TripLogId { get; set; }
    public TripLog? TripLog { get; set; }

    public DateTime Date { get; set; }

    /// <summary>Километраж в момента на зареждане.</summary>
    public int Mileage { get; set; }

    [Precision(7, 2)]
    public decimal Liters { get; set; }

    [Precision(6, 3)]
    public decimal PricePerLiter { get; set; }

    [Precision(10, 2)]
    public decimal TotalCost { get; set; }

    /// <summary>Пълен резервоар ли е – само пълните зареждания се ползват за изчисляване на разхода.</summary>
    public bool IsFullTank { get; set; }

    [MaxLength(100)]
    public string? StationName { get; set; }
}
