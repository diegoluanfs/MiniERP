using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Entidades
{
    public class Produtos
    {
        public Produtos(int id, string nome, int qtdEstoque, double preco, string fornecedor)
        {
            Id = id;
            Nome = nome;
            QtdEstoque = qtdEstoque;
            Preco = preco;
            Fornecedor = fornecedor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdEstoque { get; set; }
        public double Preco { get; set; }
        public string Fornecedor { get; set; }

    }
}
