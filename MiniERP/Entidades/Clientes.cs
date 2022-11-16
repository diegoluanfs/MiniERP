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


        public static List<Clientes> GetListaClientes()
        {
            var listaClientes = new List<Clientes>();

            listaClientes.Add(new Clientes(1, "Diego", "55966666666"));
            listaClientes.Add(new Clientes(2, "Luan", "55977777777"));
            listaClientes.Add(new Clientes(3, "Ferreira", "55988888888"));
            listaClientes.Add(new Clientes(4, "Silva", "55999999999"));

            return listaClientes;
        }

    }
}
