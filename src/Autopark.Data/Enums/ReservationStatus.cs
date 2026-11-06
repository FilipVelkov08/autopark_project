namespace Autopark.Data.Enums;

/// <summary>Статус на заявка за автомобил.</summary>
public enum ReservationStatus
{
    Pending = 1,   // Чака одобрение
    Approved = 2,  // Одобрена
    Rejected = 3,  // Отказана
    Cancelled = 4, // Отменена от служителя
    Completed = 5  // Приключила (автомобилът е върнат)
}
