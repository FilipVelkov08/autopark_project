using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>
/// Пътен лист: реалното пътуване по одобрена резервация.
/// Съдържа началния и крайния километраж – от тях се смятат изминатите км и разходът.
/// </summary>
[Index(nameof(ReservationId), IsUnique = true)] // една резервация = най-много един пътен лист
public class TripLog
{
    public int Id { get; set; }

    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; } = null!;

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int StartMileage { get; set; }

    /// <summary>Попълва се при връщане. Не може да е по-малък от StartMileage.</summary>
    public int? EndMileage { get; set; }

    [MaxLength(500)]
    public string? Route { get; set; } // маршрут, напр. "София – Пловдив – София"

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public ICollection<FuelRecord> FuelRecords { get; set; } = new List<FuelRecord>();
    public ICollection<Damage> Damages { get; set; } = new List<Damage>();
}
