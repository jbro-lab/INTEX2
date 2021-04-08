using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using INTEX2.Models;

#nullable disable

namespace INTEX2.DAL
{
    public partial class FagElGamousDbContext : DbContext
    {
        public FagElGamousDbContext()
        {
        }

        public FagElGamousDbContext(DbContextOptions<FagElGamousDbContext> options)
            : base(options)
        { }
    }
}
