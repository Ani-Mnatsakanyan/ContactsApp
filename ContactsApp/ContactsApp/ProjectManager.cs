using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс сериализации
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// переменная хранящая путь к сохранению файла сериализации
        /// </summary>
        public static string DefaultFilename
        {
            get
            {
                var appDataFolder =
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var defaultFilename = appDataFolder + $@"\ContactsApp\contacts.json";
                return defaultFilename;
            }
        }

        /// <summary>
        /// Метод для сохранения информации
        /// </summary>
        /// <param name="project"></param>
        /// <param name="filename"></param>
        public static void SaveToFile(Project project, string filename)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(filename))
            using (var writer = new JsonTextWriter(sw))
            { 
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, project);
            }
        }
        
        /// <summary>
        /// Метод для загрузки информации по контактам
        /// </summary>
        /// <returns></returns>
        public static Project LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return new Project();
            }

            var project = new Project();
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader(filename))
            using (var reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
                if (project == null)
                { 
                    return new Project();
                }
            }
            return project;
        }
    }
}