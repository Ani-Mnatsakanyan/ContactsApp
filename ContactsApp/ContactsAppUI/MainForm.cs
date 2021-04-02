using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
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
        }

        /// <summary>
        /// Метод удаления контакта 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
                
            var result = MessageBox.Show("Are you wanna delete " +
                                         _project.Contacts[selectedIndex].Surname + "?", "Verification",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             
            if (result == DialogResult.OK)
            {  
                _project.Contacts.RemoveAt(selectedIndex);
                ContactsListBox.Items.RemoveAt(selectedIndex);
            }
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
            ContactsListBox.Items.Add(editForm.Contact.Surname);
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
            //_formList = new BindingList<Contact>(_project.Contacts);
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
            if (ContactsListBox.SelectedIndex == -1)
            {
                return;
            }

            var contact = _project.Contacts[ContactsListBox.SelectedIndex];
            NameTextBox.Text = contact.Name;
            SurnameTextBox.Text = contact.Surname;
            DateBirthDay.Value = contact.BirthDate;
            EmailTextBox.Text = contact.Email;
            IdVkTextBox.Text = contact.IdVK;
            PhoneTextBox.Text = contact.PhoneNumber.Number.ToString();
        }
    }
}
