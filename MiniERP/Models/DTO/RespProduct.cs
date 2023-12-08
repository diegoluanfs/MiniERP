namespace MiniERP
{
    public class RespProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Supplier Supplier { get; set; }
    }
}