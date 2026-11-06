using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Autopark.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>Заявка на служител за автомобил за даден период. Одобрява се от мениджъра.</summary>
[Index(nameof(VehicleId), nameof(StartDate), nameof(EndDate))] // ускорява проверката за застъпване
public class Reservation
{
    public int Id { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    /// <summary>Служителят, който заявява автомобила.</summary>
    [Required]
    public string UserId { get; set; } = null!;
    [InverseProperty(nameof(ApplicationUser.Reservations))]
    public ApplicationUser User { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [Required]
    [MaxLength(300)]
    public string Purpose { get; set; } = null!; // цел на пътуването

    [MaxLength(200)]
    public string? Destination { get; set; }

    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

    /// <summary>Мениджърът, който е одобрил или отказал заявката.</summary>
    public string? ReviewedById { get; set; }
    public ApplicationUser? ReviewedBy { get; set; }

    public DateTime? ReviewedOn { get; set; }

    [MaxLength(500)]
    public string? RejectionReason { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    /// <summary>Пътният лист, попълнен при връщане на автомобила.</summary>
    public TripLog? TripLog { get; set; }
}
