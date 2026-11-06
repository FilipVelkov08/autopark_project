using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Autopark.Data.Entities;

/// <summary>
/// Потребител на системата (служител, мениджър или администратор).
/// Наследява IdentityUser, който вече съдържа имейл, парола (хеширана), телефон и т.н.
/// Тук добавяме само това, което е специфично за нашата фирма.
/// </summary>
public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [MaxLength(100)]
    public string? Position { get; set; }

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    /// <summary>Неактивните служители не могат да правят резервации (напр. напуснали).</summary>
    public bool IsActive { get; set; } = true;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public ICollection<DriverLicense> DriverLicenses { get; set; } = new List<DriverLicense>();

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public ICollection<TripLog> TripLogs { get; set; } = new List<TripLog>();

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
