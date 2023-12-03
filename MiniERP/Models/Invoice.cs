namespace MiniERP
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        // Other properties specific to invoices

        // Composition: references to Customer, Product, and Supplier
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public Supplier Supplier { get; set; }
    }
}