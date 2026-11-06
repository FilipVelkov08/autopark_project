using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>Журнал: кой, какво и кога е направил в системата (създаване, промяна, изтриване, одобрение).</summary>
[Index(nameof(CreatedOn))]
public class AuditLog
{
    public int Id { get; set; }

    /// <summary>Null, ако действието е от системата (напр. фоновата услуга).</summary>
    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    [Required]
    [MaxLength(50)]
    public string Action { get; set; } = null!; // "Create", "Update", "Delete", "Approve"...

    [Required]
    [MaxLength(50)]
    public string EntityName { get; set; } = null!; // "Vehicle", "Reservation"...

    [MaxLength(50)]
    public string? EntityId { get; set; }

    [MaxLength(2000)]
    public string? Details { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
