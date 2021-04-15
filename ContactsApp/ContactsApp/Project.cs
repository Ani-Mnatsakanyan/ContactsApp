using System;
using System.Collections.Generic;

namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий список контактов
    /// </summary>
    public class Project : IEquatable<Project> 
    {
        /// <summary>
        /// Список контактов 
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public bool Equals(Project other)
        {
            if (other == null)
                return false;

            return this.Contacts.Equals(other.Contacts);
        }

       /// <summary>
       /// Метод, сортирующий список контактов
       /// </summary>
       public void SortList()
       {
           Contacts.Sort();
       }
      
       /// <summary>
       /// Метод, осуществляющий поиск контактов
       /// </summary>
       /// <param name="project"></param>
       /// <param name="str"></param>
       /// <returns></returns>
        public static Project FindContact(Project project, string str)
        {
            Project findContact = new Project();
            int count = 0;
            for (int i = 0; i < project.Contacts.Count; i++)
            {
                str = str.ToLower();
                if (str == String.Empty)
                {
                    return project;
                }
                if (project.Contacts[i].Surname.ToLower().Contains(str) ||
                    project.Contacts[i].Name.ToLower().Contains(str)) 
                    {
                        findContact.Contacts.Add(new Contact());
                        findContact.Contacts[count] = project.Contacts[i];
                        count++;
                    }
            }
            return findContact;
        }

        /// <summary>
        /// Метод, осуществляющий поиск именинников 
        /// </summary>
        /// <param name="project"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static Project FindBirthDay(Project project, DateTime date)
        {
            var findBirthArr = new Project();
            var count = 0;
            for (var i = 0; i < project.Contacts.Count; i++)
            {
                if (project.Contacts[i].BirthDate.Month == date.Month && 
                    project.Contacts[i].BirthDate.Day == date.Day)
                {
                    findBirthArr.Contacts.Add(new Contact());
                    findBirthArr.Contacts[count] = project.Contacts[i];
                    count++;
                }
            }
            return findBirthArr;
        }
    }
}
