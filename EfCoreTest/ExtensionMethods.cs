using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCoreTest
{
    public static class ExtensionMethods
    {
        public static Person FirstWrapper(this DbSet<Person> dbSet, Func<Person, bool> predicate)
        {
            using (var sampleContext = new SampleContext())
            {
                return dbSet.First(predicate);
            }
        }
    }
}
