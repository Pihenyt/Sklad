using System;

namespace Sklad
{
    /// <summary>
    /// Кладовщик, отвечающий за товары на складе.
    /// </summary>
    public class Storekeeper
    {
        private int _id;
        private string _fullName = string.Empty;
        private string _shift = string.Empty;
        private int _experience;
        /// <summary>
        /// Уникальный идентификатор кладовщика. Не может быть отрицательным.
        /// </summary>
        public int Id
        {
            get => _id;
            init => _id = ValidateId(value);
        }
        /// <summary>
        /// Полное имя кладовщика. Не может быть пустым.
        /// </summary>
        public string FullName
        {
            get => _fullName;
            init => _fullName = ValidateFullName(value);
        }
        /// <summary>
        /// Смена, в которую работает кладовщик (например, "Утренняя"). Не может быть пустой.
        /// </summary>
        public string Shift
        {
            get => _shift;
            init => _shift = ValidateShift(value);
        }
        /// <summary>
        /// Стаж работы в годах. Не может быть отрицательным.
        /// </summary>
        public int Experience
        {
            get => _experience;
            init => _experience = ValidateExperience(value);
        }
        /// <summary>
        /// Признак утренней смены.
        /// </summary>
        public bool IsMorningShift => Shift == "Утренняя";
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Storekeeper()
        {
        }
        /// <summary>
        /// Конструктор с полным набором параметров и проверкой значений.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Если идентификатор или стаж отрицательные, либо имя или смена пустые.
        /// </exception>
        public Storekeeper(int id, string fullName, string shift, int experience)
        {
            Id = ValidateId(id);
            FullName = ValidateFullName(fullName);
            Shift = ValidateShift(shift);
            Experience = ValidateExperience(experience);
        }
        /// <summary>
        /// Конструктор без идентификатора (удобно для новых записей).
        /// </summary>
        public Storekeeper(string fullName, string shift, int experience)
            : this(0, fullName, shift, experience)
        {
        }
        /// <summary>
        /// Возвращает краткую информацию о кладовщике.
        /// </summary>
        public string GetInfo()
        {
            return $"{FullName} ({Experience} {GetYearWord(Experience)} опыта)";
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
        /// Проверяет имя: не может быть пустым или состоять из пробелов.
        /// </summary>
        private static string ValidateFullName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Имя не может быть пустым.", nameof(FullName));
            }
            return value;
        }
        /// <summary>
        /// Проверяет смену: не может быть пустой.
        /// </summary>
        private static string ValidateShift(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Смена не может быть пустой.", nameof(Shift));
            }
            return value;
        }
        /// <summary>
        /// Проверяет стаж: не может быть отрицательным.
        /// </summary>
        private static int ValidateExperience(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Стаж не может быть отрицательным.", nameof(Experience));
            }
            return value;
        }
        /// <summary>
        /// Подбирает правильную форму слова "год" для числа лет.
        /// </summary>
        private static string GetYearWord(int years)
        {
            int rem100 = years % 100;
            int rem10 = years % 10;
            if (rem100 >= 11 && rem100 <= 14) return "лет";
            if (rem10 == 1) return "год";
            if (rem10 >= 2 && rem10 <= 4) return "года";
            return "лет";
        }
    }
}