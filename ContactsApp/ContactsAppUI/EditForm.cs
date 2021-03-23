using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    /// <summary>
    /// Класс редактирования и добавления контактов 
    /// </summary>
    public partial class EditForm : Form 
    {
        /// <summary>
        /// Поле, хранящее контакт 
        /// </summary>
        private Contact _contact;
        /// <summary>
        /// 
        /// </summary>
        bool _globalCheck;
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
                PhoneTextBox.Text = _contact.Number.Number.ToString();
                IdVkTextBox.Text = _contact.IdVK;
                DateBirthDay.Value = _contact.BirthDate;
            }
        }

        public EditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Реакция нажатия на кнопку ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (SurnameTextBox.BackColor == Color.Red ||
                NameTextBox.BackColor == Color.Red ||
                PhoneTextBox.BackColor == Color.Red || 
                BirthDayLabel.Text == "Error")
            {
                _globalCheck = true;
            }
            else
            {
                _globalCheck = false;
            }

            if (NameTextBox.Text != null && SurnameTextBox.Text != null && _globalCheck == false
                                         && PhoneTextBox.Text.Length == 11 && NameTextBox.Text != string.Empty
                                         && SurnameTextBox.Text != string.Empty)
            {
                _contact = new Contact
                {
                    Number = new PhoneNumber(),
                    Name = NameTextBox.Text,
                    Surname = SurnameTextBox.Text,
                    Email = EmailTextBox.Text
                };
                _contact.Number.Number = Convert.ToInt64(PhoneTextBox.Text);
                _contact.IdVK = IdVkTextBox.Text;
                _contact.BirthDate = DateBirthDay.Value;
                var editForm = new EditForm();
                Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Check if the values are correct and try again",
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
            var check = false;
            for (var i = 0; i < SurnameTextBox.TextLength; i++)
            {
                foreach (var t in _incorrectSymbols.Where(t => SurnameTextBox.Text[i] == t))
                {
                    check = true;
                }
            }
            SurnameTextBox.BackColor = check == true ? Color.Red : Color.White;
        }

        /// <summary>
        /// Проверка ввода имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            var check = false;
            for (var i = 0; i < NameTextBox.TextLength; i++)
            {
                foreach (var t in _incorrectSymbols)
                {
                    if (NameTextBox.Text[i] == t)
                    {
                        check = true;
                    }
                }
            }
            NameTextBox.BackColor = check == true ? Color.Red : Color.White;
        }

        /// <summary>
        /// Проверка ввода номера 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneTextBox_Leave(object sender, EventArgs e)
        {
            PhoneTextBox.BackColor = PhoneTextBox.Text.Length != 11 ? Color.Red : Color.White;
            if(PhoneTextBox.Text.StartsWith("7") == false)
            { 
               PhoneTextBox.BackColor = Color.Red; 
            }
        }

       /// <summary>
       /// Проверку корректного ввода почты
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            EmailTextBox.BackColor = !Regex.IsMatch(EmailTextBox.Text, "[@]") ? Color.Red : Color.White;
        }

        /// <summary>
        /// Проверку корректного ввода даты рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateBirthDay_ValueChanged(object sender, EventArgs e)
        {
            if (DateBirthDay.Value.Year >= 1900 && DateBirthDay.Value <= DateTime.Today)
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
    }
}
