namespace Sklad
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public bool IsBig
        {
            get { return Area > 200; }
        }
        public string GetInfo()
        {
            return Name + " (" + Area + " м²)";
        }
    }
}
