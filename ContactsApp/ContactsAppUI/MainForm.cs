using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Поле хранящее список контактов
        /// </summary>
        private Project _project;

        /// <summary>
        /// Обновленный список контаков, удовлетворяющий условиям поиска
        /// </summary>
        private List<Contact> _findedContacts = new List<Contact>();

        /// <summary>
        /// Переменная хранящая путь 
        /// </summary>
        private string _defaultFilename = ProjectManager.DefaultFilename;

        /// <summary>
        /// Инициализирует все компоненты, загружает информацию по контактам 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFromFile(_defaultFilename, "contact.json");
            _project.SortList();
            CheckBirthdayToday();
            //DateTime curDate = DateTime.Today;
            //BirthDateLabel.Text = "У них сегодня день рождения: ";
            //for (int i = 0; i < Project.FindBirthDay(_project, curDate).Contacts.Count; i++)
            //{
            //    BirthDateLabel.Text += Project.FindBirthDay(_project, curDate).Contacts[i].Surname + ", ";
            //}
        }

        /// <summary>
        /// Удаления контакта 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        /// <summary>
        /// Метод, реализующий удаление контакта по нажатию на клавишу Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteContact();
            }
        }

        /// <summary>
        ///  Метод удаления контакта
        /// </summary>
        private void DeleteContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete " +
                                         _project.Contacts[selectedIndex].Surname + 
                                         " from your contact list?", "Delete contact",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result != DialogResult.OK) return;
            _project.Contacts.RemoveAt(selectedIndex);
            ContactsListBox.Items.RemoveAt(selectedIndex);
        }
        /// <summary>
        /// Метод добавления контакта 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            ContactForm editForm = new ContactForm();

            editForm.ShowDialog();

            if (editForm.Contact == null) return;
            _project.Contacts.Add(new Contact());
            _project.Contacts[ContactsListBox.Items.Count] = editForm.Contact;
            _project.SortList();
            ContactsListBox.Items.Clear();
            foreach (var t in _project.Contacts)
            {
                ContactsListBox.Items.Add(t.Surname);
            }
            CheckBirthdayToday();
        }

        /// <summary>
        /// Метод редактирования контакта 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex >= 0)
            {
                var editForm = new ContactForm
                {
                    Contact = _project.Contacts[ContactsListBox.SelectedIndex]
                };
                editForm.ShowDialog();
                if (editForm.Contact == null) return;
                _project.Contacts[ContactsListBox.SelectedIndex] = editForm.Contact;
                ContactsListBox.Items.Clear();
                foreach (var t in _project.Contacts)
                {
                    ContactsListBox.Items.Add(t.Surname);
                }
            }
        }

        /// <summary>
        /// Метод, описывающий реакцию на нажатие кнопки About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Обновление списка контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < _project.Contacts.Count; i++)
            {
                ContactsListBox.Items.Add(_project.Contacts[i].Surname);
            }
        }

        /// <summary>
        /// Сохраняет данные при закрытии формы 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProjectManager.SaveToFile(_project, _defaultFilename, "contact.json");
        }

        /// <summary>
        /// Отображение контакта на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contact contact;
            if (ContactsListBox.SelectedIndex == -1 || ContactsListBox.Items == null)
            {
                NameTextBox.Text = null;
                SurnameTextBox.Text = null;
                DateBirthDay.Value = DateTime.Today;
                EmailTextBox.Text = null;
                IdVkTextBox.Text = null;
                PhoneTextBox.Text = null;
                return;
            }

            contact = FindTextBox.Text == String.Empty
                ? contact = _project.Contacts[ContactsListBox.SelectedIndex]
                : _findedContacts[ContactsListBox.SelectedIndex];

            NameTextBox.Text = contact.Name;
            SurnameTextBox.Text = contact.Surname;
            DateBirthDay.Value = contact.BirthDate;
            EmailTextBox.Text = contact.Email;
            IdVkTextBox.Text = contact.IdVK;
            PhoneTextBox.Text = contact.PhoneNumber.Number.ToString();
        }

        /// <summary>
        /// Поиск контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        { 
            ContactsListBox.Items.Clear();
            _findedContacts.Clear();
            foreach (var t in Project.FindContact(_project, FindTextBox.Text).Contacts)
            {
                _findedContacts.Add(t);
                ContactsListBox.Items.Add(t.Surname);
                NameTextBox.Text = t.Name;
                SurnameTextBox.Text = t.Surname;
                DateBirthDay.Value = t.BirthDate;
                EmailTextBox.Text = t.Email;
                IdVkTextBox.Text = t.IdVK;
                PhoneTextBox.Text = t.PhoneNumber.Number.ToString();
            }
        }

        /// <summary>
        /// Метод реализующий вывоод информации об именинниках
        /// </summary>
        private void CheckBirthdayToday()
        {
            var today = DateTime.Today;
            var birthdayContact = Project.FindBirthDay(_project, today);
            if (birthdayContact.Contacts.Count != 0)
            {
                BirthdayPanel.Visible = true;
                BirthDateLabel.Text = "Сегодня день рождения: ";
                for (int i = 0; i < Project.FindBirthDay(_project, today).Contacts.Count; i++)
                {
                    var birthdayLabelText = String.Join(", ", birthdayContact.Contacts[i].Surname);
                    BirthDateLabel.Text += birthdayLabelText;
                }
            }
            else
            {
                BirthdayPanel.Visible = false;
            }
        }
    }
}
