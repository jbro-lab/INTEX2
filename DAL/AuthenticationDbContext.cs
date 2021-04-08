using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.DAL
{
    public class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext() 
        { }

        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) :
            base(options) 
        { }
    }
}
