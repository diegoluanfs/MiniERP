namespace MiniERP.Forms.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }

        public string IdAndName => $"{SupplierId} - {Name}";
    }
}