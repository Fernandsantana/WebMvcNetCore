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

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Venda> Venda { get; set; }
    }
}
