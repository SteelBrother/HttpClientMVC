using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCallApi.Models;

namespace TestCallApi.Data
{
    public class TestCallApiContext : DbContext
    {
        public TestCallApiContext (DbContextOptions<TestCallApiContext> options)
            : base(options)
        {
        }

        public DbSet<TestCallApi.Models.Person> Person { get; set; }
    }
}
