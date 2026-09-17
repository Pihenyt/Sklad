namespace Sklad
{
    public class Storekeeper
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Shift { get; set; }
        public int Experience { get; set; }
        public bool IsMorningShift
        {
            get { return Shift == "Утренняя"; }
        }
        public string GetInfo()
        {
            return FullName + " (" + Experience + " лет опыта)";
        }
    }
}
