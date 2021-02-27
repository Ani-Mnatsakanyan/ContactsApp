using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс хранящий информацию о номере телефона
    /// </summary>
    public class TelephoneNumber
    {
        private static long _number;

        public static  long Number
        {
            get { return _number; }
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
        public TelephoneNumber(long number)
        {
            TelephoneNumber.Number = number;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public TelephoneNumber() { }
    }
}
