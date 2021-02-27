using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace ContactsApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                //должен вывести ошибку, после исправить добавив еще одну 9
              TelephoneNumber nun =  new TelephoneNumber(number: 79999999999); 
            }
            catch (Exception e)
            {
                Console.WriteLine(value: e);
                throw;
            }
            Project data = new Project();
            ManagerProject.SaveToFile( contacts: data, falename: "savefile");
            TelephoneContact contact = new TelephoneContact(Name: "ani", surname: "mnatsakanyan",
                email: "Mnatsakanyan300800@mail.ru", idVK: "iamani2000", Convert.ToDateTime("30.08.2000"), 79999999999);
            Console.WriteLine(value: contact.Name + " " + contact.Surname + " " 
                                     + TelephoneNumber.Number + " " + contact.Email + " " 
                                     + contact.IdVK + " " + contact.BirthDate);
            Console.ReadKey();
       
        }
    }
}
