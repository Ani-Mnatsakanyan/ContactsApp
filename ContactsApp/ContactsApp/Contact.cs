using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий информацию о контакте:
    /// имя, фамилия, почта, idvk
    /// </summary>
    public class Contact : ICloneable
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
            get
            {
                return _surname;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Ошибка. Фамилия не должна содержать более 50 символов");
                }
                else if (value == string.Empty || value == null)
                {
                    throw new ArgumentException("Ошибка. Пустая строка");
                }
                else
                {
                    value = value.Substring(0, 1).ToUpper() + value.Remove(0, 1);
                    _surname = value;
                }
            }
        }

        /// <summary>
        /// Свойства имени
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Ошибка. Имя не должно содержать более 50 символов");
                }
                else if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Ошибка. Пустая строка");
                }
                else
                {
                    value = value.Substring(0, 1).ToUpper() + value.Remove(0, 1);
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Свойство номера телефона
        /// </summary>
        public PhoneNumber Number { get; set; }

        /// <summary>
        /// Свойства даты рождения
        /// </summary>
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
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
            get
            {
                return _email;
            }
            set
            {
                if (value.Length > 50 && value != null)
                {
                    throw new ArgumentException("Ошибка. Почта не должна содержать более 50 символов");
                }
                _email = value;
            }
        }

        /// <summary>
        /// Свойство idVk
        /// </summary>
        public string IdVK
        {
            get
            {
                return _idVK;
            }
            set
            {
                if (value.Length > 15 && value != null)
                {
                    throw new ArgumentException("Ошибка. id в VK не должен быть более 15 символов");
                }
                _idVK = value;
            }
        }

        /// <summary>
        /// конструктор класса по умолчанию
        /// </summary>
        public Contact() { }

        /// <summary>
        /// конструктор со всеми полями класса
        /// </summary>
        /// <param name="surname"Фамилия></param>
        /// <param name="name"Имя></param>
        /// <param name="birthDate"День Рождения></param>
        /// <param name="email"Электроонная почта></param>
        /// <param name="number"Телефнный номер></param>
        /// <param name="idVK"ID Вконтакте></param>
        public Contact(string name, string surname, string email, string idVK, 
            DateTime birthDate, long number)
        {
            this.BirthDate = birthDate;
            this.Email = email;
            this.IdVK = idVK;
            this.Name = name;
            this.Surname = surname;
            PhoneNumber.Number = number;
        }

        /// <summary>
        /// Метод, реализующий копирование объекта
        /// </summary>
        /// <returns>Воозвращает новый объект == копия оригинала </returns>
        public object Clone()
        {
            return new Contact(this.Name, this.Surname, this.Email, this.IdVK,
                this.BirthDate, PhoneNumber.Number);
        }
    }
}
