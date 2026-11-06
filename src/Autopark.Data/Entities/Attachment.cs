using System.ComponentModel.DataAnnotations;

namespace Autopark.Data.Entities;

/// <summary>Прикачен файл: снимка на щета или сканиран документ. Самият файл е на диска, тук е само пътят.</summary>
public class Attachment
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string OriginalFileName { get; set; } = null!;

    /// <summary>Име, под което е записан на сървъра (генерирано, за да няма конфликти и опасни имена).</summary>
    [Required]
    [MaxLength(300)]
    public string StoredFilePath { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string ContentType { get; set; } = null!; // напр. "image/jpeg"

    public long SizeInBytes { get; set; }

    public DateTime UploadedOn { get; set; } = DateTime.UtcNow;

    [Required]
    public string UploadedById { get; set; } = null!;
    public ApplicationUser UploadedBy { get; set; } = null!;

    // Файлът принадлежи или на щета, или на документ.
    public int? DamageId { get; set; }
    public Damage? Damage { get; set; }

    public int? VehicleDocumentId { get; set; }
    public VehicleDocument? VehicleDocument { get; set; }
}
