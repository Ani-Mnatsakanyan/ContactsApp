using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий информацию о контактах
    /// </summary>
    public class Project
    {
        /// <summary>
        /// закрытая переменная максимальной размерности
        /// </summary>
        private const int _capacity = 200;

        /// <summary>
        /// список для хранения контактов
        /// </summary>
        public List<TelephoneContact> _contacts;

        /// <summary>
        /// Метод инициализации списка контактов
        /// </summary>
        public Project()
        {
            _contacts = new List<TelephoneContact>(_capacity);
        }
    }
}
