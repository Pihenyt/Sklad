using System;

namespace Sklad
{
    /// <summary>
    /// Секция склада — место хранения товаров.
    /// </summary>
    public class Section
    {
        private int _id;
        private string _name = string.Empty;
        private int _area;
        /// <summary>
        /// Уникальный идентификатор секции. Не может быть отрицательным.
        /// </summary>
        public int Id
        {
            get => _id;
            init => _id = ValidateId(value);
        }
        /// <summary>
        /// Название секции. Не может быть пустым.
        /// </summary>
        public string Name
        {
            get => _name;
            init => _name = ValidateName(value);
        }
        /// <summary>
        /// Площадь секции в квадратных метрах. Не может быть отрицательной.
        /// </summary>
        public int Area
        {
            get => _area;
            init => _area = ValidateArea(value);
        }
        /// <summary>
        /// Признак большой секции: площадь больше 200 м².
        /// </summary>
        public bool IsBig => Area > 200;
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Section()
        {
        }
        /// <summary>
        /// Конструктор с полным набором параметров и проверкой значений.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Если идентификатор или площадь отрицательные, либо название пустое.
        /// </exception>
        public Section(int id, string name, int area)
        {
            Id = ValidateId(id);
            Name = ValidateName(name);
            Area = ValidateArea(area);
        }
        /// <summary>
        /// Конструктор без идентификатора (удобно для новых записей).
        /// </summary>
        public Section(string name, int area)
            : this(0, name, area)
        {
        }
        /// <summary>
        /// Возвращает краткую информацию о секции.
        /// </summary>
        public string GetInfo()
        {
            return $"{Name} ({Area} м²)";
        }
        /// <summary>
        /// Проверяет идентификатор: не может быть отрицательным.
        /// </summary>
        private static int ValidateId(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Идентификатор не может быть отрицательным.", nameof(Id));
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
        /// Проверяет площадь: не может быть отрицательной.
        /// </summary>
        private static int ValidateArea(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Площадь не может быть отрицательной.", nameof(Area));
            }
            return value;
        }
    }
}