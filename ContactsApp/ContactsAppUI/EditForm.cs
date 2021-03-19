using System;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class EditForm : Form
    {
        private Contact _contact;

        public EditForm()
        {
            InitializeComponent();
        }
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                if (_contact == null) return;
                NameTextBox.Text = _contact.Name;
                SurnameTextBox.Text = _contact.Surname;
                EmailTextBox.Text = _contact.Email;
                PhoneTextBox.Text = _contact.Number.Number.ToString();
                IdVkTextBox.Text = _contact.IdVK;
                dateBirthDay.Value = _contact.BirthDate;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
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
            _contact.BirthDate = dateBirthDay.Value;
            EditForm editForm = new EditForm();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _contact = null;
            this.Close();
        }
    }
}
