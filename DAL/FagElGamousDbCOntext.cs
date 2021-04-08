using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using INTEX2.Models;

#nullable disable

namespace INTEX2.DAL
{
    public partial class FagElGamousDbCOntext : DbContext
    {
        public FagElGamousDbCOntext()
        {
        }

        public FagElGamousDbCOntext(DbContextOptions<FagElGamousDbCOntext> options)
            : base(options)
        { }
    }
}
