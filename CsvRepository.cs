using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Sklad
{
    /// <summary>
    /// Репозиторий, читающий данные из CSV-файлов на диске.
    /// </summary>
    public class CsvRepository
    {
        private string _basePath;
        /// <summary>
        /// Создаёт репозиторий, указывая папку с CSV-файлами (sections.csv, storekeepers.csv, items.csv).
        /// </summary>
        public CsvRepository(string basePath)
        {
            _basePath = basePath;
        }
        /// <summary>
        /// Считывает и возвращает список секций из файла sections.csv.
        /// </summary>
        public List<Section> GetSections()
        {
            List<Section> result = new List<Section>();
            string path = Path.Combine(_basePath, "sections.csv");
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2)
            {
                Console.WriteLine($"Файл {path} пуст или содержит только заголовок.");
                return result;
            }
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3)
                {
                    continue;
                }
                Section section = new Section
                {
                    Id = int.Parse(parts[0], CultureInfo.InvariantCulture),
                    Name = parts[1],
                    Area = int.Parse(parts[2], CultureInfo.InvariantCulture)
                };
                result.Add(section);
            }
            return result;
        }
        /// <summary>
        /// Считывает и возвращает список кладовщиков из файла storekeepers.csv.
        /// </summary>
        public List<Storekeeper> GetStorekeepers()
        {
            List<Storekeeper> result = new List<Storekeeper>();
            string path = Path.Combine(_basePath, "storekeepers.csv");
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2)
            {
                Console.WriteLine($"Файл {path} пуст или содержит только заголовок.");
                return result;
            }
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }
                string[] parts = lines[i].Split(',');
                if (parts.Length < 4)
                {
                    continue;
                }
                Storekeeper storekeeper = new Storekeeper
                {
                    Id = int.Parse(parts[0], CultureInfo.InvariantCulture),
                    FullName = parts[1],
                    Shift = parts[2],
                    Experience = int.Parse(parts[3], CultureInfo.InvariantCulture)
                };
                result.Add(storekeeper);
            }
            return result;
        }
        /// <summary>
        /// Считывает и возвращает список товаров из файла items.csv.
        /// </summary>
        public List<Item> GetItems()
        {
            List<Item> result = new List<Item>();
            string path = Path.Combine(_basePath, "items.csv");
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2)
            {
                Console.WriteLine($"Файл {path} пуст или содержит только заголовок.");
                return result;
            }
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }
                string[] parts = lines[i].Split(',');
                if (parts.Length < 6)
                {
                    continue;
                }
                Item item = new Item
                {
                    Id = int.Parse(parts[0], CultureInfo.InvariantCulture),
                    Name = parts[1],
                    SectionId = int.Parse(parts[2], CultureInfo.InvariantCulture),
                    StorekeeperId = int.Parse(parts[3], CultureInfo.InvariantCulture),
                    Quantity = int.Parse(parts[4], CultureInfo.InvariantCulture),
                    Price = decimal.Parse(parts[5], CultureInfo.InvariantCulture)
                };
                result.Add(item);
            }
            return result;
        }
    }
}