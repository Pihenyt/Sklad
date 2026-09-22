using System.Collections.Generic;

namespace Sklad
{
    /// <summary>
    /// Репозиторий, хранящий тестовые данные в оперативной памяти.
    /// </summary>
    public class InMemoryRepository
    {
        private List<Section> _sections;
        private List<Storekeeper> _storekeepers;
        private List<Item> _items;
        /// <summary>
        /// Заполняет коллекции тестовыми, 
        /// согласованными по внешним ключам данными.
        /// </summary>
        public InMemoryRepository()
        {
            _sections = new List<Section>
            {
                new Section(1, "Метизы",         300),
                new Section(2, "Инструменты",    150),
                new Section(3, "Электроника",    250),
                new Section(4, "Стройматериалы", 400),
                new Section(5, "Спецодежда",     100)
            };
            _storekeepers = new List<Storekeeper>
            {
                new Storekeeper(1, "Петров П.П.",   "Утренняя", 5),
                new Storekeeper(2, "Иванов И.И.",   "Вечерняя", 3),
                new Storekeeper(3, "Сидорова А.А.", "Утренняя", 8),
                new Storekeeper(4, "Кузнецов Д.Д.", "Вечерняя", 2),
                new Storekeeper(5, "Смирнова Е.В.", "Утренняя", 6)
            };
            _items = new List<Item>
            {
                new Item(1, "Болты М8",    1, 1, 1000, 5m),
                new Item(2, "Гайки М8",    1, 1, 50,   3m),
                new Item(3, "Шайбы М8",    1, 3, 80,   2m),
                new Item(4, "Дрель",       2, 2, 15,   3500m),
                new Item(5, "Отвёртка",    2, 2, 200,  150m),
                new Item(6, "Кабель ВВГ",  3, 5, 500,  45m),
                new Item(7, "Цемент М500", 4, 4, 300,  350m),
                new Item(8, "Перчатки",    5, 5, 30,   80m)
            };
        }
        /// <summary>
        /// Возвращает список всех секций склада.
        /// </summary>
        public List<Section> GetSections() => _sections;
        /// <summary>
        /// Возвращает список всех кладовщиков.
        /// </summary>
        public List<Storekeeper> GetStorekeepers() => _storekeepers;
        /// <summary>
        /// Возвращает список всех товаров.
        /// </summary>
        public List<Item> GetItems() => _items;
    }
}