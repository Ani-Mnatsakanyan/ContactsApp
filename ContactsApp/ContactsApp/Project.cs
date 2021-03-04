using System.Collections.Generic;

namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий список контактов
    /// </summary>
    public class Project
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
