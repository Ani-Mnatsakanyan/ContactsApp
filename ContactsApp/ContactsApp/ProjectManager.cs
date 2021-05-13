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
        /// Переменная хранящая путь к сохранению файла сериализации
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
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод для загрузки информации по контактам
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
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
            try
            {
                using (var sr = new StreamReader(path + filename))
                using (var reader = new JsonTextReader(sr))
                {
                    var project = serializer.Deserialize<Project>(reader);
                    return project ?? new Project();
                }
            }
            catch
            {
                return new Project();
            }
        }
    }
}