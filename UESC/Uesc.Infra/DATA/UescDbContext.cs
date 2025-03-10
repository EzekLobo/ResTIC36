namespace Uesc.Infra.DATA;
using Microsoft.EntityFrameworkCore;
using Uesc.Business.Entities;

public class UescDbContext : DbContext
{
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Materia> Materias { get; set; }


    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=UESC;Trusted_Connection=True;MultipleActiveResultSets=true");
    }*/

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=Uesc;User=root;Password=12345678;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>()
                .HasKey(a => a.Id);
                
        modelBuilder.Entity<Log>()
                .HasKey(l => l.Id);

        modelBuilder.Entity<Materia>()
                .HasKey(m => m.Id);
    }
}