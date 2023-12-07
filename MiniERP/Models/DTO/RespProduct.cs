namespace MiniERP
{
    public class RespProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // Other properties specific to products

        // Composition: references to Customer and Supplier
        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
    }
}