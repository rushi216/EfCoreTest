using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCoreTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Generating initial data");

            GenerateFakeData();

            Console.WriteLine("Getting person with id 55");

            using (var sampleContext = new SampleContext())
            {
                var person1 = sampleContext.Person.First(x => x.Id == 55);
            }

            Console.WriteLine("Getting person with id 55 with extension method");

            using (var sampleContext = new SampleContext())
            {
                var person1 = sampleContext.Person.FirstWrapper(x => x.Id == 55);
            }

            Console.ReadLine();
        }

        private static void GenerateFakeData()
        {
            using (var sampleContext = new SampleContext())
            {
                if (!sampleContext.Person.Any())
                {
                    for (var i = 0; i < 100; i++)
                    {
                        sampleContext.Person.Add(new Person() { Name = "test " + i });

                        sampleContext.SaveChanges();
                    }
                }
            }
        }
    }
}
