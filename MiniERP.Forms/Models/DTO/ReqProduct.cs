namespace MiniERP.Forms.Models.DTO
{
    public class ReqProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public int CustomerId { get; set; }
    }
}