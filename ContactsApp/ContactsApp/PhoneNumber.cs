using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс хранящий информацию о номере телефона
    /// </summary>
    public class PhoneNumber : IEquatable<PhoneNumber>
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        private long _number;

        /// <summary>
        /// Задает номер телефона
        /// Тефонный номер должен быть 11 цифр и начинаться с 7
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public long Number
        {
            get => _number;
            set
            {
                if (value >= 70000000000 && value <= 79999999999)
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Ошибка. Номер должен содержать 11 цифр, первая цифра должна быть 7");
                }
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PhoneNumber() { }

        public bool Equals(PhoneNumber other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _number == other._number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((PhoneNumber) obj);
        }

        public override int GetHashCode()
        {
            return _number.GetHashCode();
        }
    }
}
