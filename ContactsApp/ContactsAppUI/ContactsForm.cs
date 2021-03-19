using System;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactsForm : Form
    {
        private Project _allContacts = new Project();
        private int _countContacts;
        public ContactsForm()
        {
            InitializeComponent();
            this.Text = "ContactsApp";
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            ContactsListBox.Items.Remove(ContactsListBox.SelectedItem);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(); //создаем окно

            editForm.ShowDialog(); // открываем 

            if (editForm.Contact == null) return;
            _allContacts.Contacts.Add(new Contact()); 
            _allContacts.Contacts[_countContacts] = editForm.Contact;
            _countContacts++;
            UpdateListBox();
            /*  Contact newContact = new Contact();
            newContact.Name = "Смирнов";
            newContact.Number.Number = 79521817225;
            newContact.Email = "u.smirnov@fake.mail";
            _contacts.Add(newContact);
            ContactsListBox.Items.Add(newContact.Name);*/
        }

        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();
            for (int i = 0; i < _allContacts.Contacts.Count; i++)
            {
                ContactsListBox.Items.Add(_allContacts.Contacts[i].Surname);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm
            {
                Contact = _allContacts.Contacts[ContactsListBox.SelectedIndex]
            };
            editForm.ShowDialog();
            if (editForm.Contact != null)
            {
                _allContacts.Contacts[ContactsListBox.SelectedIndex] = editForm.Contact;
                UpdateListBox();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
