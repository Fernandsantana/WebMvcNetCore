using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace WebMvcNetCore.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} necessário")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho do {0} deve ser entre {1} a {2}")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} necessário")]
        [EmailAddress(ErrorMessage = "{0} inválido")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} necessário")]
        [Display (Name = "Aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Aniversario { get; set; }

        [Required(ErrorMessage = "{0} necessário")]
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Range(0.0, 10000.0, ErrorMessage = "{0} deve ser entre {1} a {2}")]
        public double Salario { get; set; }

        public Departamento Departamento { get; set; }

        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }

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
