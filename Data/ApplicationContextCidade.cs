using System;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoEFCore.Data
{
    public class ApplicationContextCidade : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }

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