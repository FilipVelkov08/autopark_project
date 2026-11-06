using System.ComponentModel.DataAnnotations;
using Autopark.Data.Enums;

namespace Autopark.Data.Entities;

/// <summary>Щета по автомобил, докладвана от служител (обикновено при връщане). Може да има снимки.</summary>
public class Damage
{
    public int Id { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    [Required]
    public string ReportedById { get; set; } = null!;
    public ApplicationUser ReportedBy { get; set; } = null!;

    /// <summary>По време на кое пътуване е станала (ако е известно).</summary>
    public int? TripLogId { get; set; }
    public TripLog? TripLog { get; set; }

    public DateTime ReportedOn { get; set; } = DateTime.UtcNow;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    public DamageSeverity Severity { get; set; }

    /// <summary>Ремонтът, с който е отстранена щетата. Null = още не е ремонтирана.</summary>
    public int? RepairId { get; set; }
    public MaintenanceRecord? Repair { get; set; }

    public ICollection<Attachment> Photos { get; set; } = new List<Attachment>();
}
