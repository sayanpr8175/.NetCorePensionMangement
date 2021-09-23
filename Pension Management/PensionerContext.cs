using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pension_Management
{
    public class PensionerContext:DbContext
    {
        public PensionerContext(DbContextOptions options) : base(options) { }
        public DbSet<Pensioner> Pensioners { get; set; }
    }
}
