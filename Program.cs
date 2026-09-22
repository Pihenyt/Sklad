using System;
using System.Collections.Generic;

namespace Sklad
{
    /// <summary>
    /// Точка входа в программу. Отвечает за выбор источника данных
    /// и демонстрацию аналитических методов.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Уникальный ключ источника данных в памяти.
        /// </summary>
        private static string InMemoryKey { get; } = "1";

        /// <summary>
        /// Уникальный ключ источника данных csv.
        /// </summary>
        private static string CsvKey { get; } = "2";

        /// <summary>
        /// Главный метод программы.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Section> sections;
            List<Storekeeper> storekeepers;
            List<Item> items;

            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine($"{InMemoryKey} - InMemoryRepository");
            Console.WriteLine($"{CsvKey} - CsvRepository");
            Console.Write("Ваш выбор: ");
            string key = (Console.ReadLine() ?? string.Empty).Trim();
            try
            {
                switch (key)
                {
                    case var k when k == InMemoryKey:
                        InMemoryRepository inMemoryRepository = new InMemoryRepository();
                        sections = inMemoryRepository.GetSections();
                        storekeepers = inMemoryRepository.GetStorekeepers();
                        items = inMemoryRepository.GetItems();
                        break;
                    case var k when k == CsvKey:
                        CsvRepository csvRepository = new CsvRepository("data");
                        sections = csvRepository.GetSections();
                        storekeepers = csvRepository.GetStorekeepers();
                        items = csvRepository.GetItems();
                        break;
                    default:
                        throw new ArgumentException("Неверный выбор");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении данных: {ex.Message}");
                return;
            }
            Console.WriteLine();
            Storekeeper? foundStorekeeper = FindStorekeeper(items, storekeepers, "Болты М8");
            Console.WriteLine("1. FindStorekeeper(\"Болты М8\"): " +
                (foundStorekeeper != null ? foundStorekeeper.GetInfo() : "null"));

            Section? foundSection = FindSection(items, sections, "Болты М8");
            Console.WriteLine("2. FindSection(item \"Болты М8\"): " +
                (foundSection != null ? foundSection.GetInfo() : "null"));

            int totalQuantity = GetTotalQuantity(items);
            Console.WriteLine($"3. GetTotalQuantity: {totalQuantity} шт.");

            int threshold = 100;
            List<Item> lowStockItems = GetItemsBelowThreshold(items, threshold);
            Console.Write($"4. GetItemsBelowThreshold({threshold}): ");
            for (int i = 0; i < lowStockItems.Count; i++)
            {
                Console.Write($"{lowStockItems[i].Name} ({lowStockItems[i].Quantity})");
                if (i < lowStockItems.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("5. PrintAllItems:");
            PrintAllItems(items, sections, storekeepers);
            Console.WriteLine();
            Storekeeper? notFound = FindStorekeeper(items, storekeepers, "Неизвестный товар");
            Console.WriteLine("Не найдено: FindStorekeeper(\"Неизвестный товар\") -> " +
                (notFound != null ? notFound.GetInfo() : "null"));
        }
        /// <summary>
        /// Ищет первый товар с указанным названием.
        /// </summary>
        private static Item? FindItemByName(List<Item> items, string itemName)
        {
            if (items == null) return null;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == itemName)
                {
                    return items[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Находит кладовщика, отвечающего за товар с заданным названием.
        /// </summary>
        public static Storekeeper? FindStorekeeper(List<Item> items, List<Storekeeper> storekeepers, string itemName)
        {
            if (items == null || storekeepers == null) return null;
            Item? foundItem = FindItemByName(items, itemName);
            if (foundItem == null) return null;
            for (int i = 0; i < storekeepers.Count; i++)
            {
                if (storekeepers[i].Id == foundItem.StorekeeperId)
                {
                    return storekeepers[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Находит секцию, в которой хранится товар с заданным названием.
        /// </summary>
        public static Section? FindSection(List<Item> items, List<Section> sections, string itemName)
        {
            if (items == null || sections == null) return null;
            Item? foundItem = FindItemByName(items, itemName);
            if (foundItem == null) return null;
            for (int i = 0; i < sections.Count; i++)
            {
                if (sections[i].Id == foundItem.SectionId)
                {
                    return sections[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Считает суммарное количество всех товаров на складе.
        /// </summary>
        public static int GetTotalQuantity(List<Item> items)
        {
            if (items == null) return 0;
            int total = 0;
            for (int i = 0; i < items.Count; i++)
            {
                total += items[i].Quantity;
            }
            return total;
        }
        /// <summary>
        /// Возвращает список товаров, количество которых меньше указанного порога.
        /// </summary>
        public static List<Item> GetItemsBelowThreshold(List<Item> items, int threshold)
        {
            List<Item> result = new List<Item>();
            if (items == null) return result;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Quantity < threshold)
                {
                    result.Add(items[i]);
                }
            }
            return result;
        }
        /// <summary>
        /// Печатает информацию о каждом товаре вместе с его кладовщиком и секцией.
        /// </summary>
        public static void PrintAllItems(List<Item> items, List<Section> sections, List<Storekeeper> storekeepers)
        {
            if (items == null || sections == null || storekeepers == null) return;
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                Storekeeper? storekeeper = null;
                for (int j = 0; j < storekeepers.Count; j++)
                {
                    if (storekeepers[j].Id == item.StorekeeperId)
                    {
                        storekeeper = storekeepers[j];
                        break;
                    }
                }
                Section? section = null;
                for (int j = 0; j < sections.Count; j++)
                {
                    if (sections[j].Id == item.SectionId)
                    {
                        section = sections[j];
                        break;
                    }
                }
                string storekeeperName = storekeeper != null ? storekeeper.FullName : "—";
                string sectionName = section != null ? section.Name : "—";

                Console.WriteLine($"\"{item.GetInfo()}\" — кладовщик {storekeeperName}, секция \"{sectionName}\"");
            }
        }
    }
}