using System.Collections.Generic;

namespace Sklad
{
    public class InMemoryRepository
    {
        private List<Section> _sections;
        private List<Storekeeper> _storekeepers;
        private List<Item> _items;
        public InMemoryRepository()
        {
            _sections = new List<Section>
            {
                new Section { Id = 1, Name = "Метизы",         
                    Area = 300 },
                
                new Section { Id = 2, Name = "Инструменты",    
                    Area = 150 },
                
                new Section { Id = 3, Name = "Электроника",    
                    Area = 250 },
                
                new Section { Id = 4, Name = "Стройматериалы", 
                    Area = 400 },
                
                new Section { Id = 5, Name = "Спецодежда",     
                    Area = 100 }
            };
            _storekeepers = new List<Storekeeper>
            {
                new Storekeeper { Id = 1, FullName = "Петров П.П.",   
                    Shift = "Утренняя", Experience = 5 },
                
                new Storekeeper { Id = 2, FullName = "Иванов И.И.",   
                    Shift = "Вечерняя", Experience = 3 },
                
                new Storekeeper { Id = 3, FullName = "Сидорова А.А.", 
                    Shift = "Утренняя", Experience = 8 },
                
                new Storekeeper { Id = 4, FullName = "Кузнецов Д.Д.", 
                    Shift = "Вечерняя", Experience = 2 },
                
                new Storekeeper { Id = 5, FullName = "Смирнова Е.В.", 
                    Shift = "Утренняя", Experience = 6 }
            };
            _items = new List<Item>
            {
                new Item { Id = 1, Name = "Болты М8",     SectionId = 1, 
                    StorekeeperId = 1, Quantity = 1000, Price = 5m },
                
                new Item { Id = 2, Name = "Гайки М8",     SectionId = 1, 
                    StorekeeperId = 1, Quantity = 50,   Price = 3m },
                
                new Item { Id = 3, Name = "Шайбы М8",     SectionId = 1, 
                    StorekeeperId = 3, Quantity = 80,   Price = 2m },
                
                new Item { Id = 4, Name = "Дрель",        SectionId = 2, 
                    StorekeeperId = 2, Quantity = 15,   Price = 3500m },
                
                new Item { Id = 5, Name = "Отвёртка",     SectionId = 2, 
                    StorekeeperId = 2, Quantity = 200,  Price = 150m },
                
                new Item { Id = 6, Name = "Кабель ВВГ",   SectionId = 3, 
                    StorekeeperId = 5, Quantity = 500,  Price = 45m },
                
                new Item { Id = 7, Name = "Цемент М500",  SectionId = 4, 
                    StorekeeperId = 4, Quantity = 300,  Price = 350m },

                new Item { Id = 8, Name = "Перчатки",     SectionId = 5, 
                    StorekeeperId = 5, Quantity = 30,   Price = 80m }
            };
        }
        public List<Section> GetSections()
        {
            return _sections;
        }
        public List<Storekeeper> GetStorekeepers()
        {
            return _storekeepers;
        }
        public List<Item> GetItems()
        {
            return _items;
        }
    }
}
