using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    public class ManagerProject
    {
        /// <summary>
        /// Метод для сохранения информации
        /// </summary>
        ///   /// <param name="filename"></param>
        public static void SaveToFile(Project contacts, string falename) 
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(falename)) 
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, contacts);
            }
        } 
        
        /// <summary>
        /// Метод для загрузки информации по контактам
        /// </summary>
        public static Project Load(string falename)
        {
            Project contacts = new Project();
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(falename))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                contacts = (Project)serializer.Deserialize<Project>(reader);
            }

            return contacts;
        }
    }
}