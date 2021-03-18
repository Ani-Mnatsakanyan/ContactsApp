using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactsForm : Form
    {
        private List<Contact> _contacts = new List<Contact>();
        public ContactsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContactsListBox.Items.Remove(ContactsListBox.SelectedItem);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Contact newContact = new Contact();
            newContact.Name = "Смирнов";
            newContact.Number.Number = 79521817225;
            newContact.Email = "u.smirnov@fake.mail";
            _contacts.Add(newContact);
            ContactsListBox.Items.Add(newContact.Name);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ContactsForm_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
