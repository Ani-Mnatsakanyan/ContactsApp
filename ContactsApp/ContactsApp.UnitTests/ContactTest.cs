using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    /// <summary>
    /// Класс тестов для тестирования Contact
    /// </summary>
    [TestFixture]
    class ContactTest
    {
        private Contact _testContact;

        [SetUp]
        public void SetUp()
        {
            _testContact = new Contact();
        }

        [Test(Description = "Позитивный тест геттера Surname")]
        public void TestSurnameGet_CorrectValue()
        {
            var expected = "Иванов";
            _testContact.Surname = expected;
            var actual = _testContact.Surname;
            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }

        [Test(Description = "Позитивный тест сеттера Surname")]
        public void TestSurnameSet_CorrectValue()
        {
            _testContact.Surname = "Иванов";
            var actual = _testContact.Surname;
            Assert.AreEqual(actual, _testContact.Surname, "Сеттер неправильно заполнил фамилию");
        }

        [Test(Description = "Присвоение неправильной фамилии")]
        [TestCase("", "Должно возникать исключение, если фамилия - пустая строка",
            TestName = "Присвоение пустой строки в качестве фамилии")]
        [TestCase("Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов", 
            "Должно возникать исключение, если фамилия длиннее 50 символов",
            TestName = "Присвоение неправильной фамилии больше 50 символов")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _testContact.Surname = wrongSurname; },
                message);
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void TestNameGet_CorrectValue()
        {
            var expected = "Иван";

            _testContact.Name = expected;
            var actual = _testContact.Name;
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void TestNameSet_CorrectValue()
        {
            _testContact.Name = "Иван";
            var actual = _testContact.Name;
            Assert.AreEqual(actual, _testContact.Name, "Сеттер неправильно заполнил имя");
        }

        [Test(Description = "Присвоение неправильного имени")]
        [TestCase("", "Должно возникать исключение, если имя - пустая строка",
            TestName = "Присвоение пустой строки в качестве имени")]
        [TestCase("Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван", 
            "Должно возникать исключение, если имя длиннее 50 символов", 
            TestName = "Присвоение неправильного имени больше 50 символов")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            Assert.Throws<ArgumentException>(
            () => { _testContact.Name = wrongName; },
            message);
        }

        [Test(Description = "Позитивный тест геттера Email")]
        public void TestMailGet_CorrectValue()
        {
            var expected = "Mnatsakanyan300800@mail.ru";

            _testContact.Email = expected;
            var actual = _testContact.Email;
            Assert.AreEqual(expected, actual, "Геттер Email возвращает неправильную почту");
        }

        [Test(Description = "Позитивный тест сеттера Email")]
        public void TestMailSet_CorrectValue()
        {
            _testContact.Email = "mnatsakanyan.ani@mail.ru";
            var actual = _testContact.Email;
            Assert.AreEqual(actual, _testContact.Email, "Сеттер неправильно заполнил почту");
        }

        
        [Test(Description = "Негативный тест сеттера Email")]
        [TestCase("",
            "Должно возникать исключение, если Email - пустая строка",
            TestName = "Присвоение пустой строки в качестве почты")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@mail.ru",
            "Должно возникать исключение, если почта больше 50 символов",
            TestName = "Присвоение неправильной почты больше 50 символов")]
        public void TestMailSet_ArgumentException(string wrongEmail, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _testContact.Email = wrongEmail; },
                message);
        }

        [Test(Description = "Позитивный тест геттера IdVk")]
        public void TestIdVkGet_CorrectValue()
        {
            var expected = "id777777";

            _testContact.IdVK = expected;
            var actual = _testContact.IdVK;
            Assert.AreEqual(expected, actual, "Геттер IdVK возвращает неправильный  idvk");
        }

        [Test(Description = "Позитивный тест сеттера IdVk")]
        public void TestIdVkSet_CorrectValue()
        {
            _testContact.IdVK = "iamani.i00";
            var actual = _testContact.IdVK;
            Assert.AreEqual(actual, _testContact.IdVK, "Сеттер неправильно заполнил idVk");
        }

        [Test(Description = "Негативный тест сеттера IdVK")]
        [TestCase("",
            "Должно возникать исключение, если IdVK - пустая строка",
            TestName = "Присвоение пустой строки в качестве IdVK")]
        [TestCase("id1234567899999999",
            "Должно возникать исключение, если IdVK > 15 символов",
            TestName = "Присвоение неправильной даты больше текущей")]
        public void TestIdVKSet_ArgumentException(string wrongIdVk, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _testContact.IdVK = wrongIdVk; },
                message);
        }

        [Test(Description = "Позитивный тест геттера BirthDate")]
        public void TestDateGet_CorrectValue()
        {
            DateTime expected = new DateTime(2000, 8, 30);

            _testContact.BirthDate = expected;
            var actual = _testContact.BirthDate;
            Assert.AreEqual(expected.Year, actual.Year, "Геттер BirthDay возвращает неправильную дату");
        }

        [Test(Description = "Позитивный тест сеттера BirthDate")]
        public void TestDateSet_CorrectValue()
        {
            _testContact.BirthDate = new DateTime(2000, 5, 20);
            var actual = _testContact.BirthDate;
            Assert.AreEqual(actual, _testContact.BirthDate, "Сеттер неправильно заполнил дату");
        }

        [TestCase("1899, 1, 5",
            "Должно возникать исключение, если год меньше 1900",
            TestName = "Присвоение неправильной даты меньше 1900")]
        [TestCase(null, "Должно возникать исключение, если дата - пустая строка",
            TestName = "Присвоение путой строки")]
        [TestCase("2025, 1, 5",
            "Должно возникать исключение, если год больше текущего", 
            TestName = "Присвоение неправильной даты больше текущей")]
        public void TestDateSet_ArgumentException(DateTime wrongDate, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _testContact.BirthDate = wrongDate; },
                message);
        }
    }
}
