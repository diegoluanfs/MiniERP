using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Entidades
{
    public class Fornecedores
    {
        public Fornecedores(int id, string nome, string contato)
        {
            Id = id;
            Nome = nome;
            Contato = contato;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }


        public static List<Fornecedores> GetListaFornecedores()
        {
            var listaFornecedores = new List<Fornecedores>();

            listaFornecedores.Add(new Fornecedores(1, "Bom Coração", "55123456785"));
            listaFornecedores.Add(new Fornecedores(2, "Fritz e Frida", "55123456787"));
            listaFornecedores.Add(new Fornecedores(3, "Figueira", "55123456788"));
            listaFornecedores.Add(new Fornecedores(4, "Dona Maria", "55123456799"));
            listaFornecedores.Add(new Fornecedores(5, "Noal", "55123456789"));
            return listaFornecedores;
        }

    }
}
