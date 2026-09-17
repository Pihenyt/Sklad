namespace Sklad
{

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectionId { get; set; }
        public int StorekeeperId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalValue
        {
            get { return Quantity * Price; }
        }
        public bool IsLowStock(int threshold)
        {
            return Quantity < threshold;
        }
        public string GetInfo()
        {
            return Name + " (" + Quantity + " шт., " + Price + " руб.)";
        }
    }
}
