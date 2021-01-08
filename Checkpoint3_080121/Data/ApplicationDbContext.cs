using Checkpoint3_080121.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint3_080121.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Models.Annonce> Annonce { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
    }

}
