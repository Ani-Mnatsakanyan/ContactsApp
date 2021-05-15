using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    /// <summary>
    /// Класс редактирования и добавления контактов 
    /// </summary>
    public partial class ContactForm : Form 
    {
        /// <summary>
        /// Для некорректного значения TextBox
        /// </summary>
        public static readonly Color IncorrectValue = Color.DarkSalmon;

        /// <summary>
        /// Для корректного значения TextBox
        /// </summary>
        public static readonly Color CorrectValue = Color.White;

        /// <summary>
        /// Поле, хранящее контакт 
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// Переменная для проверки корректного ввода всех TextBox
        /// </summary>
        private bool _isCorrectContact;

        /// <summary>
        /// Переменная, хранящая недопустимые для ввода символы
        /// </summary>
        string _incorrectSymbols = @"123456789!@#$%^&*()_+|-=\.,<>";

        /// <summary>
        ///  Загрузка формы 
        /// </summary>
        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                if (_contact == null)
                {
                    return;
                }
                NameTextBox.Text = _contact.Name;
                SurnameTextBox.Text = _contact.Surname;
                EmailTextBox.Text = _contact.Email;
                PhoneTextBox.Text = _contact.PhoneNumber.Number.ToString();
                IdVkTextBox.Text = _contact.IdVK;
                DateBirthDay.Value = _contact.BirthDate;
            }
        }

        /// <summary>
        /// Инициализирует все компоненты
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Проверяет наличие некорректных данных для ввода
        /// </summary>
        /// <returns>true - если есть некорректные данные, иначе false</returns>
        private bool IsContactValidated()
        {
            return SurnameTextBox.BackColor == IncorrectValue ||
                   NameTextBox.BackColor == IncorrectValue ||
                   PhoneTextBox.BackColor == IncorrectValue ||
                   IdVkTextBox.Text == String.Empty ||
                   BirthDayLabel.Text == "Error";
        }

        /// <summary>
        /// Проверяет все TextBox на наличие символов и их корректность
        /// </summary>
        /// <returns>true - если проверка пройдена, иначе false</returns>
        private bool CheckTextBox()
        {
            return NameTextBox.Text != null && SurnameTextBox.Text != null && _isCorrectContact == false
                   && PhoneTextBox.Text.Length == 11 && NameTextBox.Text != string.Empty
                   && SurnameTextBox.Text != string.Empty;
        }

        /// <summary>
        /// Реакция нажатия на кнопку ОК после заполнения всех TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            _isCorrectContact = IsContactValidated();
            if (CheckTextBox())
            {
                _contact = new Contact
                {
                    PhoneNumber = new PhoneNumber(),
                    Name = NameTextBox.Text,
                    Surname = SurnameTextBox.Text,
                    Email = EmailTextBox.Text
                };
                _contact.PhoneNumber.Number = Convert.ToInt64(PhoneTextBox.Text);
                _contact.IdVK = IdVkTextBox.Text;
                _contact.BirthDate = DateBirthDay.Value;
                Close();
            }
            else
            {
                MessageBox.Show("Check if the values are correct and try again",
                    "" , MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Реакция нажатия на кнопку Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            _contact = null;
            Close();
        }

        /// <summary>
        /// Проверка ввода фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurnameTextBox_Leave(object sender, EventArgs e)
        {
            var check = SurnameTextBox.Text.Length >= 50;
            for (var i = 0; i < SurnameTextBox.TextLength; i++)
            {
                foreach (var t in _incorrectSymbols.Where(t => SurnameTextBox.Text[i] == t))
                {
                    check = true;
                }
            }
            SurnameTextBox.BackColor = check ? IncorrectValue : CorrectValue;
        }

        /// <summary>
        /// Проверка ввода имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            var check = NameTextBox.Text.Length >= 15;
            for (var i = 0; i < NameTextBox.TextLength; i++)
            {
                foreach (var t in _incorrectSymbols.Where(t => NameTextBox.Text[i] == t))
                {
                    check = true;
                }
            }
            NameTextBox.BackColor = check ? IncorrectValue : CorrectValue;
        }

        /// <summary>
        /// Проверка ввода номера 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneTextBox_Leave(object sender, EventArgs e)
        {
            PhoneTextBox.BackColor = PhoneTextBox.Text.Length != 11 ? IncorrectValue : CorrectValue;
            if (PhoneTextBox.Text.StartsWith("7"))
            {
                return;
            }
            PhoneTextBox.BackColor = IncorrectValue;
        }

        /// <summary>
        /// Проверку ввода почты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            EmailTextBox.BackColor = EmailTextBox.Text.Contains("@") ? CorrectValue : IncorrectValue;
        }

        /// <summary>
        /// Проверка ввода даты рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateBirthDay_ValueChanged(object sender, EventArgs e)
        {
            if (DateBirthDay.Value.Year >= 1900 && DateBirthDay.Value <= DateTime.Now)
            {
                BirthDayLabel.Text = "BirthDay";
                BirthDayLabel.ForeColor = Color.Black;
            }
            else
            {
                BirthDayLabel.Text = "Error";
                BirthDayLabel.ForeColor = IncorrectValue;
            }
        }

    }
}
