using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactsForm : Form
    {
        /// <summary>
        /// Поле хранящее список контактов
        /// </summary>
        private Project _project;

        private int index;

        /// <summary>
        /// Переменная хранящая путь 
        /// </summary>
        string defaultFilename = ProjectManager.DefaultFilename;

        /// <summary>
        /// обновляющийся список
        /// </summary>
        private BindingList<Contact> _formList;

        /// <summary>
        /// Инициализирует все компоненты, загружает информацию по контактам 
        /// </summary>
        public ContactsForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFromFile(defaultFilename);
        }

        /// <summary>
        /// Метод удаления контакта 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Click(object sender, EventArgs e)
        {
            if (ContactsListBox.Items.Count != 0)
            {
                var selectedIndex = ContactsListBox.SelectedIndex;
                if (ContactsListBox.Items.Count <= 0) return;
                if (selectedIndex < 0 || selectedIndex == 0 || selectedIndex == 1)
                {
                    selectedIndex = _project.Contacts.Count - 1;
                }
                else
                {
                    MessageBox.Show("Error: you haven't contacts for delete", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DialogResult result = MessageBox.Show("Are you wanna delete " +
                                                      _project.Contacts[ContactsListBox.SelectedIndex].Surname + "?", "Verification",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             
                if (result == DialogResult.OK)
                {  
                    selectedIndex = ContactsListBox.SelectedIndex;
                    _project.Contacts.RemoveAt(selectedIndex);
                    ContactsListBox.Items.Clear();
                    foreach (var contact in _project.Contacts)
                    {
                        ContactsListBox.Items.Add(contact.Surname);
                    }
                }
            }
        }

        /// <summary>
        /// Метод добавления контакта 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(); 

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
            if (ContactsListBox.SelectedIndex >= 0 && ContactsListBox.SelectedIndex < ContactsListBox.Items.Count)
            {
                var editForm = new EditForm
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
            _formList = new BindingList<Contact>(_project.Contacts);
            for (int i = 0; i < _formList.Count; i++)
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
            ProjectManager.SaveToFile(_project, defaultFilename);
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
                ContactsListBox.SelectedIndex = index;
            }
            NameTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndex].Name;
            SurnameTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndex].Surname;
            DateBirthDay.Value = _project.Contacts[ContactsListBox.SelectedIndex].BirthDate;
            EmailTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndex].Email;
            IdVkTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndex].IdVK;
            PhoneTextBox.Text = _project.Contacts[ContactsListBox.SelectedIndex].Number.Number.ToString();
        }
    }
}
