using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class LegateDbContextFactory : DesignTimeDbContextFactoryBase<LegateDbContext>
    {
        protected override LegateDbContext CreateNewInstance(DbContextOptions<LegateDbContext> options)
        {
            return new LegateDbContext(options);
        }
    }
}
