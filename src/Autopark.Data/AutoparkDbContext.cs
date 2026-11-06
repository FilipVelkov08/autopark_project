using Autopark.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autopark.Data;

/// <summary>
/// Връзката на приложението с базата данни.
/// Наследява IdentityDbContext, за да създаде и таблиците за потребители и роли (AspNetUsers, AspNetRoles...).
/// Всеки DbSet по-долу става отделна таблица.
/// </summary>
public class AutoparkDbContext : IdentityDbContext<ApplicationUser>
{
    public AutoparkDbContext(DbContextOptions<AutoparkDbContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<DriverLicense> DriverLicenses => Set<DriverLicense>();
    public DbSet<VehicleCategory> VehicleCategories => Set<VehicleCategory>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<VehicleDocument> VehicleDocuments => Set<VehicleDocument>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<TripLog> TripLogs => Set<TripLog>();
    public DbSet<FuelRecord> FuelRecords => Set<FuelRecord>();
    public DbSet<MaintenanceRecord> MaintenanceRecords => Set<MaintenanceRecord>();
    public DbSet<Damage> Damages => Set<Damage>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Задължително първо – създава таблиците на Identity.
        base.OnModelCreating(builder);

        // По подразбиране EF изтрива каскадно (изтриеш автомобил -> изтриват се всичките му записи).
        // За автопарк това е опасно – губи се историята. Освен това SQL Server отказва
        // няколко каскадни пътя към една таблица. Затова за нашите таблици забраняваме каскадата:
        // запис, към който има връзки, не може да бъде изтрит.
        var ourForeignKeys = builder.Model.GetEntityTypes()
            .Where(e => e.ClrType.Namespace == typeof(Vehicle).Namespace)
            .SelectMany(e => e.GetForeignKeys());

        foreach (var foreignKey in ourForeignKeys)
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // Ако снимка/документ се изтрие заедно с щетата или документа – това е желано.
        builder.Entity<Attachment>()
            .HasOne(a => a.Damage).WithMany(d => d.Photos)
            .HasForeignKey(a => a.DamageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Attachment>()
            .HasOne(a => a.VehicleDocument).WithMany(d => d.Attachments)
            .HasForeignKey(a => a.VehicleDocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Начални данни за номенклатурите. Останалите демо данни ще добавим отделно.
        builder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Продажби", Description = "Търговски представители и работа с клиенти" },
            new Department { Id = 2, Name = "Логистика", Description = "Доставки и складова дейност" },
            new Department { Id = 3, Name = "Администрация", Description = "Управление, счетоводство и ИТ" });

        builder.Entity<VehicleCategory>().HasData(
            new VehicleCategory { Id = 1, Name = "Лек автомобил", RequiredLicenseCategory = "B" },
            new VehicleCategory { Id = 2, Name = "Ван / лекотоварен", RequiredLicenseCategory = "B" },
            new VehicleCategory { Id = 3, Name = "Товарен автомобил", RequiredLicenseCategory = "C" });
    }
}
