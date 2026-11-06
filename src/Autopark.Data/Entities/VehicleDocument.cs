using System.ComponentModel.DataAnnotations;
using Autopark.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data.Entities;

/// <summary>Документ на автомобил със срок: застраховка, ГТП, винетка. Следи се за изтичане.</summary>
[Index(nameof(ExpiryDate))]
public class VehicleDocument
{
    public int Id { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public DocumentType Type { get; set; }

    [MaxLength(50)]
    public string? DocumentNumber { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    [Precision(10, 2)]
    public decimal? Cost { get; set; }

    public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}
