using System;
using System.Diagnostics;
using System.Linq;
using CursoEFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreAvancado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // warmup
            new ApplicationContext().Departamentos.AsNoTracking().Any();

            _count = 0;
            GerenciarEstadoConexao(gerenciarEstado: false);

            _count = 0;
            GerenciarEstadoConexao(gerenciarEstado: true);

            //HealthCheckDb();

            //GapDoEnsureCreated();

            // using var db = new ApplicationContext();
            // db.Database.EnsureCreated();
            // db.Database.EnsureDeleted();
        }

        static int _count;
        static void GerenciarEstadoConexao(bool gerenciarEstado)
        {
            using var db = new ApplicationContext();
            var time = Stopwatch.StartNew();

            var conexao = db.Database.GetDbConnection();
            conexao.StateChange += (_, __) => ++_count;

            if (gerenciarEstado)
                conexao.Open();

            for (int i = 0; i < 200; i++)
                db.Departamentos.AsNoTracking().Any();

            time.Stop();

            var mensagem = $"Tempo: {time.Elapsed}, {gerenciarEstado}, contador: {_count}";
            Console.WriteLine(mensagem);
        }

        static void HealthCheckDb()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureCreated();

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
