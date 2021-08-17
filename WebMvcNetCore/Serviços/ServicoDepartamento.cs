using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcNetCore.Data;
using WebMvcNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace WebMvcNetCore.Serviços
{
    public class ServicoDepartamento
    {
        private readonly WebMvcNetCoreContext _context;

        public ServicoDepartamento(WebMvcNetCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllaAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
