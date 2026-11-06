namespace Autopark.Data.Enums;

/// <summary>Вид документ на автомобил, който има срок на валидност.</summary>
public enum DocumentType
{
    CivilLiabilityInsurance = 1, // Гражданска отговорност
    CascoInsurance = 2,          // Каско
    TechnicalInspection = 3,     // ГТП (годишен технически преглед)
    Vignette = 4,                // Винетка
    RegistrationCertificate = 5  // Свидетелство за регистрация
}
