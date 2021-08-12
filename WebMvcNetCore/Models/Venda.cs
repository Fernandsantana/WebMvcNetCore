using System;
using WebMvcNetCore.Models.Enums;

namespace WebMvcNetCore.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public double Quantidade { get; set; }

        public StatusVenda Status { get; set; }

        public Vendedor Vendedor { get; set; }

        public Venda()
        {

        }

        public Venda(int id, DateTime data, double quantidade, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantidade = quantidade;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
