using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YaelTestWebApi.Models
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options)
    : base(options)
        {
        }

        public DbSet<Calculator> CalculatorHistory { get; set; }
    }
}
