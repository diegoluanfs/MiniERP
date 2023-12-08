// CustomerLogic.cs
using System;
using System.Windows.Forms;

namespace MiniERP.Logic
{
    public class CustomerLogic
    {
        public static void ProcessCustomerData(Form form, string customerId, string customerName, string escritoNoBotao)
        {
            if(escritoNoBotao == "Buscar por ID")
            {
                MessageBox.Show("Buscar por ID");
            }
            else if (escritoNoBotao == "Adicionar")
            {
                MessageBox.Show("Adicionar");
            }
            else
            {
                MessageBox.Show("Listar Tudo");
            }


            //MessageBox.Show($"ID: {customerId}, Nome: {customerName}, Escrito no botão: {escritoNoBotao}", "Informações do Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //if (string.IsNullOrWhiteSpace(customerId) || string.IsNullOrWhiteSpace(customerName))
            //{
            //    MessageBox.Show("ID e Nome do cliente devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    MessageBox.Show($"ID: {customerId}, Nome: {customerName}", "Informações do Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        internal static void AddCustomer(Form form, string customerName)
        {
            throw new NotImplementedException();
        }

        internal static void SearchCustomerById(Form form, string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
