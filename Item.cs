using System;

namespace Sklad
{
    /// <summary>
    /// Товар, хранящийся на складе.
    /// </summary>
    public class Item
    {
        private int _id;
        private string _name = string.Empty;
        private int _sectionId;
        private int _storekeeperId;
        private int _quantity;
        private decimal _price;
        /// <summary>
        /// Уникальный идентификатор товара. Не может быть отрицательным.
        /// </summary>
        public int Id
        {
            get => _id;
            init => _id = ValidateId(value, nameof(Id));
        }
        /// <summary>
        /// Название товара. Не может быть пустым.
        /// </summary>
        public string Name
        {
            get => _name;
            init => _name = ValidateName(value);
        }
        /// <summary>
        /// Идентификатор секции, в которой хранится товар. Не может быть отрицательным.
        /// </summary>
        public int SectionId
        {
            get => _sectionId;
            init => _sectionId = ValidateId(value, nameof(SectionId));
        }
        /// <summary>
        /// Идентификатор кладовщика, отвечающего за товар. Не может быть отрицательным.
        /// </summary>
        public int StorekeeperId
        {
            get => _storekeeperId;
            init => _storekeeperId = ValidateId(value, nameof(StorekeeperId));
        }
        /// <summary>
        /// Количество товара на складе, шт. Не может быть отрицательным.
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            init => _quantity = ValidateQuantity(value);
        }
        /// <summary>
        /// Цена за единицу товара, руб. Не может быть отрицательной.
        /// </summary>
        public decimal Price
        {
            get => _price;
            init => _price = ValidatePrice(value);
        }
        /// <summary>
        /// Общая стоимость товара на складе (Quantity * Price).
        /// </summary>
        public decimal TotalValue => Quantity * Price;
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Item()
        {
        }
        /// <summary>
        /// Конструктор с полным набором параметров и проверкой значений.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Если идентификаторы, количество или цена отрицательные, либо название пустое.
        /// </exception>
        public Item(int id, string name, int sectionId, int storekeeperId, int quantity, decimal price)
        {
            Id = ValidateId(id, nameof(Id));
            Name = ValidateName(name);
            SectionId = ValidateId(sectionId, nameof(SectionId));
            StorekeeperId = ValidateId(storekeeperId, nameof(StorekeeperId));
            Quantity = ValidateQuantity(quantity);
            Price = ValidatePrice(price);
        }
        /// <summary>
        /// Конструктор без идентификатора (удобно для новых записей).
        /// </summary>
        public Item(string name, int sectionId, int storekeeperId, int quantity, decimal price)
            : this(0, name, sectionId, storekeeperId, quantity, price)
        {
        }
        /// <summary>
        /// Признак того, что количество товара ниже указанного порога.
        /// </summary>
        /// <param name="threshold">Пороговое значение количества.</param>
        public bool IsLowStock(int threshold)
        {
            return Quantity < threshold;
        }
        /// <summary>
        /// Возвращает краткую информацию о товаре.
        /// </summary>
        public string GetInfo()
        {
            return $"{Name} ({Quantity} шт., {Price} руб.)";
        }
        /// <summary>
        /// Проверяет идентификатор: не может быть отрицательным.
        /// </summary>
        private static int ValidateId(int value, string paramName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Идентификатор {paramName} не может быть отрицательным.", paramName);
            }
            return value;
        }
        /// <summary>
        /// Проверяет название: не может быть пустым или состоять из пробелов.
        /// </summary>
        private static string ValidateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Название не может быть пустым.", nameof(Name));
            }
            return value;
        }
        /// <summary>
        /// Проверяет количество: не может быть отрицательным.
        /// </summary>
        private static int ValidateQuantity(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Количество не может быть отрицательным.", nameof(Quantity));
            }
            return value;
        }
        /// <summary>
        /// Проверяет цену: не может быть отрицательной.
        /// </summary>
        private static decimal ValidatePrice(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Цена не может быть отрицательной.", nameof(Price));
            }
            return value;
        }
    }
}