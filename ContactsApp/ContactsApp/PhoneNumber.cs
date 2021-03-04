using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс хранящий информацию о номере телефона
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        private static long _number;

        /// <summary>
        /// Задает номер телефона
        /// Тефонный номер должен быть 11 цифр и начинаться с 7
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public static  long Number
        {
            get
            {
                return _number;
            }
            set
            {
                if ((value >= 70000000000 && value <= 79999999999))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("Ошибка. Номер должен содержать 11 цифр, первая цифра должна быть 7");
                }
            }
        }

        /// <summary>
        /// Конструктор, принимающий на вход номер
        /// </summary>
        /// <param name="number">номер телефона</param> 
        public PhoneNumber(long number)
        {
            PhoneNumber.Number = number;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PhoneNumber() { }
    }
}
