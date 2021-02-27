using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий информацию об одном контакте
    /// </summary>
    public class TelephoneContact
   {
       
        private string _surname;
       /// <summary>
       /// метод с использование свойств set/get для фамилии
       /// </summary>
       public string Surname
       {
           get { return _surname; }
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

       private string _name;
       /// <summary>
       /// метод с использование свойств set/get для имени
       /// </summary>
        public string Name
       {
           get { return _name; }
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

        private TelephoneNumber _number;
        /// <summary>
        /// метод с использование свойств set/get для телефона
        /// </summary>
        public TelephoneNumber Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private DateTime _birthDate;
        /// <summary>
        /// метод с использование свойств set/get для даты рождения
        /// </summary>
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                DateTime nowDate = DateTime.Now;
                if (value.Year < 1900 || value.Date > nowDate || value == null)
                {
                    throw new ArgumentException("Ошибка. Некорректная дата ");
                }
                else
                {
                    _birthDate = value;
                }
            }
        }

        private string _email;
        /// <summary>
        /// метод с использование свойств set/get для почты
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Length > 50 && value != null)
                {
                    throw new ArgumentException("Ошибка. Почта не должна содержать более 50 символов");
                }
                else
                {
                    _email = value;
                }
            }
        }

        private string _idVK;
        /// <summary>
        /// метод с использование свойств set/get для idVk
        /// </summary>
        public string IdVK
        {
            get { return _idVK; }
            set
            {
                if (value.Length > 15 && value != null)
                {
                    throw new ArgumentException("Ошибка. id в VK не должен быть более 15 символов");
                }
                else
                {
                    _idVK = value;
                }
            }
        }
        public TelephoneContact()
        {
         
        }
        /// <summary>
        /// конструктор со всеми полями класса
        /// </summary>
        public TelephoneContact(string Name, string surname, string email, string idVK, global::System.DateTime birthDate, 
            long number)
        {
            this.BirthDate = birthDate;
            this.Email = email;
            this.IdVK = idVK;
            this.Name = Name;
            this.Surname = surname;
            TelephoneNumber.Number = number;
        }
   }
}
