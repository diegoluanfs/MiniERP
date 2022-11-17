using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Entidades
{
    public class Clientes
    {
        public Clientes(int id, string nome, string contato)
        {
            Id = id;
            Nome = nome;
            Contato = contato;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }

    }
}
