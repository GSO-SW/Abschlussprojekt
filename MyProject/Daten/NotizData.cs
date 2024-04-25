using System.IO;
using Microsoft.EntityFrameworkCore;


namespace NotizData
{
    // GSO_ABSCHLUSS Klasse erbt von DbContext, einem Teil des Entity Frameworks
    internal class GSO_ABSCHLUSS : DbContext
    {
        // DbSet-Eigenschaften repräsentieren Tabellen in der Datenbank
        // Jede Eigenschaft ist stark typisiert mit einer Modellklasse
        public DbSet<Login> Logins { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;

        // OnModelCreating-Methode wird verwendet, um das Modell und die Beziehungen mittels Fluent API zu konfigurieren
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definieren von Primärschlüsseln für jede Entität
            modelBuilder.Entity<Login>().HasKey(l => l.Id);
            modelBuilder.Entity<Note>().HasKey(n => n.Id);

            // Immer die Basis-Methode aufrufen, um das Basisverhalten einzuschließen
            base.OnModelCreating(modelBuilder);
        }

        // OnConfiguring-Methode wird verwendet, um die Datenbankverbindung und andere Konfigurationen einzustellen
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Überprüfen, ob der optionsBuilder bereits konfiguriert ist, wenn nicht, konfigurieren
            if (!optionsBuilder.IsConfigured)
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var dbPath = Path.Combine(currentDirectory, "Notiz.db");

                // Konfigurieren der Verwendung der SQLite-Datenbank mit dem angegebenen Verbindungsstring
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }

            // Immer die Basis-Methode aufrufen, um das Basisverhalten einzuschließen
            base.OnConfiguring(optionsBuilder);
        }
    }
}
