namespace MiniERP
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // Other properties specific to products

        // Composition: references to Customer and Supplier
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
    }
}