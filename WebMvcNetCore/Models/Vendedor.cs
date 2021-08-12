using System;
using System.Collections.Generic;
using System.Linq;


namespace WebMvcNetCore.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime Aniversario { get; set; }

        public double Salario { get; set; }

        public Departamento Departamento { get; set; }

        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, DateTime aniversario, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            Salario = salario;
            Departamento = departamento;
        }

        public void AddVenda(Venda v)
        {
            Vendas.Add(v);
        }

        public void RemoveVenda(Venda v)
        {
            Vendas.Remove(v);
        }

        public double TotalVenda(DateTime inicial, DateTime final)
        {
            return Vendas.Where(v => v.Data >= inicial && v.Data <= final).Sum(v => v.Quantidade);
        }

    }
}
