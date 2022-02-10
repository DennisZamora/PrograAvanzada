using System;
using System.Collections.Generic;
using System.Text;
using BE.DAL.DO.Objectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BE.DAL.EF
{
    public partial class NDbContext : DbContext
    {
        public NDbContext()
        {
        }

        public NDbContext(DbContextOptions<NDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Categories> Categories { get; set; }

    }
}
