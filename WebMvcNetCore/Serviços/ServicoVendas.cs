using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcNetCore.Data;
using WebMvcNetCore.Models;

namespace WebMvcNetCore.Serviços
{
    public class ServicoVendas
    {
        private readonly WebMvcNetCoreContext _context;

        public ServicoVendas(WebMvcNetCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Venda>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Venda select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }
    }
}
