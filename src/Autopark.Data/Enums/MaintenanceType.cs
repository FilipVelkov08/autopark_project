namespace Autopark.Data.Enums;

/// <summary>Вид обслужване.</summary>
public enum MaintenanceType
{
    ScheduledService = 1, // Планово обслужване (масло, филтри)
    Repair = 2,           // Ремонт
    TireChange = 3,       // Смяна на гуми
    Other = 4             // Друго
}
