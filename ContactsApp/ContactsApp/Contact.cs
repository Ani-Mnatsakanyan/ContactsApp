﻿using System;
using Newtonsoft.Json;

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
            get
            {
                return _name;
            }
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
        public PhoneNumber Number { get; set; } = new PhoneNumber();

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
                ValidateTitleLength(value);
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
           // var condition = 0;
            if (str == null || str == String.Empty)
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
            DateTime birthDate, long number)
        {
            this.BirthDate = birthDate;
            this.Email = email;
            this.IdVK = idVK;
            this.Name = name;
            this.Surname = surname;
            this.Number = new PhoneNumber(number);
        }

        /// <summary>
        /// Метод, реализующий копирование объекта
        /// </summary>
        /// <returns>Воозвращает новый объект == копия оригинала </returns>
        public object Clone()
        {
            return new Contact(this.Name, this.Surname, this.Email, this.IdVK,
                this.BirthDate, this.Number.Number);
        }
    }
}
