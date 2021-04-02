using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    /// <summary>
    /// Класс тестов для тестирования PhoneNumber
    /// </summary>
    public class PhoneNumberTest
    {
        private PhoneNumber _testNumber;

        public void SetUp()
        {
            _testNumber = new PhoneNumber();
        }

        [Test(Description = "Позитивный тест геттера Number")]
        public void TestNumberGet_CorrectValue()
        {
            //SetUp
            SetUp();

            //Act
            var expected = 79531817562;
            _testNumber.Number = expected;
            var actual = _testNumber.Number;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер Number возвращает неправильный номер");
        }

        [Test(Description = "Позитивный тест сеттера Number")]
        public void TestNumberSet_CorrectValue()
        {
            //SetUp
            SetUp();

            //Act
            _testNumber.Number = 79523658444;
            var actual = _testNumber.Number;

            //Assert
            Assert.AreEqual(actual, _testNumber.Number, "Сеттер неправильно заполнил номер");
        }

        [TestCase(null, "Должно возникать исключение, если телефон - пустая строка", 
            TestName = "Присвоение пустой строки в качестве номера")]
        [TestCase(789, "Должно возникать исключение, если номер короче 11 символов",
            TestName = "Присвоение неправильного номера короче 11 символов")]
        [TestCase(789878978788, "Должно возникать исключение, если номер длиннее 11 символов",
            TestName = "Присвоение неправильного номера длиннее 11 символов")]
        public void TestNumberSet_ArgumentException(long wrongNumber, string message)
        {
            //SetUp
            SetUp();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { _testNumber.Number = wrongNumber; }, message);
        }
    }
}
