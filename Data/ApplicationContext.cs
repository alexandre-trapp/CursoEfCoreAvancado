using System;
using EFCoreAvancado.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connection = "Data source=(localdb)\\mssqllocaldb; Initial Catalog=C002;Integrated Security=true;";

            optionsBuilder.
              UseSqlServer(connection)
              .EnableSensitiveDataLogging()
              .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}