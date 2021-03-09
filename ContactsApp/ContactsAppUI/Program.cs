﻿using System;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form1());*/
            try
            {
                //должен вывести ошибку, после исправить добавив еще одну 9
                PhoneNumber num = new PhoneNumber(number: 79999999999);
            }
            catch (Exception e)
            {
                Console.WriteLine(value: e);
                throw;
            }
            Project data = new Project();
            Contact contact = new Contact(name: "ani", surname: "mnatsakanyan",
                email: "Mnatsakanyan300800@mail.ru", idVK: "iamani2000",
                new DateTime(2000, 8, 30), 79999999999);
            Console.WriteLine(value: contact.Name + " " + contact.Surname + " "
                                     + contact.Number.Number + " " + contact.Email + " "
                                     + contact.IdVK + " " + contact.BirthDate); 
            data.Contacts.Add(contact); 
            ProjectManager.SaveToFile(project: data, filename: "filename");
            Console.Read();
        }
    }
}