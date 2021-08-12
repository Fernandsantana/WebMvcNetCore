using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcNetCore.Data;
using WebMvcNetCore.Models;

namespace WebMvcNetCore.Serviços
{
    public class ServicoVendedor
    {
        private readonly WebMvcNetCoreContext _context;

        public ServicoVendedor(WebMvcNetCoreContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
    }
}
