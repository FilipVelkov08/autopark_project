using System.ComponentModel.DataAnnotations;
using Autopark.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>Служебен автомобил – централната таблица на системата.</summary>
[Index(nameof(RegistrationNumber), IsUnique = true)]
[Index(nameof(Vin), IsUnique = true)]
public class Vehicle
{
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    public string RegistrationNumber { get; set; } = null!; // напр. "CA1234AB"

    [Required]
    [MaxLength(17)]
    public string Vin { get; set; } = null!; // номер на рама – винаги 17 символа

    [Required]
    [MaxLength(50)]
    public string Make { get; set; } = null!; // марка

    [Required]
    [MaxLength(50)]
    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public FuelType FuelType { get; set; }

    /// <summary>Норма на разход в литри на 100 км. Спрямо нея се дава сигнал при отклонение над 20%.</summary>
    [Precision(5, 2)]
    public decimal FuelNormPer100Km { get; set; }

    /// <summary>Текущ километраж. Може само да се увеличава.</summary>
    public int CurrentMileage { get; set; }

    public VehicleStatus Status { get; set; } = VehicleStatus.Available;

    /// <summary>Обслужване на всеки N км (напр. 15000).</summary>
    public int ServiceIntervalKm { get; set; }

    /// <summary>Обслужване на всеки N месеца (напр. 12) – което настъпи първо.</summary>
    public int ServiceIntervalMonths { get; set; }

    [MaxLength(300)]
    public string? ImagePath { get; set; }

    public int CategoryId { get; set; }
    public VehicleCategory Category { get; set; } = null!;

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public ICollection<VehicleDocument> Documents { get; set; } = new List<VehicleDocument>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<TripLog> TripLogs { get; set; } = new List<TripLog>();
    public ICollection<FuelRecord> FuelRecords { get; set; } = new List<FuelRecord>();
    public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
    public ICollection<Damage> Damages { get; set; } = new List<Damage>();
}
