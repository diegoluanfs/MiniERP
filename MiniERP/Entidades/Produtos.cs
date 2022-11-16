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

        public static List<Produtos> GetListaProdutos()
        {
            var listaProdutos = new List<Produtos>();

            listaProdutos.Add(new Produtos(1, "Açucar", 5, 3.80, "Bom Coração"));
            listaProdutos.Add(new Produtos(2, "Feijão", 8, 9.40, "Fritz e Frida"));
            listaProdutos.Add(new Produtos(3, "Arroz", 3, 8.80, "Figueira"));
            listaProdutos.Add(new Produtos(4, "Farinha", 10, 6.70, "Dona Maria"));
            listaProdutos.Add(new Produtos(5, "Azeite", 7, 10.20, "Noal"));

            return listaProdutos;
        }
    }
}
