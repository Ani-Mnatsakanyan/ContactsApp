using System;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий информацию о контакте:
    /// имя, фамилия, почта, idvk
    /// </summary>
    public class Contact : IEquatable<Contact>, IComparable<Contact>
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Почта
        /// </summary>
        private string _email;

        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateTime _birthDate;

        /// <summary>
        /// idVk
        /// </summary>
        private string _idVK;

        /// <summary>
        /// Свойства фамилии
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                ValidateTitleLength(value);
                value = ToCorrectRegister(value);
                _surname = value;
            }
        }

        /// <summary>
        /// Свойства имени
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                ValidateTitleLength(value);
                value = ToCorrectRegister(value);
                _name = value;
            }
        }

        /// <summary>
        /// Свойство номера телефона
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

        /// <summary>
        /// Свойства даты рождения
        /// </summary>
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                DateTime nowDate = DateTime.Now;
                if (value.Year < 1900 || value.Date > nowDate || value == null)
                {
                    throw new ArgumentException("Ошибка. Некорректная дата ");
                }
                _birthDate = value;
            }
        }

        /// <summary>
        /// Свойство почты
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                ValidateTitleLength(value);
                _email = value;
            }
        }

        /// <summary>
        /// Свойство idVk
        /// </summary>
        public string IdVK
        {
            get => _idVK;
            set
            { 
                if (value.Length > 15)
                {
                    throw new ArgumentException("Ошибка. id в VK не должен быть более 15 символов");
                }
                ValidateTitleLength(value);
                _idVK = value;
            }
        }

        /// <summary>
        /// Метод для проверки значений. Строка не должна быть пустой или превышать 50 символов.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception> 
        void ValidateTitleLength(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Ошибка. Пустая строка");
            }
            if (str.Length > 50)
            {
                throw new ArgumentException("Ошибка. Значение не должно превышать 50 символов");
            }
        }

        /// <summary>
        /// Метод, преобразующий к верхнему регистру первый символ.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string ToCorrectRegister(string value)
        {
            return value.Substring(0, 1).ToUpper() + value.Remove(0, 1);
        }

        /// <summary>
        /// конструктор класса по умолчанию
        /// </summary>
        public Contact() { }

        /// <summary>
        /// конструктор со всеми полями класса
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="birthDate">День Рождения</param>
        /// <param name="email">Электроонная почта</param>
        /// <param name="number">Телефнный номер</param>
        /// <param name="idVK">ID Вконтакте</param>
        [JsonConstructor]
        public Contact(string name, string surname, string email, string idVK, 
            DateTime birthDate, PhoneNumber number)
        {
            this.BirthDate = birthDate;
            this.Email = email;
            this.IdVK = idVK;
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = number;
        }

        public bool Equals(Contact other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _surname == other._surname 
                   && _name == other._name 
                   && _email == other._email 
                   && _birthDate.Equals(other._birthDate) 
                   && _idVK == other._idVK 
                   && Equals(PhoneNumber, other.PhoneNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Contact) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_surname != null ? _surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_email != null ? _email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _birthDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (_idVK != null ? _idVK.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PhoneNumber != null ? PhoneNumber.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <summary>
        /// Метод для реализации интерфейса IComporable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Contact other)
        {
            return other == null ? 1 : String.Compare(_surname, other._surname, StringComparison.Ordinal);
        }
    }
}
