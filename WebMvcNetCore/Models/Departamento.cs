using System.Collections.Generic;
using System;
using System.Linq;

namespace WebMvcNetCore.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {

        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddVendedor(Vendedor v)
        {
            Vendedores.Add(v);
        }

        public double TotalVenda(DateTime inicial, DateTime final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVenda(inicial, final));
        }
    }
}
