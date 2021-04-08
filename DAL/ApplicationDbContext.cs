using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using INTEX2.Models;

#nullable disable

namespace INTEX2.DAL
{
    /// <summary>
    /// DbContext provided by scaffolding.
    /// </summary>
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
