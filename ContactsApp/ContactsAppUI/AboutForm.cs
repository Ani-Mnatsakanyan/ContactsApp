using System.Windows.Forms;

namespace ContactsAppUI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Ani-Mnatsakanyan/ContactsApp");
        }
    }
}
