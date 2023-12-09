namespace MiniERP.Forms.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public Customer() { }

        public Customer(int CustomerId, string Name) { }
    }
}