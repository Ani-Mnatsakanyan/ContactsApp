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
        public static void SaveToFile(Project project, string path, string filename)
        {
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            using (var sw = new StreamWriter(path + filename))
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
        public static Project LoadFromFile(string path, string filename)
        {
            if (!File.Exists(path + filename))
            {
                return new Project();
            }

            var serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            using (var sr = new StreamReader(path + filename))
            using (var reader = new JsonTextReader(sr))
            {
                return (Project)serializer.Deserialize<Project>(reader);
            }
        }
    }
}