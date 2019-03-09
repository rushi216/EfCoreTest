using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.ComponentModel.DataAnnotations;

namespace EfCoreTest
{
    public class SampleContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=PersonsDb;Integrated Security=True;");
        }

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] {  new ConsoleLoggerProvider((category, level)
                                            => category == DbLoggerCategory.Database.Command.Name && level >= LogLevel.Information, true) });
    }

    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
