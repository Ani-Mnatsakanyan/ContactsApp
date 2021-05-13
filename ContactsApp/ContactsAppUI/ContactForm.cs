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
        /// Поле, хранящее контакт 
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// Переменная для проверки корректного ввода всех TextBox
        /// </summary>
        bool _IsCorrectContact;

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
                if (_contact == null) return;
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
        /// Реакция нажатия на кнопку ОК после заполнения всех TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            _IsCorrectContact = IsContactValidated();
           
            if (NameTextBox.Text != null && SurnameTextBox.Text != null && _IsCorrectContact == false
                                         && PhoneTextBox.Text.Length == 11 && NameTextBox.Text != string.Empty
                                         && SurnameTextBox.Text != string.Empty)
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
            SurnameTextBox.BackColor = check ? Color.Red : Color.White;
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
            NameTextBox.BackColor = check ? Color.Red : Color.White;
        }

        /// <summary>
        /// Проверка ввода номера 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneTextBox_Leave(object sender, EventArgs e)
        {
            PhoneTextBox.BackColor = PhoneTextBox.Text.Length != 11 ? Color.Red : Color.White;
            if (PhoneTextBox.Text.StartsWith("7")) return;
            PhoneTextBox.BackColor = Color.Red;
        }

        /// <summary>
        /// Проверку ввода почты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            EmailTextBox.BackColor = EmailTextBox.Text.Contains("@") ? Color.White : Color.Red;
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
                BirthDayLabel.ForeColor = Color.Red;
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
        /// Проверяет наличие некорректных данных для ввода
        /// </summary>
        /// <returns>true - если есть некорректные данные, иначе false</returns>
        private bool IsContactValidated()
        {
            return SurnameTextBox.BackColor == Color.Red ||
                   NameTextBox.BackColor == Color.Red ||
                   PhoneTextBox.BackColor == Color.Red ||
                   IdVkTextBox.Text == String.Empty ||
                   BirthDayLabel.Text == "Error";
        }
    }
}
