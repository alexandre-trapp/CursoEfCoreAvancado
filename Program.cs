using System;
using CursoEFCore.Data;

namespace EFCoreAvancado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var applicationContext = new ApplicationContext();
            applicationContext.Database.EnsureCreated();
        }
    }
}
