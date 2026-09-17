using System;
using System.Collections.Generic;
using System.Text;

namespace Sklad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 - InMemoryRepository");
            Console.WriteLine("2 - CsvRepository");
            Console.Write("Ваш выбор: ");

            string input = Console.ReadLine();
            int choice;
            if (!int.TryParse(input, out choice))
            {
                choice = 0;
            }
            List<Section> sections;
            List<Storekeeper> storekeepers;
            List<Item> items;
            switch (choice)
            {
                case 1:
                    InMemoryRepository inMemoryRepository = new InMemoryRepository();
                    sections = inMemoryRepository.GetSections();
                    storekeepers = inMemoryRepository.GetStorekeepers();
                    items = inMemoryRepository.GetItems();
                    break;
                case 2:
                    CsvRepository csvRepository = new CsvRepository("data");
                    sections = csvRepository.GetSections();
                    storekeepers = csvRepository.GetStorekeepers();
                    items = csvRepository.GetItems();
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    return;
            }
            Console.WriteLine();
            Storekeeper foundStorekeeper = FindStorekeeper
                (items, storekeepers, "Болты М8");
            Console.WriteLine("1. FindStorekeeper(\"Болты М8\"): " +
                (foundStorekeeper != null ? foundStorekeeper.GetInfo() : "null"));

            Item sampleItem = FindItemByName(items, "Болты М8");

            Section foundSection = sampleItem != null ? 
                FindSection(sections, sampleItem) : null;

            Console.WriteLine("2. FindSection(item \"Болты М8\"): " +
                (foundSection != null ? foundSection.GetInfo() : "null"));

            int totalQuantity = GetTotalQuantity(items);
            Console.WriteLine("3. GetTotalQuantity: " + totalQuantity + " шт.");

            int threshold = 100;
            List<Item> lowStockItems = GetItemsBelowThreshold(items, threshold);
            Console.Write("4. GetItemsBelowThreshold(" + threshold + "): ");
            for (int i = 0; i < lowStockItems.Count; i++)
            {
                Console.Write(lowStockItems[i].Name + " (" + 
                    lowStockItems[i].Quantity + ")");
                if (i < lowStockItems.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();

            Console.WriteLine("5. PrintAllItems:");
            PrintAllItems(items, sections, storekeepers);

            Console.WriteLine();
            Console.WriteLine("Не найдено: FindStorekeeper" +
                "(\"Неизвестный товар\") -> " +
                (FindStorekeeper(items, storekeepers, 
                "Неизвестный товар") == null ? "null" : "ошибка"));
        }
        private static Item FindItemByName(List<Item> items, string itemName)
        {
            foreach (Item item in items)
            {
                if (item.Name == itemName)
                {
                    return item;
                }
            }
            return null;
        }
        public static Storekeeper FindStorekeeper
            (List<Item> items, List<Storekeeper> storekeepers, string itemName)
        {
            Item foundItem = FindItemByName(items, itemName);
            if (foundItem == null)
            {
                return null;
            }
            foreach (Storekeeper storekeeper in storekeepers)
            {
                if (storekeeper.Id == foundItem.StorekeeperId)
                {
                    return storekeeper;
                }
            }

            return null;
        }
        public static Section FindSection(List<Section> sections, Item item)
        {
            foreach (Section section in sections)
            {
                if (section.Id == item.SectionId)
                {
                    return section;
                }
            }
            return null;
        }
        public static int GetTotalQuantity(List<Item> items)
        {
            int total = 0;
            foreach (Item item in items)
            {
                total += item.Quantity;
            }
            return total;
        }
        public static List<Item> GetItemsBelowThreshold(List<Item> items, int threshold)
        {
            List<Item> result = new List<Item>();
            foreach (Item item in items)
            {
                if (item.Quantity < threshold)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static void PrintAllItems
            (List<Item> items, List<Section> sections, List<Storekeeper> storekeepers)
        {
            foreach (Item item in items)
            {
                Storekeeper storekeeper = null;
                foreach (Storekeeper s in storekeepers)
                {
                    if (s.Id == item.StorekeeperId)
                    {
                        storekeeper = s;
                        break;
                    }
                }
                Section section = FindSection(sections, item);

                string storekeeperName = storekeeper != null ? storekeeper.FullName : "—";
                string sectionName = section != null ? section.Name : "—";

                Console.WriteLine("\"" + item.GetInfo() + "\" — кладовщик " + storekeeperName +
                    ", секция \"" + sectionName + "\"");
            }
        }
    }
}
