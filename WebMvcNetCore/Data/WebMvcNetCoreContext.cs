using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMvcNetCore.Models;

namespace WebMvcNetCore.Data
{
    public class WebMvcNetCoreContext : DbContext
    {
        public WebMvcNetCoreContext (DbContextOptions<WebMvcNetCoreContext> options)
            : base(options)
        {
        }

        public DbSet<WebMvcNetCore.Models.Departamento> Departamento { get; set; }
    }
}
