namespace Autopark.Data.Enums;

/// <summary>Вид известие.</summary>
public enum NotificationType
{
    Info = 1,                 // Обща информация
    ReservationApproved = 2,  // Одобрена заявка
    ReservationRejected = 3,  // Отказана заявка
    DeadlineWarning = 4,      // Наближаващ срок (документ, книжка, обслужване)
    FuelConsumptionAlert = 5  // Разход над нормата с повече от 20%
}
