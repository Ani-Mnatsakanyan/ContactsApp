using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactsApp;

namespace ContactsApp.UnitTests
{
    /// <summary>
    /// Тестирование класса сериализации и десериализации
    /// </summary>
    [TestFixture]
    class ProjectManagerTest
    {
        private const string CorrectProjectFile = @"TestData\correctproject.json";
        private const string IncorrectProjectFile = @"TestData\incorrectproject.json";
        private const string SavedFile = @"Output\SavedProjectFile.json";

        private Project getCorrectProject()
        {
            var project = new Project();
            
            PhoneNumber expectedphone = new PhoneNumber();
            expectedphone.Number = 79521817225;
            var contact = new Contact(
                "Ani",
                "Mnatsakanyan",
                "Anime@mail.ru",
                "iamani",
                new DateTime(2000, 8, 30),
                expectedphone);
            project.Contacts.Add(contact);
            
            expectedphone = new PhoneNumber();
            expectedphone.Number = 79139999999;
            contact = new Contact(
                "Ivanov",
                "Ivan",
                "Ivanov@mail.ru",
                "Id758964",
                new DateTime(1980, 7, 27),
                expectedphone);
            project.Contacts.Add(contact);
            return project;
        }

        [Test(Description = "Тест метода LoadFromFile")]
        public void ProjectManager_LoadCorrectData_FileLoadCorrected()
        {
            //SetUp
            var expectedProject = getCorrectProject();

            //Act
            var actualProject = ProjectManager.LoadFromFile(@"TestData\correctproject.json", "file");

             //Assert
            Assert.AreEqual(expectedProject.Contacts.Count, actualProject.Contacts.Count);

            Assert.Multiple(() =>
            {

                for (int i = 0; i < expectedProject.Contacts.Count; i++)
                {
                    var expected = expectedProject.Contacts[i];
                    var actual = actualProject.Contacts[i];
                    Assert.AreEqual(expected, actual);
                }
            });
        }

        [TestCase(Description = "", TestName = "")]
        public void ProjectManager_LoadInorrectData_FileLoadInorrectly()
        {
            // Assert
            Assert.Multiple(() =>
                {
                    var actualProject = ProjectManager.LoadFromFile(@"TestData\incorrectproject.json", "file");
                }
            );
        }

        [TestCase(Description = "", TestName = "")]
        public void ProjectManager_SaveCorrectData_FileSaveCorrectly()
        {
            // Setup
            var savingProject = getCorrectProject();

            // Act
            ProjectManager.SaveToFile(savingProject, @"Output\SavedProjectFile.json", "savefile");

            // Assert
            var expected = File.ReadAllText(@"TestData\correctproject.json");
            var actual = File.ReadAllText(@"Output\SavedProjectFile.json");
            Assert.AreEqual(expected, actual);
        }
    }
}
