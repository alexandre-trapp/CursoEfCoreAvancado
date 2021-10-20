using System;
using CursoEFCore.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreAvancado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HealthCheckDb();

            //GapDoEnsureCreated();

            // using var db = new ApplicationContext();
            // db.Database.EnsureCreated();
            // db.Database.EnsureDeleted();
        }

        static void HealthCheckDb()
        {
            using var db = new ApplicationContext();

            if (db.Database.CanConnect())
                Console.WriteLine("Connected");
            else
                Console.WriteLine("Disconnected");
        }

        static void GapDoEnsureCreated()
        {
            using var db1 = new ApplicationContext();
            using var db2 = new ApplicationContextCidade();

            db1.Database.EnsureCreated();
            db2.Database.EnsureCreated();

            var databaseCreator = db2.GetService<IRelationalDatabaseCreator>();
            databaseCreator.CreateTables();
        }
    }
}
