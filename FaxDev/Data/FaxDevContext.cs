using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FaxDev.Models;

namespace FaxDev.Data
{
    public class FaxDevContext : DbContext
    {
        public FaxDevContext (DbContextOptions<FaxDevContext> options)
            : base(options)
        {
        }

        public DbSet<FaxDev.Models.UserModel> UserModel { get; set; } = default!;

        public DbSet<FaxDev.Models.PostVedette>? PostVedette { get; set; }

        public DbSet<FaxDev.Models.Homepage>? Homepage { get; set; }
      
    }
}
