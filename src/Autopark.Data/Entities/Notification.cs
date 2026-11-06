using System.ComponentModel.DataAnnotations;
using Autopark.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>Известие в приложението (и по имейл). Създава се от фоновата услуга или при одобрение/отказ.</summary>
[Index(nameof(UserId), nameof(IsRead))]
[Index(nameof(ReferenceKey))]
public class Notification
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;

    public NotificationType Type { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(1000)]
    public string Message { get; set; } = null!;

    /// <summary>Линк към страницата, за която се отнася известието.</summary>
    [MaxLength(300)]
    public string? Url { get; set; }

    /// <summary>
    /// Ключ, който предотвратява повторно известие за едно и също нещо,
    /// напр. "doc-12-30d" = документ 12, известие 30 дни преди срока.
    /// </summary>
    [MaxLength(100)]
    public string? ReferenceKey { get; set; }

    public bool IsRead { get; set; }

    public bool EmailSent { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
