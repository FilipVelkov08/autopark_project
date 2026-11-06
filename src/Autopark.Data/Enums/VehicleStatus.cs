namespace Autopark.Data.Enums;

/// <summary>Текущо състояние на автомобила.</summary>
public enum VehicleStatus
{
    Available = 1,      // Свободен
    InUse = 2,          // В движение (по резервация)
    InService = 3,      // В сервиз
    Decommissioned = 4  // Изведен от употреба
}
