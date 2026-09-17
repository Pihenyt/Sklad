using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Sklad
{
    public class CsvRepository
    {
        private string _basePath;
        public CsvRepository(string basePath)
        {
            _basePath = basePath;
        }
        public List<Section> GetSections()
        {
            List<Section> result = new List<Section>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "sections.csv"));
            if (lines.Length < 2)
            {
                return result;
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3)
                {
                    continue;
                }
                Section section = new Section();
                section.Id = int.Parse(parts[0]);
                section.Name = parts[1];
                section.Area = int.Parse(parts[2]);
                result.Add(section);
            }
            return result;
        }
        public List<Storekeeper> GetStorekeepers()
        {
            List<Storekeeper> result = new List<Storekeeper>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "storekeepers.csv"));
            if (lines.Length < 2)
            {
                return result;
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 4)
                {
                    continue;
                }
                Storekeeper storekeeper = new Storekeeper();
                storekeeper.Id = int.Parse(parts[0]);
                storekeeper.FullName = parts[1];
                storekeeper.Shift = parts[2];
                storekeeper.Experience = int.Parse(parts[3]);
                result.Add(storekeeper);
            }
            return result;
        }
        public List<Item> GetItems()
        {
            List<Item> result = new List<Item>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "items.csv"));
            if (lines.Length < 2)
            {
                return result;
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 6)
                {
                    continue;
                }
                Item item = new Item();
                item.Id = int.Parse(parts[0]);
                item.Name = parts[1];
                item.SectionId = int.Parse(parts[2]);
                item.StorekeeperId = int.Parse(parts[3]);
                item.Quantity = int.Parse(parts[4]);
                item.Price = decimal.Parse(parts[5], CultureInfo.InvariantCulture);
                result.Add(item);
            }
            return result;
        }
    }
}
